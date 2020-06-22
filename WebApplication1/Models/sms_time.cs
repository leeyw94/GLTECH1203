using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class sms_time
    {
        [Key]
        public int idx { get; set; }
        public int sms_time_set { get; set; }
        [StringLength(50)]
        public string shop_id { get; set; }
    }
}
