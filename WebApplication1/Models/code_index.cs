using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class code_index
    {
        public code_index()
        {
            work_list = new HashSet<work_list>();
        }

        [Key]
        public int code_id { get; set; }
        [Required]
        [StringLength(350)]
        public string code_name { get; set; }
        [Required]
        [StringLength(1)]
        public string use_yn { get; set; }
        public int index_order { get; set; }
        [StringLength(10)]
        public string gubun { get; set; }

        [InverseProperty("indexNavigation")]
        public virtual ICollection<work_list> work_list { get; set; }
    }
}
