namespace EngLishSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Class", "CreateddBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Schools", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Schools", "CreateddBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ApplicationUsers", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationUsers", "CreateddBy", c => c.String(maxLength: 256));
            AddColumn("dbo.TypeUsers", "NumberSort", c => c.Int());
            DropColumn("dbo.Class", "CreatDate");
            DropColumn("dbo.Class", "CreatedBy");
            DropColumn("dbo.Schools", "CreatDate");
            DropColumn("dbo.Schools", "CreatedBy");
            DropColumn("dbo.ApplicationUsers", "CreatDate");
            DropColumn("dbo.ApplicationUsers", "CreatedBy");
            DropColumn("dbo.TypeUsers", "NuberSort");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeUsers", "NuberSort", c => c.Int());
            AddColumn("dbo.ApplicationUsers", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ApplicationUsers", "CreatDate", c => c.DateTime());
            AddColumn("dbo.Schools", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Schools", "CreatDate", c => c.DateTime());
            AddColumn("dbo.Class", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Class", "CreatDate", c => c.DateTime());
            DropColumn("dbo.TypeUsers", "NumberSort");
            DropColumn("dbo.ApplicationUsers", "CreateddBy");
            DropColumn("dbo.ApplicationUsers", "CreatedDate");
            DropColumn("dbo.Schools", "CreateddBy");
            DropColumn("dbo.Schools", "CreatedDate");
            DropColumn("dbo.Class", "CreateddBy");
            DropColumn("dbo.Class", "CreatedDate");
        }
    }
}
