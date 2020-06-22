using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class Main_data
    {
        [Key]
        public int idx { get; set; }
        [StringLength(15)]
        public string shop_id { get; set; }
        [StringLength(2)]
        public string w_type { get; set; }
        [StringLength(8)]
        public string firm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime in_date { get; set; }
        [StringLength(1)]
        public string rf_state { get; set; }
        [StringLength(2)]
        public string rf_id { get; set; }
        [StringLength(1)]
        public string sensor_type { get; set; }
        [StringLength(1)]
        public string sensor_state { get; set; }
        public int w_level { get; set; }
        [StringLength(1)]
        public string pump_state { get; set; }
        [StringLength(1)]
        public string run_state { get; set; }
        [StringLength(1)]
        public string t_battery { get; set; }
        [StringLength(1)]
        public string r_battery { get; set; }
        [StringLength(1)]
        public string r_power_state { get; set; }
        public int h_level { get; set; }
        public int l_level { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [StringLength(80)]
        public string rowdata { get; set; }
        public int index_order { get; set; }
        [StringLength(1)]
        public string check_use { get; set; }
    }
}
