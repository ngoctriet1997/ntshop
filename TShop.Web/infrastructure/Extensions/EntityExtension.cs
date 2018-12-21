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
        public static void UpdatePostCategory(this Post post, PostViewModel postVm)
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
    }
}