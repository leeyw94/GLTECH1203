using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class work_list
    {
        [Key]
        public int idx { get; set; }
        [Required]
        [StringLength(50)]
        public string company_id { get; set; }
        [Required]
        [StringLength(50)]
        public string department_id { get; set; }
        [StringLength(50)]
        public string user_id { get; set; }
        public double gubun_code { get; set; }
        public string title { get; set; }
        [StringLength(50)]
        public string gubun_type { get; set; }
        [StringLength(100)]
        public string use_yn { get; set; }
        [StringLength(100)]
        public string who { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? write_date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? edit_date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime work_date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime end_date { get; set; }
        public int state { get; set; }
        [Column(TypeName = "ntext")]
        public string content { get; set; }
        public int project_idx { get; set; }
        [StringLength(2)]
        public string open_it { get; set; }
        [StringLength(300)]
        public string who_list { get; set; }
        public int? index { get; set; }

        [ForeignKey(nameof(index))]
        [InverseProperty(nameof(code_index.work_list))]
        public virtual code_index indexNavigation { get; set; }
        [ForeignKey(nameof(state))]
        [InverseProperty(nameof(code_project_state.work_list))]
        public virtual code_project_state stateNavigation { get; set; }
    }
}
