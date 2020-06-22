using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class photo
    {
        [Key]
        public int id { get; set; }
        public int M_Category { get; set; }
        public int? M_season { get; set; }
        public int? code_contry_id { get; set; }
        public int? code_city_id { get; set; }
        [Required]
        [StringLength(500)]
        public string ImagePath { get; set; }
        public int? Num { get; set; }
        public int? Image_Cate { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime r_date { get; set; }
        [StringLength(50)]
        public string write_id { get; set; }
        public int index_order { get; set; }
        [StringLength(500)]
        public string sImagePath { get; set; }
        [StringLength(100)]
        public string title { get; set; }
        [StringLength(200)]
        public string M_keyword { get; set; }
        [StringLength(200)]
        public string M_gubun { get; set; }
        [StringLength(100)]
        public string title_en { get; set; }
        public int hit { get; set; }
        public int like_it { get; set; }

        [ForeignKey(nameof(M_season))]
        [InverseProperty(nameof(event_list.photo))]
        public virtual event_list M_seasonNavigation { get; set; }
    }
}
