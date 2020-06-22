using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class sensor_data
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string machine_id { get; set; }
        public int sensor_id { get; set; }
        public double value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime time { get; set; }

        [ForeignKey(nameof(machine_id))]
        [InverseProperty(nameof(sensor_set.sensor_data))]
        public virtual sensor_set machine_ { get; set; }
    }
}
