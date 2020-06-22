using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class machine
    {
        public machine()
        {
            sensor_event_log = new HashSet<sensor_event_log>();
            sms_list = new HashSet<sms_list>();
        }

        [Required]
        [StringLength(50)]
        public string company_id { get; set; }
        public int idx { get; set; }
        [Key]
        [StringLength(50)]
        public string machine_id { get; set; }
        public int company_idx { get; set; }
        public int code_machine_idx { get; set; }
        [StringLength(150)]
        public string machine_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [Required]
        [StringLength(50)]
        public string writer_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime edit_date { get; set; }
        [StringLength(1)]
        public string use_yn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? in_date { get; set; }
        [StringLength(1)]
        public string rf_state { get; set; }
        [StringLength(2)]
        public string rf_id { get; set; }
        [StringLength(1)]
        public string sensor_type { get; set; }
        [StringLength(1)]
        public string sensor_state { get; set; }
        public int? w_level { get; set; }
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
        public int? h_level { get; set; }
        public int? l_level { get; set; }
        public int? index_order { get; set; }
        [StringLength(1)]
        public string check_use { get; set; }
        [StringLength(100)]
        public string addr { get; set; }
        [StringLength(50)]
        public string x_position { get; set; }
        [StringLength(50)]
        public string y_position { get; set; }
        [StringLength(100)]
        public string file_sn { get; set; }
        public double pump_hour { get; set; }

        [ForeignKey(nameof(code_machine_idx))]
        [InverseProperty(nameof(code_machine.machine))]
        public virtual code_machine code_machine_idxNavigation { get; set; }
        [ForeignKey(nameof(company_idx))]
        [InverseProperty(nameof(company.machine))]
        public virtual company company_idxNavigation { get; set; }
        [ForeignKey(nameof(writer_id))]
        [InverseProperty(nameof(user.machine))]
        public virtual user writer_ { get; set; }
        [InverseProperty("machine_")]
        public virtual ICollection<sensor_event_log> sensor_event_log { get; set; }
        [InverseProperty("shop_")]
        public virtual ICollection<sms_list> sms_list { get; set; }
    }
}
