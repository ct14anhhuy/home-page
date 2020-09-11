using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserLoginService
    {
        IEnumerable<UserLoginDTO> GetAll();

        UserLoginDTO GetUserInfoByUserName(string userName);

        bool CheckLogin(string userName, string password);

        bool ChangePassword(UserLoginDTO userLogin);

        UserLoginDTO CreateUser(UserLoginDTO userLogin);
    }
}