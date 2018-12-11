namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gebruikers",
                c => new
                    {
                        GebruikerID = c.Int(nullable: false, identity: true),
                        Gebruikersnaam = c.String(),
                        Wachtwoord = c.String(),
                    })
                .PrimaryKey(t => t.GebruikerID);
            
            AddColumn("dbo.Ondernemings", "Gebruikersnaam", c => c.String());
            AddColumn("dbo.Ondernemings", "Wachtwoord", c => c.String());
            AddColumn("dbo.Ondernemings", "Afbeeldingen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ondernemings", "Afbeeldingen");
            DropColumn("dbo.Ondernemings", "Wachtwoord");
            DropColumn("dbo.Ondernemings", "Gebruikersnaam");
            DropTable("dbo.Gebruikers");
        }
    }
}
