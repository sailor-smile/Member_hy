using System.Linq;
using Member_hy.Dto.Users;
using Member_hy.Entitys;

namespace Member_hy.Dao.Users
{
    public class LoginDaolmpl : BaseDaoImpl, ILoginDao
    {
        public LoginDaolmpl(MemberContext dbContext) : base(dbContext)
        {
        }

        //登录
        public IniUser User(UserVmer userVmer)
        {
            var query = from n in _dbContext.IniUser
                        where n.Username == userVmer.UserName && n.Userword == userVmer.Newpwd
                        select n;

            var site = query.FirstOrDefault();

            return site;


        }
    }
}
