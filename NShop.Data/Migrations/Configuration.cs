namespace NShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NShop.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NShop.Data.TShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NShop.Data.TShopDbContext";
        }

        protected override void Seed(NShop.Data.TShopDbContext context)
        {
            CreateProductCategorySimple(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TShopDbContext()));
            //var user = new ApplicationUser()
            //{
            //    UserName = "ngoctriet",
            //    Email = "ngoctriet201297@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName="HoNgocTriet"
            //};
            //manager.Create(user, "123456$");
            //if(!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}
            //var adminUser = manager.FindByEmail("ngoctriet201297@gmail.com");
           // manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

        }
        private void CreateProductCategorySimple(NShop.Data.TShopDbContext context)
        {
           if(context.ProductCategories.Count()==0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>();
                {
                    new ProductCategory() { Name = "Điện lạnh", Alias = "dien-lanh", Status = true };
                    new ProductCategory() { Name = "Viễn thông", Alias = "vien-thong", Status = true };
                    new ProductCategory() { Name = "Đồ gia dụng", Alias = "do-gia-dung", Status = true };
                    new ProductCategory() { Name = "Mỹ phẩm", Alias = "my-pham", Status = true };
                }
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();

            }


        }
    }
}
