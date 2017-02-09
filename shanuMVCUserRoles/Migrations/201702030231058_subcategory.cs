namespace shanuMVCUserRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "SubCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "StatusReason", c => c.String());
            AddColumn("dbo.Blogs", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Active");
            DropColumn("dbo.Blogs", "StatusReason");
            DropColumn("dbo.Blogs", "SubCategoryId");
        }
    }
}
