
using System;
/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：页面JSON结果集                                                    
*│　作   者：                                            
*│　版   本：1.0                                                 
*│　                          
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间:                                
*│　类   名：JsonCallRes                                      
*└──────────────────────────────────────────────────────────────┘
*/
namespace Member_hy.Context
{
    public  class JsonCallRes
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
      
        public JsonCallRes(int code, object data)
        {
            this.Code = code;
            this.Data = data;
        }
        public JsonCallRes(int code, string msg, object data)
        {
            this.Code = code;
            this.Msg = msg;
            this.Data = data;
        }
        public JsonCallRes(int code)
        {
            this.Code = code;
        }
        public JsonCallRes() { }
    }
}
