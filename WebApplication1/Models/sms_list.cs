using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class sms_list
    {
        [Key]
        public int idx { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? work_date { get; set; }
        public int? error_type_int { get; set; }
        [StringLength(50)]
        public string shop_id { get; set; }
        [StringLength(250)]
        public string who { get; set; }

        [ForeignKey(nameof(error_type_int))]
        [InverseProperty(nameof(error_type.sms_list))]
        public virtual error_type error_type_intNavigation { get; set; }
        [ForeignKey(nameof(shop_id))]
        [InverseProperty(nameof(machine.sms_list))]
        public virtual machine shop_ { get; set; }
    }
}
