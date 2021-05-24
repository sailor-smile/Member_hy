

using Member_hy.Biz.Users;
using Member_hy.Dao.Users;
using Member_hy.Dto.Users;
using Member_hy.Entitys;

namespace Member_hy.Biz.Users
{
    
    public class LoginDaoServiceImpl : ILoginDaoService
    {

        private readonly ILoginDao _loginDao;
        public LoginDaoServiceImpl(ILoginDao loginDao) {
            _loginDao = loginDao;

        }

        public IniUser User(UserVmer userVmer)
        {
            return _loginDao.User(userVmer);

           
        }

      
    }
}
