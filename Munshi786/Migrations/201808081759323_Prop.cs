namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Properties", "file", c => c.String());
            AddColumn("dbo.Properties", "created_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Properties", "created_by", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "owner_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "owner_id");
            DropColumn("dbo.Properties", "created_by");
            DropColumn("dbo.Properties", "created_date");
            DropColumn("dbo.Properties", "file");
            DropTable("dbo.Users");
        }
    }
}
