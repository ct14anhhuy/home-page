using DTO;
using HomePageVST.Controllers.Core;
using HomePageVST.Extensions.AntiModelInjection;
using HomePageVST.Extensions.Authentication;
using Services.Interfaces;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Utilities;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class UserLoginController : ControllerCore
    {
        private IUserLoginService _userLoginService;
        private UserRoleProvider _userRoleProvider;

        public UserLoginController(IUserLoginService userLoginService, UserRoleProvider userRoleProvider)
        {
            _userLoginService = userLoginService;
            _userRoleProvider = userRoleProvider;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Recruitment");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginDTO userLogin)
        {
            if (ModelState.IsValid)
            {
                bool checkLogin = _userLoginService.CheckLogin(userLogin.UserName, userLogin.Password);
                if (checkLogin)
                {
                    FormsAuthentication.SetAuthCookie(userLogin.UserName, false);
                    return RedirectToAction("Index", "Recruitment");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "user name or pass incorrect!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            ViewBag.Active = "change-password";
            UserLoginDTO user = _userLoginService.GetUserInfoByUserName(User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("Id")]
        [ValidateAntiModelInjection("UserName")]
        [ValidateAntiModelInjection("RoleId")]
        [ValidateAntiModelInjection("CreatedAt")]
        [ValidateAntiModelInjection("IsActive")]
        public ActionResult ChangePassword(UserLoginDTO userLogin)
        {
            if (ModelState.IsValid)
            {
                bool result = _userLoginService.ChangePassword(userLogin);
                if (result)
                {
                    ViewBag.PasswordChanged = true;
                    FormsAuthentication.SignOut();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something wrong, enter again");
                }
            }
            return View(userLogin);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser(UserLoginDTO userLogin)
        {
            userLogin.RoleId = CommonConstants.USER_ROLE;
            if (ModelState.IsValid)
            {
                _userLoginService.CreateUser(userLogin);
                return RedirectToAction("Index", "Recruitment");
            }
            else
            {
                return View(userLogin);
            }
        }
    }
}