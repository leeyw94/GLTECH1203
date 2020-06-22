using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class Inquiry
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
        public string company { get; set; }
        [Required]
        [StringLength(50)]
        public string department { get; set; }
        [Required]
        [StringLength(50)]
        public string tel { get; set; }
        [Required]
        public string contents { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime writeDate { get; set; }
    }
}
