using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Member_hy.Entitys
{
    public partial class Clubercar
    {
        public string CCardId { get; set; }
        public int ClubId { get; set; }
        public string Cardtype { get; set; }
        public string Collectiontype { get; set; }
        public decimal? Cardseller { get; set; }
        public DateTime? CUdeadline { get; set; }
        [NotMapped]
        public string CUdeadlinestr { get; set; }
        public int? State { get; set; }
        public int? Sort { get; set; }
        public decimal? Cda { get; set; }
        public decimal? Xda { get; set; }
        public DateTime? CExpiretime { get; set; }
        [NotMapped]
        public string CExpiretimestr { get; set; }
        public string CFrequency { get; set; }
        public int? Consum { get; set; }

    }
}
