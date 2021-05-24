using System;
using System.Collections.Generic;

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：分页结果集容器                                                    
*│　作   者：c                                            
*│　版   本：1.0                                                 
*│　创建时间：2018-12-19 14:40:40                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: NurseIndicator.Base.Context                                   
*│　类   名：PageList                                      
*└──────────────────────────────────────────────────────────────┘
*/
namespace Member_hy.Context
{
    public class PageList<T>
    {
        private static int PAGE_SIZE = 20;
        public int TotalRecords { get; set; }
        public List<T> Data { get; set; }
       


        public int TotalPages
        {
            get;
            set;
        }
        public PageList(int totalRecords, List<T> data)
        {
            TotalRecords = totalRecords;
            Data = data;
            TotalPages = (int)Math.Ceiling(TotalRecords / (PAGE_SIZE * 1.0)); 
        }
        public PageList(int totalRecords, int pageSize, List<T> data)
        {
            TotalRecords = totalRecords;
            Data = data;
            TotalPages = (int)Math.Ceiling(TotalRecords / (pageSize * 1.0));
        }
        public PageList() { }
    }
}
