using System.Collections.Generic;
using Member_hy.Dto;
using Member_hy.Dto.IdCard;
using Member_hy.Entitys;

namespace Member_hy.Dao.IdCard
{
    public class IdCardDaoServiceImpl : IdCardDaoService
    {
        private readonly IdCardDao _idCardDao;

        public IdCardDaoServiceImpl(IdCardDao idCardDao) {
            _idCardDao = idCardDao;
        }

        public Clubercars Cber(string id)
        {
            return _idCardDao.Cber(id);
        }

        public int Delet(string id)
        {
            return _idCardDao.Delet(id);
        }

        public List<Clubercars> FindClubercars(Vmparameter pageCond)
        {
           return _idCardDao.FindClubercars(pageCond);
        }

        public int SaveConsum(Consumption consumption)
        {
            return _idCardDao.SaveConsum(consumption);
        }

        public int SaveIdcard(SaveAll sall)
        {
            return _idCardDao.SaveIdcard(sall);
        }

        public int Update(Clubercar cube)
        {
            return _idCardDao.Update(cube);
        }

        public int Updateqian(Clubercar cube)
        {
            return _idCardDao.Updateqian(cube);
        }
    }
}
