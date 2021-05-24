using Member_hy.Context;
using Member_hy.Dao.MemberM;
using Member_hy.Dto;
using Member_hy.Entitys;

namespace Member_hy.Biz.MemberM
{

    public class CluberDaoServicelmpl : ICluberDaoService
    {
        private readonly ICluberDao _cluberDao;
        public CluberDaoServicelmpl(ICluberDao cluberDao)
        {
            _cluberDao = cluberDao;

        }

        public Cluber Cber(int id)
        {
            return _cluberDao.Cber(id);
        }

        public int Delet(int id)
        {
          return  _cluberDao.Delet(id);
        }

        public PageList<Cluber> FindVmcoes(PageCond<Vmparameter> pageCond)
        {
            return _cluberDao.FindVmcoes(pageCond);
        }

        public PageList<Cluber> FindVmcoessousuo(PageCond<Vmparameter> pageCond)
        {
            return _cluberDao.FindVmcoessousuo(pageCond);
        }

        public int Save(Cluber cluber)
        {
            return _cluberDao.Save(cluber);
        }

        public int Update(Cluber cube)
        {
            return _cluberDao.Update(cube);
        }
    }
}
