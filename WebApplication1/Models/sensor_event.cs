using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class sensor_event
    {
        public sensor_event()
        {
            sensor_event_log = new HashSet<sensor_event_log>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [InverseProperty("event_")]
        public virtual ICollection<sensor_event_log> sensor_event_log { get; set; }
    }
}
