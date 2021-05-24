using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Dto.Users
{
    public class UserVmer
    {
        public string Pwd { get; set; }//用户密码

        public string Newpwd { get; set; }//修改后的密码
        public string UserId { get; set; }//用户ID

        public string UserName { get; set; }//用户名

    }
}
