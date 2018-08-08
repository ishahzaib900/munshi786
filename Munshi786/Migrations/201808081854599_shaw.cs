namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shaw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDetails", "appartment_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChequeDetails", "appartment_id");
        }
    }
}
