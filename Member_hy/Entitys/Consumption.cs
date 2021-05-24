using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Member_hy.Entitys
{
    public partial class Consumption
    {
        public int Consumptioncode { get; set; }
        public string CCardId { get; set; }
        public string ItemId { get; set; }
        public string CItems { get; set; }
        public string Frequency { get; set; }
        public DateTime? CDate { get; set; }
        [NotMapped]
        public string CDatestr { get; set; }
        public decimal? PAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Cda { get; set; }
        public decimal? je { get; set; }
        public int? Consum { get; set; }
        [NotMapped]
        public string CdaStr { get; set; } = "0.00";
        //项目单价向下取整
        [NotMapped]
        public string CdpStr { get; set; } = "0.00";

    }
}
