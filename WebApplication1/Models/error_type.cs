using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class error_type
    {
        public error_type()
        {
            alert_error = new HashSet<alert_error>();
            sms_list = new HashSet<sms_list>();
        }

        [Key]
        public int code_id { get; set; }
        [StringLength(50)]
        public string code_name { get; set; }

        [InverseProperty("error_type_intNavigation")]
        public virtual ICollection<alert_error> alert_error { get; set; }
        [InverseProperty("error_type_intNavigation")]
        public virtual ICollection<sms_list> sms_list { get; set; }
    }
}
