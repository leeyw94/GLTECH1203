using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class CategoryMenus
    {
        [Key]
        public int idx { get; set; }
        [Required]
        [StringLength(50)]
        public string company_id { get; set; }
        [Required]
        [StringLength(50)]
        public string step_name { get; set; }
        [StringLength(50)]
        public string step_url1 { get; set; }
        [StringLength(50)]
        public string step_url2 { get; set; }
        [StringLength(150)]
        public string step_auth { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? step_writedate { get; set; }
        [StringLength(2)]
        public string step_index { get; set; }
        [StringLength(50)]
        public string step_icon { get; set; }
        public int step_dept { get; set; }
        public int step_orderby { get; set; }
    }
}
