namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseTypes", "status", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "status");
            DropColumn("dbo.ExpenseTypes", "status");
        }
    }
}
