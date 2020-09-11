﻿using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class UserLoginService : IUserLoginService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<UserLogin> _userLoginRepository;
        private IMapper _mapper;

        public UserLoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userLoginRepository = _unitOfWork.UserLoginRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserLoginDTO> GetAll()
        {
            var userLogins = _userLoginRepository.GetAll();
            return _mapper.Map<IEnumerable<UserLoginDTO>>(userLogins);
        }

        public UserLoginDTO GetUserInfoByUserName(string userName)
        {
            var user = _userLoginRepository.GetSingleByPredicate(x => x.UserName == userName, x => x.Role);
            return _mapper.Map<UserLoginDTO>(user);
        }

        public bool CheckLogin(string userName, string password)
        {
            bool verifyPassword = false;
            var user = _userLoginRepository.GetSingleByPredicate(x => x.UserName == userName && x.IsActive);
            if (user != null)
            {
                verifyPassword = CryptoService.VerifyPassword(password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt));
            }
            return verifyPassword;
        }

        public bool ChangePassword(UserLoginDTO userLogin)
        {
            bool checkError = false;
            bool verifyPassword = false;

            var user = _userLoginRepository.GetSingleByPredicate(x => x.UserName == userLogin.UserName && x.IsActive);
            if (user != null)
            {
                verifyPassword = CryptoService.VerifyPassword(userLogin.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt));
                if (verifyPassword)
                {
                    byte[] salt = CryptoService.GenerateSalt();
                    userLogin.PasswordSalt = Convert.ToBase64String(salt);
                    userLogin.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(userLogin.NewPassword, salt));
                    _userLoginRepository.Update(_mapper.Map<UserLogin>(userLogin));
                    _unitOfWork.Commit();
                    checkError = true;
                }
            }
            return checkError;
        }

        public UserLoginDTO CreateUser(UserLoginDTO userLogin)
        {
            byte[] salt = CryptoService.GenerateSalt();
            userLogin.PasswordSalt = Convert.ToBase64String(salt);
            userLogin.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(userLogin.Password, salt));
            var user = _userLoginRepository.Add(_mapper.Map<UserLogin>(userLogin));
            _unitOfWork.Commit();
            return _mapper.Map<UserLoginDTO>(user);
        }
    }
}