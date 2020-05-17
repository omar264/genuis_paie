namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.F_Salarie", "DP_Code", c => c.String());
            AddColumn("dbo.F_Salarie", "SE_Code", c => c.String());
            AddColumn("dbo.F_Salarie", "UN_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.F_Salarie", "UN_Code");
            DropColumn("dbo.F_Salarie", "SE_Code");
            DropColumn("dbo.F_Salarie", "DP_Code");
        }
    }
}
