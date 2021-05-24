using Member_hy.Context;
using Member_hy.Dto;
using Member_hy.Dto.Consumption;
using Member_hy.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Biz.ConsumptionView
{
    public interface IConsumptionViewDaoService
    {
        Consumption FindConsumptions(int liushuicode);


        PageList<Consumption> FindConsumption(PageCond<Vmparameter> pageCond);
        PageList<Consumption> FindConsumptionsousuo(PageCond<Consumptionter> pageCond);



        int Delet(int id);
    }
}
