using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class sensor_event_log
    {
        [Key]
        public int id { get; set; }
        public int event_id { get; set; }
        [Required]
        [StringLength(50)]
        public string machine_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime occ_time { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? check_time { get; set; }
        public bool check { get; set; }
        public int? sensor_data_id { get; set; }

        [ForeignKey(nameof(event_id))]
        [InverseProperty(nameof(sensor_event.sensor_event_log))]
        public virtual sensor_event event_ { get; set; }
        [ForeignKey(nameof(machine_id))]
        [InverseProperty(nameof(machine.sensor_event_log))]
        public virtual machine machine_ { get; set; }
    }
}
