using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class history
    {
        [Key]
        public int idx { get; set; }
        [StringLength(50)]
        public string user_id { get; set; }
        [StringLength(50)]
        public string company_id { get; set; }
        [StringLength(50)]
        public string department_id { get; set; }
        [StringLength(50)]
        public string user_ip { get; set; }
        [StringLength(150)]
        public string pre_page { get; set; }
        [StringLength(250)]
        public string connect_agent { get; set; }
        [StringLength(250)]
        public string connect_host { get; set; }
        [StringLength(250)]
        public string connect_path { get; set; }
        [StringLength(250)]
        public string memo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? connect_date { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string page { get; set; }

        [ForeignKey(nameof(user_id))]
        [InverseProperty(nameof(user.history))]
        public virtual user user_ { get; set; }
    }
}
