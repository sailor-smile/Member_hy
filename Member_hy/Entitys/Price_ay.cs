using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Entitys
{
    public partial class Price_ay
    {
        public string Pid { get; set; }
        public int Projectname { get; set; }
        public string Projectname_ay { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Pyear { get; set; }
      



    }
}