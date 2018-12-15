using NShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NShop.Model.Models
{
    [Table("Products")]
    public class Product:  Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }
   
        [Required]
        public int CategoryID { get; set; }
        public string Image { get; set; }

        public XElement MoreImages { get; set; }

        public decimal Price { get; set; }
        public decimal? Promotion { get; set; }
        public int? Warrantly { set; get; }
        [MaxLength(500)]
        public string Description { set; get; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }


    }
}
