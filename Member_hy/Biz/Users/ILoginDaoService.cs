

using Member_hy.Dto.Users;
using Member_hy.Entitys;

namespace Member_hy.Biz.Users
{
    public interface ILoginDaoService
    {
        //登录
        IniUser User(UserVmer userVmer);
    }
}
