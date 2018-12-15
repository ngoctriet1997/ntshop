using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Model.Models
{
    [Table("SystemConfigs")]
    public class SystemConfigs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string ValueString { get; set; }
        public int? ValueInt { set; get; }
    }
}
