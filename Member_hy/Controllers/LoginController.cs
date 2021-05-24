
using Member_hy.Biz.Users;
using Member_hy.Context;
using Member_hy.Dto.Users;
using Member_hy.Entitys;
using Member_hy.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Member_hy.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginDaoService _loginDaoService;
        public LoginController(ILoginDaoService loginDaoService)
        {
            _loginDaoService = loginDaoService;
        }

        public IActionResult Loginout()
        {
            HttpContext.Session.Remove(GlobalConstants.S_USER);
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Loginog(UserVmer vmer)
        {

            string message = string.Empty;
            JsonCallRes res = null;
            try
            {
                var account = vmer.UserName;
                var pwd = vmer.Newpwd;
                if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
                {
                    message = "用户名或密码不能为空.";
                    res = new JsonCallRes(GlobalConstants.ERROR, message, null);
                    return Json(res);
                }
                vmer.UserName = Base64Util.DecodeBase64(account);
                vmer.Newpwd = Base64Util.DecodeBase64(pwd);

                IniUser user = _loginDaoService.User(vmer);//登录验证
                if (user == null)
                {
                    message = "用户名或密码错误";
                    res = new JsonCallRes(GlobalConstants.ERROR, message, null);
                    return Json(res);
                }
                HttpContext.Session.Set(GlobalConstants.S_USER, ByteConvertHelper.Object2Bytes(user));
                if (user.Usertype == "1")
                {
                    res = new JsonCallRes(GlobalConstants.OK, JsonConvert.SerializeObject(user), "/IdCard/Index");
                    return Json(res);
                }
                else
                    return null;

            }
            catch (Exception e)
            {
                message = e.Message;
                res = new JsonCallRes(GlobalConstants.ERROR, message, null);
                return Json(res);
            }






        }
    }
}