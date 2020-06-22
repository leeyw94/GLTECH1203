using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class company
    {
        public company()
        {
            BoardMenu = new HashSet<BoardMenu>();
            department = new HashSet<department>();
            machine = new HashSet<machine>();
            user = new HashSet<user>();
        }

        [Key]
        public int idx { get; set; }
        [Required]
        [StringLength(50)]
        public string company_id { get; set; }
        [Required]
        [StringLength(150)]
        public string company_name { get; set; }
        [Required]
        [StringLength(50)]
        public string nationality { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        public int index_order { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        public int code_company_idx { get; set; }

        [ForeignKey(nameof(code_company_idx))]
        [InverseProperty(nameof(code_company.company))]
        public virtual code_company code_company_idxNavigation { get; set; }
        [InverseProperty("company_idxNavigation")]
        public virtual ICollection<BoardMenu> BoardMenu { get; set; }
        [InverseProperty("company_idxNavigation")]
        public virtual ICollection<department> department { get; set; }
        [InverseProperty("company_idxNavigation")]
        public virtual ICollection<machine> machine { get; set; }
        [InverseProperty("company_idxNavigation")]
        public virtual ICollection<user> user { get; set; }
    }
}
