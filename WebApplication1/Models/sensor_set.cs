using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class sensor_set
    {
        public sensor_set()
        {
            sensor_data = new HashSet<sensor_data>();
        }

        [Key]
        [StringLength(50)]
        public string machine_id { get; set; }
        public double? temp_high { get; set; }
        public double? humi_high { get; set; }
        public TimeSpan? alarm_min { get; set; }
        public TimeSpan? alarm_max { get; set; }
        [StringLength(150)]
        public string cam_pts { get; set; }
        [StringLength(20)]
        public string cam_host { get; set; }
        public int? cam_port { get; set; }

        [InverseProperty("machine_")]
        public virtual ICollection<sensor_data> sensor_data { get; set; }
    }
}
