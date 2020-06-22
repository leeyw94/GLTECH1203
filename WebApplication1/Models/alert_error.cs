using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class alert_error
    {
        [Key]
        public int idx { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime work_date { get; set; }
        public int error_type_int { get; set; }
        [StringLength(50)]
        public string error_memo { get; set; }
        [StringLength(150)]
        public string send_state_memo { get; set; }
        [StringLength(50)]
        public string send_state { get; set; }
        [StringLength(50)]
        public string shop_id { get; set; }

        [ForeignKey(nameof(error_type_int))]
        [InverseProperty(nameof(error_type.alert_error))]
        public virtual error_type error_type_intNavigation { get; set; }
    }
}
