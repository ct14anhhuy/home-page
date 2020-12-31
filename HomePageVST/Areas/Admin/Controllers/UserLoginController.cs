using DTO;
using HomePageVST.Controllers.Core;
using HomePageVST.Extensions.AntiModelInjection;
using HomePageVST.Extensions.Authentication;
using Services.Interfaces;
using System.Web.Mvc;
using System.Web.Security;
using Utilities;

namespace HomePageVST.Areas.Admin.Controllers
{
    [Authorize]
    public class UserLoginController : ControllerCore
    {
        private readonly IUserLoginService _userLoginService;
        private readonly UserRoleProvider _userRoleProvider;

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
                    ModelState.AddModelError(string.Empty, "User name or password incorrect!");
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
        public ActionResult ChangePassword(UserLoginDTO userLogin)
        {
            ModelState["UserName"].Errors.Clear();
            if (string.IsNullOrEmpty(userLogin.NewPassword))
            {
                ModelState.AddModelError("NewPassword", "Enter your new password");
            }
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