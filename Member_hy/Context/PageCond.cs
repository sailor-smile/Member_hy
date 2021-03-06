/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：分页条件参数                                                    
*│　作   者：c
*│　版   本：1.0                                                 
*│　创建时间：2018-12-19 14:47:43                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: NurseIndicator.Base.Context                                   
*│　类   名：PageCond                                      
*└──────────────────────────────────────────────────────────────┘
*/
namespace Member_hy.Context
{
    public class PageCond<T>
    {
        public int PageNo { get; set; }//页码
        public int PageSize { get; set; }//每页条数
        public T Cond { get; set; }//查询条件参数



    }
}
