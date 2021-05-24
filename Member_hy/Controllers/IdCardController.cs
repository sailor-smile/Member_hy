using System;
using Member_hy.Biz.ConsumptionView;
using Member_hy.Context;
using Member_hy.Dao.IdCard;
using Member_hy.Dto;
using Member_hy.Dto.IdCard;
using Member_hy.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Member_hy.Controllers
{
    public class IdCardController : BaseController
    {
        private readonly IdCardDaoService _idCardDaoService;
        private readonly IConsumptionViewDaoService _consumptionViewDaoService;
        public IdCardController(IdCardDaoService idCardDaoService, IConsumptionViewDaoService consumptionViewDaoService)
        {
            _idCardDaoService = idCardDaoService;
            _consumptionViewDaoService = consumptionViewDaoService;
        }
       
        public IActionResult Index(string d,string lid)
        {
            ViewData["dataId"] = d;
            ViewData["iid"] = lid;
            return View();
        }
        
        public IActionResult Create()
        {
            
            return View();
        }

        public IActionResult Modify(string xid) {

            ViewData["xid"] = xid;
            return View();
        }


        [HttpPost]
        public IActionResult FindCard(Vmparameter vmparameter)
        {
            try
            {
                var list = _idCardDaoService.FindClubercars(vmparameter);
                return Json(new JsonCallRes(OK, list));

            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }

        [HttpPost]
        public IActionResult FindConsumption(PageCond<Vmparameter> pageCond)
        {
            try
            {
                var list = _consumptionViewDaoService.FindConsumption(pageCond);
                return Json(new JsonCallRes(OK, list));

            }
            catch (Exception)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }

        //消费功能
        [HttpPost]
        public IActionResult Xiaofei(Clubercar cber)
        {
            try
            {
                var list = _idCardDaoService.Updateqian(cber);
                return Json(new JsonCallRes(list));

            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }

        //添加消费记录功能
        [HttpPost]
        public IActionResult Xiaofeijilu(Consumption cber)
        {
            try
            {
                var list = _idCardDaoService.SaveConsum(cber);
                return Json(new JsonCallRes(list));

            }
            catch (Exception e)
            {
                return Json(new JsonCallRes(ERROR));
            }

        }



        [HttpPost]
        public IActionResult Save(SaveAll sall)
        {
            try
            {
                var list = _idCardDaoService.SaveIdcard(sall);
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
        /// <param name="pageCond"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeletIdCard(string id)
        {
            try
            {
                var state = _idCardDaoService.Delet(id);
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
        public IActionResult GetCbercar(string dataId)
        {
            try
            {
                var data = _idCardDaoService.Cber(dataId);
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
        public IActionResult Update(Clubercar cber)
        {
            try
            {
                var update = _idCardDaoService.Update(cber);
                return Json(new JsonCallRes(update));
            }
            catch (Exception e)
            {

                return Json(new JsonCallRes(ERROR));
            }
        }



    }
}