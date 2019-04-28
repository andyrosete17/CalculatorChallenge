namespace Calculator.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calculators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstOperand = c.String(),
                        SecondOperand = c.String(),
                        Operation = c.String(),
                        Result = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calculators");
        }
    }
}
