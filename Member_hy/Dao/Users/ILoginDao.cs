using Member_hy.Dto.Users;
using Member_hy.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Dao.Users
{
    public interface ILoginDao
    {
        //登录
        IniUser User(UserVmer userVmer);

    }
}
