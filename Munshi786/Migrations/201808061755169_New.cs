namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "area", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "building", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "appartment_no", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "dewa_no", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "dewa_no", c => c.String());
            AlterColumn("dbo.Properties", "appartment_no", c => c.String());
            AlterColumn("dbo.Properties", "building", c => c.String());
            AlterColumn("dbo.Properties", "area", c => c.String());
        }
    }
}
