using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class alert_member
    {
        [Key]
        public int idx { get; set; }
        [StringLength(50)]
        public string user_name { get; set; }
        [StringLength(50)]
        public string user_hp { get; set; }
        [Column(TypeName = "ntext")]
        public string memo { get; set; }
        [StringLength(50)]
        public string alert_type { get; set; }
        [StringLength(1)]
        public string alert_night { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        [StringLength(150)]
        public string use_id { get; set; }
    }
}
