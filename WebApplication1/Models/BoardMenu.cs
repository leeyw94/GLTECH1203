using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class BoardMenu
    {
        public BoardMenu()
        {
            BoardList = new HashSet<BoardList>();
        }

        [Key]
        public int idx { get; set; }
        [Required]
        [StringLength(50)]
        public string title { get; set; }
        public int company_idx { get; set; }
        public int department_idx { get; set; }
        [StringLength(150)]
        public string url { get; set; }
        public int BoardType_idx { get; set; }
        [StringLength(2)]
        public string open_yn { get; set; }
        public int index_order { get; set; }

        [ForeignKey(nameof(BoardType_idx))]
        [InverseProperty(nameof(BoardCode.BoardMenu))]
        public virtual BoardCode BoardType_idxNavigation { get; set; }
        [ForeignKey(nameof(company_idx))]
        [InverseProperty(nameof(company.BoardMenu))]
        public virtual company company_idxNavigation { get; set; }
        [ForeignKey(nameof(department_idx))]
        [InverseProperty(nameof(department.BoardMenu))]
        public virtual department department_idxNavigation { get; set; }
        [InverseProperty("BM_idxNavigation")]
        public virtual ICollection<BoardList> BoardList { get; set; }
    }
}
