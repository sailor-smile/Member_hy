using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using member_hy.Models;
using Member_hy.Context;
using Member_hy.Biz.MemberM;
using Member_hy.Dto.Users;
using Member_hy.Dto;
using Member_hy.Entitys;

namespace member_hy.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ICluberDaoService _cluberDaoService;
        public HomeController(ICluberDaoService cluberDaoService)
        {
            _cluberDaoService = cluberDaoService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Modify(int x)
        {
            ViewData["xid"] = x;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FindforPage(PageCond<Vmparameter> pageCond)
        {
            try
            {
                var list = _cluberDaoService.FindVmcoes(pageCond);
                return Json(new JsonCallRes(OK, list));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FindforPagesousuo(PageCond<Vmparameter> pageCond)
        {
            try
            {
                var list = _cluberDaoService.FindVmcoessousuo(pageCond);
                return Json(new JsonCallRes(OK, list));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(Cluber cluber)
        {
            try
            {
                var state = _cluberDaoService.Save(cluber);
                return Json(new JsonCallRes(state));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeletMemberM(int id)
        {
            try
            {
                var state = _cluberDaoService.Delet(id);
                return Json(new JsonCallRes(state));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }

        /// <summary>
        ///  根据id获取信息
        /// </summary>
        /// <param name="dataId">ID</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCber(int dataId)
        {
            try
            {
                var data = _cluberDaoService.Cber(dataId);
                return Json(new JsonCallRes(OK, data));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
       [HttpPost]
        public IActionResult Update(Cluber cber)
        {
            try
            {
                var update = _cluberDaoService.Update(cber);
                return Json(new JsonCallRes(update));
            }
            catch (Exception e)
            {

                return Json(new JsonCallRes(ERROR));
            }
        }







    }
}
