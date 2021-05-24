using Member_hy.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Dao
{
    public abstract class BaseDaoImpl
    {
        protected MemberContext _dbContext;
        /// <summary>
        /// 注入数据上下文对象
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseDaoImpl(MemberContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseDaoImpl()
        {
            _dbContext = new MemberContext();
        }

    }
}
