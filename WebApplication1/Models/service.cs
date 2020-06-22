using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLtech.Models
{
    public partial class service
    {
        [Key]
        public int idx { get; set; }
        [StringLength(50)]
        public string service_sp { get; set; }
        [Column(TypeName = "date")]
        public DateTime? out_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? finish_date { get; set; }
        [StringLength(150)]
        public string product_name { get; set; }
        public int? quantity { get; set; }
        [StringLength(250)]
        public string main_memo { get; set; }
        public int? production_code { get; set; }
        [Column(TypeName = "date")]
        public DateTime? work_start_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? work_end_date { get; set; }
        [StringLength(50)]
        public string machine_id { get; set; }
        public int? powder_id { get; set; }
        [StringLength(50)]
        public string powder_use { get; set; }
        [StringLength(50)]
        public string lotno { get; set; }
        [StringLength(100)]
        public string gipan { get; set; }
        public double cad_time { get; set; }
        public double cam_time { get; set; }
        public double setting_time { get; set; }
        public double work_time { get; set; }
        [StringLength(250)]
        public string work_memo { get; set; }
        public int? process_mode { get; set; }
        public int? laser_output { get; set; }
        public double? powder_quantity { get; set; }
        public double? gas_coaxial { get; set; }
        public double? gas_shield { get; set; }
        [StringLength(250)]
        public string photo_1 { get; set; }
        [StringLength(250)]
        public string photo_2 { get; set; }
        [StringLength(250)]
        public string photo_3 { get; set; }
        [StringLength(250)]
        public string photo_4 { get; set; }
        [StringLength(250)]
        public string process_memo { get; set; }
        [StringLength(50)]
        public string result_yn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime write_date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime edit_date { get; set; }
        [StringLength(50)]
        public string writer { get; set; }
        [StringLength(100)]
        public string file_sn { get; set; }
        [StringLength(50)]
        public string guest_id { get; set; }
        public double? gas_powder { get; set; }
        public int? sojae_id { get; set; }

        [ForeignKey(nameof(production_code))]
        [InverseProperty(nameof(code_production.service))]
        public virtual code_production production_codeNavigation { get; set; }
    }
}
