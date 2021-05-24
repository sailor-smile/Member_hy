using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member_hy.Context;
using Member_hy.Dao.ConsumptionView;
using Member_hy.Dto;
using Member_hy.Dto.Consumption;
using Member_hy.Entitys;

namespace Member_hy.Biz.ConsumptionView
{
    public class ConsumptionViewDaoServiceImpl : IConsumptionViewDaoService
    {
        private readonly IConsumptionViewDao _consumptionViewDao;
        public ConsumptionViewDaoServiceImpl(IConsumptionViewDao consumptionViewDao) {
            _consumptionViewDao = consumptionViewDao;
        }

        public int Delet(int id)
        {
           return _consumptionViewDao.Delet(id);
        }

        public PageList<Consumption> FindConsumption(PageCond<Vmparameter> pageCond)
        {
          return  _consumptionViewDao.FindConsumption(pageCond);
        }

        public Consumption FindConsumptions(int liushuicode)
        {
            return _consumptionViewDao.FindConsumptions(liushuicode);
        }

        public PageList<Consumption> FindConsumptionsousuo(PageCond<Consumptionter> pageCond)
        {
            return _consumptionViewDao.FindConsumptionsousuo(pageCond);
        }

  
    }
}
