using Member_hy.Dto;
using Member_hy.Dto.IdCard;
using Member_hy.Entitys;
using System.Collections.Generic;

namespace Member_hy.Dao.IdCard
{
    public  interface IdCardDao
    {
        //查询会员卡信息
        List<Clubercars> FindClubercars(Vmparameter pageCond);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="vmcoes"></param>
        int SaveIdcard(SaveAll sall);


        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Clubercars Cber(string id);



        /// <summary>
        /// 修改卡信息(不能修改金额)
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        int Update(Clubercar cube);

        /// <summary>
        /// 订阅项目时扣费功能
        /// </summary>
        /// <param name="cube"></param>
        /// <returns></returns>
        int Updateqian(Clubercar cube);

        /// <summary>
        /// 自动生成流水功能
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        int SaveConsum(Consumption consumption);

        //删除
        int Delet(string id);


        //卡号重复验证





    }
}
