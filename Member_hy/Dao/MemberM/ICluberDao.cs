using Member_hy.Context;
using Member_hy.Dto;
using Member_hy.Entitys;

namespace Member_hy.Dao.MemberM
{
    public interface ICluberDao
    {
        //分页查询
        PageList<Cluber> FindVmcoes(PageCond<Vmparameter> pageCond);

        //搜索
        PageList<Cluber> FindVmcoessousuo(PageCond<Vmparameter> pageCond);



        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="vmcoes"></param>
        int Save(Cluber cluber);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="vmcoesGd"></param>
        /// <returns></returns>
        int Delet(int id);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Cluber Cber(int id);



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        int Update(Cluber cube);

    }
}
