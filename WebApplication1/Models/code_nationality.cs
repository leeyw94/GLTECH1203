using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class code_nationality
    {
        [Key]
        [StringLength(50)]
        public string code_id { get; set; }
        [Required]
        [StringLength(50)]
        public string code_name { get; set; }
        [Required]
        [StringLength(1)]
        public string use_yn { get; set; }
        public int index_order { get; set; }
        [StringLength(1)]
        public string gubun { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [StringLength(50)]
        public string writer_id { get; set; }
    }
}
