using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class BoardList
    {
        public BoardList()
        {
            BoardComment = new HashSet<BoardComment>();
            BoardRread = new HashSet<BoardRread>();
        }

        [Key]
        public int idx { get; set; }
        public int BM_idx { get; set; }
        [Required]
        [StringLength(250)]
        public string title { get; set; }
        [Column(TypeName = "ntext")]
        public string content { get; set; }
        [StringLength(200)]
        public string writer { get; set; }
        [StringLength(200)]
        public string password { get; set; }
        public int hit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime writeDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? editDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? delDate { get; set; }
        [StringLength(2)]
        public string useable { get; set; }
        [StringLength(50)]
        public string fileId { get; set; }

        [ForeignKey(nameof(BM_idx))]
        [InverseProperty(nameof(BoardMenu.BoardList))]
        public virtual BoardMenu BM_idxNavigation { get; set; }
        [InverseProperty("BD_idxNavigation")]
        public virtual ICollection<BoardComment> BoardComment { get; set; }
        [InverseProperty("board_idxNavigation")]
        public virtual ICollection<BoardRread> BoardRread { get; set; }
    }
}
