namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.F_Salarie", "primes", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.F_Salarie", "retenueCnss", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.F_Salarie", "retenueIrpp", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.F_Salarie", "retenueIrpp", c => c.Single(nullable: false));
            AlterColumn("dbo.F_Salarie", "retenueCnss", c => c.Single(nullable: false));
            AlterColumn("dbo.F_Salarie", "primes", c => c.Single());
        }
    }
}
