using Member_hy.Context;
using Member_hy.Dto;
using Member_hy.Dto.Consumption;
using Member_hy.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Dao.ConsumptionView
{
    public interface IConsumptionViewDao
    {

        PageList<Consumption> FindConsumption(PageCond<Vmparameter> pageCond);

        PageList<Consumption> FindConsumptionsousuo(PageCond<Consumptionter> pageCond);

        Consumption FindConsumptions(int liushuicode);


        int Delet(int id);

    }
}
