using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class code_machine
    {
        public code_machine()
        {
            machine = new HashSet<machine>();
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
        [StringLength(1)]
        public string gubun { get; set; }

        [InverseProperty("code_machine_idxNavigation")]
        public virtual ICollection<machine> machine { get; set; }
    }
}
