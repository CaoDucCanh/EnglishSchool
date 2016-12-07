namespace EngLishSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberSchool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.String(nullable: false, maxLength: 128),
                        SChoolId = c.String(maxLength: 128),
                        ClassName = c.String(maxLength: 256),
                        IsBlock = c.Boolean(nullable: false),
                        CreatDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Schools", t => t.SChoolId)
                .Index(t => t.SChoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.String(nullable: false, maxLength: 128),
                        SchoolName = c.String(maxLength: 500),
                        Address = c.String(maxLength: 1000),
                        IsBlock = c.Boolean(nullable: false),
                        CreatDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.SchoolId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        LevelName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.LevelSchools",
                c => new
                    {
                        SchoolId = c.String(nullable: false, maxLength: 128),
                        LevelId = c.Int(nullable: false),
                        NumActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SchoolId, t.LevelId })
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Trees",
                c => new
                    {
                        LevelId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        IsBlock = c.Boolean(nullable: false),
                        ParentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LevelId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.ApplicationUsers", "ClassId", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationUsers", "SchoolId", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationUsers", "CreatDate", c => c.DateTime());
            AddColumn("dbo.ApplicationUsers", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ApplicationUsers", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationUsers", "UpdatedBy", c => c.String(maxLength: 256));
            CreateIndex("dbo.ApplicationUsers", "ClassId");
            CreateIndex("dbo.ApplicationUsers", "SchoolId");
            AddForeignKey("dbo.ApplicationUsers", "ClassId", "dbo.Class", "ClassId");
            AddForeignKey("dbo.ApplicationUsers", "SchoolId", "dbo.Schools", "SchoolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trees", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Trees", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUsers", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.ApplicationUsers", "ClassId", "dbo.Class");
            DropForeignKey("dbo.LevelSchools", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.LevelSchools", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Class", "SChoolId", "dbo.Schools");
            DropIndex("dbo.ApplicationUsers", new[] { "SchoolId" });
            DropIndex("dbo.ApplicationUsers", new[] { "ClassId" });
            DropIndex("dbo.Trees", new[] { "UserId" });
            DropIndex("dbo.Trees", new[] { "LevelId" });
            DropIndex("dbo.LevelSchools", new[] { "LevelId" });
            DropIndex("dbo.LevelSchools", new[] { "SchoolId" });
            DropIndex("dbo.Class", new[] { "SChoolId" });
            DropColumn("dbo.ApplicationUsers", "UpdatedBy");
            DropColumn("dbo.ApplicationUsers", "UpdatedDate");
            DropColumn("dbo.ApplicationUsers", "CreatedBy");
            DropColumn("dbo.ApplicationUsers", "CreatDate");
            DropColumn("dbo.ApplicationUsers", "SchoolId");
            DropColumn("dbo.ApplicationUsers", "ClassId");
            DropTable("dbo.Trees");
            DropTable("dbo.LevelSchools");
            DropTable("dbo.Levels");
            DropTable("dbo.Schools");
            DropTable("dbo.Class");
        }
    }
}
