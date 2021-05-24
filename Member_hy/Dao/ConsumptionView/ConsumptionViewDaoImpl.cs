using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Member_hy.Context;
using Member_hy.Dto;
using Member_hy.Dto.Consumption;
using Member_hy.Entitys;
using Member_hy.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Member_hy.Dao.ConsumptionView
{
    public class ConsumptionViewDaoImpl : BaseDaoImpl, IConsumptionViewDao
    {
        public ConsumptionViewDaoImpl(MemberContext dbContext) : base(dbContext)
        {
        }



        public int Delet(int id)
        {
            SqlParameter[] sqlParameters = new[] {
                new SqlParameter("@id",id)
        };
            _dbContext.Database.ExecuteSqlCommand("delete from consumption where consumptioncode = @id", sqlParameters);
            return (int)EnumDataStatus.OK;

        }
        /// <summary>
        /// 根据时间搜索
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        public PageList<Consumption> FindConsumptionsousuo(PageCond<Consumptionter> pageCond)
        {
            if (pageCond.Cond.statime != null)
            {
                string bq = pageCond.Cond.statime.ToString("d");
                string s = "00:00:00";
                string e = "23:59:59";
                string state = bq + " " + s;
                string end = bq + " " + e;
                var statetime = Convert.ToDateTime(state);
                var endtime = Convert.ToDateTime(end);

                var query = from n in _dbContext.Consumption
                            where n.CDate >= statetime && n.CDate <= endtime
                            orderby n.CDate descending
                            select n;
                var count = query.Count();
                var data = query.Skip((pageCond.PageNo - 1) * pageCond.PageSize).Take(pageCond.PageSize).ToList();
                foreach (var o in data)
                {
                    if (o.CDate != null)
                    {
                        o.CDatestr = o.CDate.Value.ToString("d") + ' ' + o.CDate.Value.ToString("t");
                        o.CdaStr = Math.Ceiling(o.Cda.Value).ToString();
                        o.CdpStr = Math.Floor(o.PAmount.Value * o.Discount.Value * o.Consum.Value).ToString();
                    }


                }

                PageList<Consumption> PageResult = new PageList<Consumption>(count, pageCond.PageSize, data);
                return PageResult;



            }

            return null;


        }
        //分页查询
        public PageList<Consumption> FindConsumption(PageCond<Vmparameter> pageCond)
        {
            var query = from n in _dbContext.Consumption
                        where pageCond.Cond.idcard ==n.CCardId
                        orderby n.CDate descending
                        select n;
            //select new Consumption
            //{
            //    CdaStr = Math.Ceiling(n.Cda.Value).ToString()
            //};

            var count = query.Count();
            var data = query.Skip((pageCond.PageNo - 1) * pageCond.PageSize).Take(pageCond.PageSize).ToList();
            foreach (var o in data) {
                o.Consum = o.Consum == null || o.Consum.Value <= 0 ? 1 : o.Consum.Value;
                if (o.CDate !=null&& o.Cda != null&&o.PAmount != null)
                {
                    
                    o.CDatestr = o.CDate.Value.ToString("d") + ' ' + o.CDate.Value.ToString("t");
                    o.CdaStr = Math.Ceiling(o.Cda.Value).ToString();
                    var disc = o.Discount == null || o.Discount.Value <= 0 ? 1 : o.Discount.Value;
                    var pm = o.Consum == null || o.Discount.Value <= 0 ? 1 : o.Consum.Value;
                    o.CdpStr = Math.Floor(o.PAmount.Value * disc * pm).ToString();
                }


            }

            PageList<Consumption> PageResult = new PageList<Consumption>(count, pageCond.PageSize, data);
            return PageResult;

        }
        /// <summary>
        /// 根据流水号查询
        /// </summary>
        /// <param name="pageCond"></param>
        /// <returns></returns>
        public Consumption FindConsumptions(int liushuicode)
        {

            var query = from n in _dbContext.Consumption
                        where liushuicode == n.Consumptioncode
                        orderby n.CDate descending
                        select n;
            var count = query.Count();
            var data = query.FirstOrDefault();
            if (data.CDate != null)
            {
                data.CDatestr = data.CDate.Value.ToString("d") + ' ' + data.CDate.Value.ToString("t");
            }
            Consumption PageResult = data;
            return PageResult;
        }

   
    }
}
