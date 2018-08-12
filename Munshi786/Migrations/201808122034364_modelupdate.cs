namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChequeDetails", "appartment_id", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChequeDetails", "appartment_id", c => c.Int(nullable: false));
        }
    }
}
