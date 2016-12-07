namespace EngLishSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableError : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ApplicationRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ApplicationUserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUserRoles", "Discriminator");
            DropColumn("dbo.ApplicationRoles", "Discriminator");
            DropTable("dbo.Errors");
        }
    }
}
