namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.F_Salarie", "SA_DateSortie", c => c.DateTime());
            AddColumn("dbo.F_Salarie", "salaireBase", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.F_Salarie", "primes", c => c.Single());
            AddColumn("dbo.F_Salarie", "retenueCnss", c => c.Single(nullable: false));
            AddColumn("dbo.F_Salarie", "retenueIrpp", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.F_Salarie", "retenueIrpp");
            DropColumn("dbo.F_Salarie", "retenueCnss");
            DropColumn("dbo.F_Salarie", "primes");
            DropColumn("dbo.F_Salarie", "salaireBase");
            DropColumn("dbo.F_Salarie", "SA_DateSortie");
        }
    }
}
