namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creationdebase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.F_Salarie", "SA_Jour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.F_Salarie", "SA_Jour", c => c.String());
        }
    }
}
