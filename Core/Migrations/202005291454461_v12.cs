namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.F_Salarie", "Css", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.F_Salarie", "Css");
        }
    }
}
