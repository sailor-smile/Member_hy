using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.enums
{
    public enum EnumDataStatus
    {
        OK = 1,//正常
        DEL = 0,//请选择项目
        EXLST =-1,//已存在
        EXLSS = -2,//余额不足
        EXCC = -3//次数不足
    }
}
