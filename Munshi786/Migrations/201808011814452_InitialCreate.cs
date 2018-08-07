namespace Munshi786.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChequeDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cheque_no = c.Int(nullable: false),
                        cheque_date = c.DateTime(nullable: false),
                        cheque_till = c.DateTime(nullable: false),
                        cheque_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cheque_by_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        appartment_id = c.Int(nullable: false),
                        expense_type_id = c.Int(nullable: false),
                        expense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        payment_to = c.String(),
                        payment_by_id = c.Int(nullable: false),
                        payment_date = c.DateTime(nullable: false),
                        description = c.String(),
                        added_by = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        added_date = c.DateTime(nullable: false),
                        expence_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        area = c.String(),
                        building = c.String(),
                        contract_start_date = c.DateTime(nullable: false),
                        contract_end_date = c.DateTime(nullable: false),
                        rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        deposite = c.Decimal(nullable: false, precision: 18, scale: 2),
                        commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        no_beds = c.Int(nullable: false),
                        no_cheques = c.Int(nullable: false),
                        appartment_no = c.Int(nullable: false),
                        dewa_no = c.Int(nullable: false),
                        du_no = c.Int(nullable: false),
                        empower_no = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        from_id = c.Int(nullable: false),
                        to_id = c.Int(nullable: false),
                        payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        date = c.DateTime(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
            DropTable("dbo.Properties");
            DropTable("dbo.ExpenseTypes");
            DropTable("dbo.Expenses");
            DropTable("dbo.ChequeDetails");
        }
    }
}
