namespace NShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAudiate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Pages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Posts", "UpdateDate", c => c.DateTime());
            DropColumn("dbo.Products", "CreatedUpdate");
            DropColumn("dbo.ProductCategories", "CreatedUpdate");
            DropColumn("dbo.Pages", "CreatedUpdate");
            DropColumn("dbo.PostCategories", "CreatedUpdate");
            DropColumn("dbo.Posts", "CreatedUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CreatedUpdate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "CreatedUpdate", c => c.DateTime());
            AddColumn("dbo.Pages", "CreatedUpdate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "CreatedUpdate", c => c.DateTime());
            AddColumn("dbo.Products", "CreatedUpdate", c => c.DateTime());
            DropColumn("dbo.Posts", "UpdateDate");
            DropColumn("dbo.PostCategories", "UpdateDate");
            DropColumn("dbo.Pages", "UpdateDate");
            DropColumn("dbo.ProductCategories", "UpdateDate");
            DropColumn("dbo.Products", "UpdateDate");
        }
    }
}
