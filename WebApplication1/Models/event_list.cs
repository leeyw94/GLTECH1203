using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class event_list
    {
        public event_list()
        {
            photo = new HashSet<photo>();
        }

        [Key]
        public int idx { get; set; }
        public int f_id { get; set; }
        public int f_count { get; set; }
        [Required]
        [StringLength(100)]
        public string f_name { get; set; }
        public int? f_nation_id { get; set; }
        [StringLength(100)]
        public string f_city { get; set; }
        [Column(TypeName = "ntext")]
        public string memo { get; set; }
        [Column(TypeName = "date")]
        public DateTime r_date { get; set; }
        [StringLength(6)]
        public string use_yn { get; set; }
        public int index_order { get; set; }

        [InverseProperty("M_seasonNavigation")]
        public virtual ICollection<photo> photo { get; set; }
    }
}
