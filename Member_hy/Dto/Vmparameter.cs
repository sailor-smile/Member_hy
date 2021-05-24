
using System.Collections.Generic;

namespace Member_hy.Dto
{
    /// <summary>
    /// 查询条件类
    /// </summary>
    public class Vmparameter
    {
        public string clubname { get; set; }//会员名称
        public string mobile { get; set; }//会员电话
        public int liushuicode { get; set; }//流水号

        public string idcard { get; set; }//卡号

        public string fhidcard { get; set; }//卡号

        public int? dataId { get; set; }//会员号


        public List<string> idcards { get; set; }//卡号shuzu 



    }
}
