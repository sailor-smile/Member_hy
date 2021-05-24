
using Member_hy.Context;
using Member_hy.Entitys;
using Member_hy.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace Member_hy.Context
{
    /// <summary>
    /// 控制器抽象
    /// </summary>
    public class BaseController : Controller
    {
        protected static int ERROR = 0;
        protected static int OK = 1;
     

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Session.TryGetValue(GlobalConstants.S_USER, out byte[] result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
                return;
            }
            else
            {
                IniUser user = ByteConvertHelper.Bytes2Object<IniUser>(result);
                base.ViewData["realName"] = user.URealnaem;
                base.ViewData["uid"] = user.Username;
                base.ViewData["wd"] = user.Userword;
                base.ViewData["aaaa"] = user.URealnaem;

            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public IniUser GetUser()
        {
            HttpContext.Session.TryGetValue(GlobalConstants.S_USER, out byte[] userBytes);
            return ByteConvertHelper.Bytes2Object<IniUser>(userBytes);
        }
    }
}