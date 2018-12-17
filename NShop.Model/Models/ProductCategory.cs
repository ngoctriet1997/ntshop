using NShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int? Parent { get; set; }
        public int? DisplayOrder { get; set; }
        [MaxLength(256)]
        public string Image { get; set; }
        public bool? HomeFlag { set; get; }
        public virtual IEnumerable<Product> Products { get; set; }

       

    }
}
