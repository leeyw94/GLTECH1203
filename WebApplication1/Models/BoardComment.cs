using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class BoardComment
    {
        [Key]
        public int idx { get; set; }
        public int BD_idx { get; set; }
        public int step { get; set; }
        [Column(TypeName = "ntext")]
        public string memo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        [StringLength(50)]
        public string writer { get; set; }
        [StringLength(50)]
        public string user_ip { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime edit_date { get; set; }

        [ForeignKey(nameof(BD_idx))]
        [InverseProperty(nameof(BoardList.BoardComment))]
        public virtual BoardList BD_idxNavigation { get; set; }
    }
}
