using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member_hy.Biz.ConsumptionView;
using Member_hy.Context;
using Member_hy.Dto;
using Member_hy.Dto.Consumption;
using Microsoft.AspNetCore.Mvc;

namespace Member_hy.Controllers
{
    public class ConsumptionController : BaseController
    {
        private readonly IConsumptionViewDaoService _consumptionViewDaoService;
        public ConsumptionController  (IConsumptionViewDaoService consumptionViewDaoService)
        {
            _consumptionViewDaoService = consumptionViewDaoService;

        }
       
        public IActionResult Index(string lid)
        {
            ViewData["iid"] = lid;
            return View();
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
                var psgeList = _consumptionViewDaoService.FindConsumption(pageCond);
                return Json(new JsonCallRes(OK, psgeList));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }

        /// <summary>
        /// 根据时间搜索
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FindforPagesousuo(PageCond<Consumptionter> pageCond)
        {
            try
            {
                var psgeList = _consumptionViewDaoService.FindConsumptionsousuo(pageCond);
                return Json(new JsonCallRes(OK, psgeList));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }


        /// <summary>
        /// 单查
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        public IActionResult FindforPagess(int liushuicode)
        {
            try
            {
                var list = _consumptionViewDaoService.FindConsumptions(liushuicode);
                return Json(new JsonCallRes(OK, list));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeletConsumption(int id)
        {
            try
            {
                var state = _consumptionViewDaoService.Delet(id);
                return Json(new JsonCallRes(state));
            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }





    }
}