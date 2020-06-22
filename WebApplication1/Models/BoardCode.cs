using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class BoardCode
    {
        public BoardCode()
        {
            BoardMenu = new HashSet<BoardMenu>();
        }

        [Key]
        public int code_id { get; set; }
        [Required]
        [StringLength(50)]
        public string code_name { get; set; }
        [Required]
        [StringLength(1)]
        public string use_yn { get; set; }
        public int index_order { get; set; }
        [StringLength(50)]
        public string gubun { get; set; }
        [StringLength(100)]
        public string board_auth { get; set; }

        [InverseProperty("BoardType_idxNavigation")]
        public virtual ICollection<BoardMenu> BoardMenu { get; set; }
    }
}
