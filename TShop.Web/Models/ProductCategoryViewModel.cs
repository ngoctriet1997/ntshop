﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }
        public int? Parent { get; set; }
        public int? DisplayOrder { get; set; }

        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
        public virtual IEnumerable<PostViewModel> Posts { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string UpdatedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}