namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.F_BullteinPaie",
                c => new
                    {
                        BP_NO = c.Int(nullable: false, identity: true),
                        SA_DateSortie = c.DateTime(),
                        salaireBase = c.Decimal(precision: 18, scale: 2),
                        primes = c.Single(),
                        retenueCnss = c.Single(nullable: false),
                        retenueIrpp = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.BP_NO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.F_BullteinPaie");
        }
    }
}
