using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class Downloader
    {
        [Key]
        public int idx { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(50)]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string tel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
    }
}
