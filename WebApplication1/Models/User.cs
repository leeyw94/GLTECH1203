using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class user
    {
        public user()
        {
            BoardRread = new HashSet<BoardRread>();
            history = new HashSet<history>();
            machine = new HashSet<machine>();
        }

        [Key]
        [StringLength(50)]
        public string user_id { get; set; }
        [StringLength(50)]
        public string user_password { get; set; }
        public int idx { get; set; }
        [Required]
        [StringLength(50)]
        public string company_id { get; set; }
        public int company_idx { get; set; }
        public int department_idx { get; set; }
        [Required]
        [StringLength(50)]
        public string user_name { get; set; }
        [StringLength(150)]
        public string user_auth { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        public int check_auth { get; set; }
        [StringLength(50)]
        public string user_tel { get; set; }
        [StringLength(50)]
        public string writer { get; set; }
        [StringLength(150)]
        public string user_email { get; set; }
        [StringLength(10)]
        public string main_bg_color { get; set; }
        [StringLength(150)]
        public string photo_profile { get; set; }
        public int? alert_yn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime edit_date { get; set; }
        [StringLength(1)]
        public string manager_yn { get; set; }
        public int position_idx { get; set; }
        [StringLength(20)]
        public string language { get; set; }
        public int user_class_idx { get; set; }

        [ForeignKey(nameof(company_idx))]
        [InverseProperty(nameof(company.user))]
        public virtual company company_idxNavigation { get; set; }
        [ForeignKey(nameof(department_idx))]
        [InverseProperty(nameof(department.user))]
        public virtual department department_idxNavigation { get; set; }
        [InverseProperty("user_")]
        public virtual ICollection<BoardRread> BoardRread { get; set; }
        [InverseProperty("user_")]
        public virtual ICollection<history> history { get; set; }
        [InverseProperty("writer_")]
        public virtual ICollection<machine> machine { get; set; }
    }
}
