using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class Md_Image
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Md_id { get; set; }
        [Required]
        [StringLength(500)]
        public string ImagePath { get; set; }
        public int? Num { get; set; }
        public int? Image_Cate { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? r_date { get; set; }
        [StringLength(50)]
        public string write_id { get; set; }
        public int index_order { get; set; }
        [StringLength(500)]
        public string sImagePath { get; set; }
        public double? file_size { get; set; }
        [StringLength(10)]
        public string file_ex { get; set; }
        [StringLength(100)]
        public string fileName { get; set; }
    }
}
