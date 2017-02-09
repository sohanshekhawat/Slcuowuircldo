namespace shanuMVCUserRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class public_state_ct_bld : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroupMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodGroupId = c.Int(nullable: false),
                        DonateTo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId, cascadeDelete: true)
                .Index(t => t.BloodGroupId);
            
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        BloodGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BloodGroupId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.PersonalInfoes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CityId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        BloodGroupId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.BloodGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInfoes", "StateId", "dbo.States");
            DropForeignKey("dbo.PersonalInfoes", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PersonalInfoes", "BloodGroupId", "dbo.BloodGroups");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.BloodGroupMaps", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.PersonalInfoes", new[] { "BloodGroupId" });
            DropIndex("dbo.PersonalInfoes", new[] { "StateId" });
            DropIndex("dbo.PersonalInfoes", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.BloodGroupMaps", new[] { "BloodGroupId" });
            DropTable("dbo.PersonalInfoes");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.BloodGroups");
            DropTable("dbo.BloodGroupMaps");
        }
    }
}
