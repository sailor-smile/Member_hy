using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Member_hy.Entitys
{
    public partial class Cluber
    {
        
        public int ClubId { get; set; }
        public string CType { get; set; }
        public string Clubname { get; set; }
        public string CSex { get; set; }
        public string CMobile { get; set; }
        public DateTime? CBirthday { get; set; }

        [NotMapped]
        public string CBirthdaystr { get; set; }
        public string CRemarks { get; set; }
        public int CSort { get; set; }
    }
}
