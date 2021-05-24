using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Entitys
{


    /// <summary>
    /// 
    /// </summary>
    public class Clubercars
    {
        public string CCardId { get; set; }
        public int ClubId { get; set; }
        public string Cardtype { get; set; }
        public string Collectiontype { get; set; }
        public decimal? Cardseller { get; set; }
        public DateTime? CUdeadline { get; set; }
      
        public string CUdeadlinestr { get; set; }
        public int? State { get; set; }
        public int? Sort { get; set; }
        public decimal? Cda { get; set; }
        public decimal? Xda { get; set; }
        public DateTime? CExpiretime { get; set; }
        
        public string CExpiretimestr { get; set; }
        public string CFrequency { get; set; }

        public decimal? PAmount { get; set; }


        [NotMapped]
        public string Cdatring { get; set; }




    }
}
