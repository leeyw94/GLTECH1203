using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class project_main
    {
        [Key]
        public int project_id { get; set; }
        [StringLength(50)]
        public string project_code { get; set; }
        [Required]
        [StringLength(50)]
        public string company_id { get; set; }
        [Required]
        [StringLength(50)]
        public string project_name { get; set; }
        [Column(TypeName = "date")]
        public DateTime? start_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }
        public int state { get; set; }
        [StringLength(350)]
        public string memo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [StringLength(50)]
        public string writer { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        [StringLength(50)]
        public string department_id { get; set; }
        public int index_order { get; set; }
    }
}
