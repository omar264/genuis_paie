 namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.F_Enfant",
                c => new
                    {
                        EN_NO = c.Int(nullable: false, identity: true),
                        EN_Nom = c.String(maxLength: 69),
                        EN_Prenom = c.String(maxLength: 69),
                        EN_DateNaissance = c.DateTime(),
                        EN_Sexe = c.Short(nullable: false),
                        EN_Acharge = c.Short(nullable: false),
                        SA_NO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EN_NO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.F_Enfant");
        }
    }
}
