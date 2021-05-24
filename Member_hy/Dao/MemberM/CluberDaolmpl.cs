using System.Data.SqlClient;
using System.Linq;
using Member_hy.Context;
using Member_hy.Dto;
using Member_hy.Entitys;
using Member_hy.enums;
using Microsoft.EntityFrameworkCore;

namespace Member_hy.Dao.MemberM
{
    public class CluberDaolmpl:BaseDaoImpl, ICluberDao
    {
        public CluberDaolmpl(MemberContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cluber Cber(int id)
        {
            var query = from n in _dbContext.Cluber
                        where n.ClubId == id
                        select n;
            var data = query.FirstOrDefault();
         
            return data;

        }

        public int Delet(int id)
        {

            SqlParameter[] sqlParameters = new[] {
                new SqlParameter("@id",id)
        };
            _dbContext.Database.ExecuteSqlCommand("delete from cluber where clubId = @id", sqlParameters);
            return (int)EnumDataStatus.OK;

        }

        //分页查询
        public PageList<Cluber> FindVmcoes(PageCond<Vmparameter> pageCond)
        {
            var query = from n in _dbContext.Cluber
                        where 1==1
                        orderby n.ClubId descending
                        select n;
            var count = query.Count();
            var data = query.Skip((pageCond.PageNo - 1) * pageCond.PageSize).Take(pageCond.PageSize).ToList();
            //var datas = query.ToList();
            foreach (var o in data)
            {
                if (o.CBirthday != null)
                {
                    o.CBirthdaystr = o.CBirthday.Value.ToString("d");
                }
            }


            PageList<Cluber> PageResult = new PageList<Cluber>(count, pageCond.PageSize, data);
            return PageResult;

        }


        //搜索
        public PageList<Cluber> FindVmcoessousuo(PageCond<Vmparameter> pageCond)
        {
            if (pageCond.Cond != null) {
                var query = from n in _dbContext.Cluber
                            where pageCond.Cond.mobile == n.CMobile
                            select n;
                var count = query.Count();
                var data = query.Skip((pageCond.PageNo - 1) * pageCond.PageSize).Take(pageCond.PageSize).ToList();


                PageList<Cluber> PageResult = new PageList<Cluber>(count, pageCond.PageSize, data);
                return PageResult;

            }
            return null;
        }


        public int Save(Cluber cluber)
        {
            _dbContext.Cluber.AddRange(cluber);
            _dbContext.SaveChanges();
            return (int)EnumDataStatus.OK;
        }

        public int Update(Cluber cube)
        {
            Cluber c = new Cluber();
            c.ClubId = cube.ClubId;
            c.Clubname = cube.Clubname;
            c.CMobile = cube.CMobile;
            c.CRemarks = cube.CRemarks;
            c.CSex = cube.CSex;
            c.CBirthday = cube.CBirthday;

            _dbContext.Attach(c);

            _dbContext.Entry(c).Property(po => po.Clubname).IsModified = true;
            _dbContext.Entry(c).Property(po => po.CMobile).IsModified = true;
            _dbContext.Entry(c).Property(po => po.CRemarks).IsModified = true;
            _dbContext.Entry(c).Property(po => po.CSex).IsModified = true;
            _dbContext.Entry(c).Property(po => po.CBirthday).IsModified = true;

            _dbContext.SaveChanges();
            return (int)EnumDataStatus.OK;
        }
    }
}
