namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ondernemings", "Gebruiker_GebruikerID", "dbo.Gebruikers");
            DropIndex("dbo.Ondernemings", new[] { "Gebruiker_GebruikerID" });
            AddColumn("dbo.Gebruikers", "Abonnementen", c => c.String());
            DropColumn("dbo.Ondernemings", "Gebruiker_GebruikerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ondernemings", "Gebruiker_GebruikerID", c => c.Int());
            DropColumn("dbo.Gebruikers", "Abonnementen");
            CreateIndex("dbo.Ondernemings", "Gebruiker_GebruikerID");
            AddForeignKey("dbo.Ondernemings", "Gebruiker_GebruikerID", "dbo.Gebruikers", "GebruikerID");
        }
    }
}
