namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyModelChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "appartment_no", c => c.String());
            AlterColumn("dbo.Properties", "dewa_no", c => c.String());
            AlterColumn("dbo.Properties", "du_no", c => c.String());
            AlterColumn("dbo.Properties", "empower_no", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "empower_no", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "du_no", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "dewa_no", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "appartment_no", c => c.Int(nullable: false));
        }
    }
}
