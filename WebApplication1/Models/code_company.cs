using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class code_company
    {
        public code_company()
        {
            company = new HashSet<company>();
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

        [InverseProperty("code_company_idxNavigation")]
        public virtual ICollection<company> company { get; set; }
    }
}
