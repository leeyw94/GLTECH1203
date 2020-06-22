using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class department
    {
        public department()
        {
            BoardMenu = new HashSet<BoardMenu>();
            user = new HashSet<user>();
        }

        [Key]
        public int idx { get; set; }
        [Required]
        [StringLength(150)]
        public string department_name { get; set; }
        [StringLength(150)]
        public string department_auth { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [Required]
        [StringLength(3)]
        public string use_yn { get; set; }
        public int index_order { get; set; }
        public int company_idx { get; set; }

        [ForeignKey(nameof(company_idx))]
        [InverseProperty(nameof(company.department))]
        public virtual company company_idxNavigation { get; set; }
        [InverseProperty("department_idxNavigation")]
        public virtual ICollection<BoardMenu> BoardMenu { get; set; }
        [InverseProperty("department_idxNavigation")]
        public virtual ICollection<user> user { get; set; }
    }
}
