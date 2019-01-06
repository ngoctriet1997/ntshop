using NShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TShop.Web.infrastructure.Core;
using TShop.Web.Models;

namespace TShop.Web.infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static void UpdatePostCategory(this PostCategory postCategory,PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Description = postCategoryVm.Description;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdateDate = postCategoryVm.UpdateDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;
        }
        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.Description = postVm.Description;
            post.CategoryID = postVm.CategoryID;
            post.Image = postVm.Image;
            post.Content = postVm.Content;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;


           post.CreatedDate = postVm.CreatedDate;
           post.CreatedBy = postVm.CreatedBy;
           post.UpdateDate = postVm.UpdateDate;
           post.UpdatedBy = postVm.UpdatedBy;
           post.MetaKeyword = postVm.MetaKeyword;
           post.MetaDescription = postVm.MetaDescription;
           post.Status = postVm.Status;
        }
        public static void UpdateProduct(this Product product, ProductViewModel productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Alias = productVm.Alias;
            product.Description = productVm.Description;
            product.CategoryID = productVm.CategoryID;
            product.Image = productVm.Image;
            product.Content = productVm.Content;
            product.HomeFlag = productVm.HomeFlag;
            product.ViewCount = productVm.ViewCount;
            product.MoreImages = productVm.MoreImages;
            product.Price = productVm.Price;
            product.Promotion = productVm.Promotion;
            product.Warrantly = productVm.Warrantly;

            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdateDate = productVm.UpdateDate;
            product.UpdatedBy = productVm.UpdatedBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;
            product.Tags = productVm.Tags;
        }
        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;
            productCategory.Name = productCategoryVm.Name;
            productCategory.Alias = productCategoryVm.Alias;
            productCategory.Description = productCategoryVm.Description;
            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.Image = productCategoryVm.Image;
            productCategory.Parent = productCategoryVm.Parent;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;

            productCategory.CreatedDate = productCategoryVm.CreatedDate;
            productCategory.CreatedBy = productCategoryVm.CreatedBy;
            productCategory.UpdateDate = productCategoryVm.UpdateDate;
            productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            productCategory.MetaKeyword = productCategoryVm.MetaKeyword;
            productCategory.MetaDescription = productCategoryVm.MetaDescription;
            productCategory.Status = productCategoryVm.Status;
        }
    }
}