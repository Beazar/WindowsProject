namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ondernemings", "Gebruiker_GebruikerID", c => c.Int());
            CreateIndex("dbo.Ondernemings", "Gebruiker_GebruikerID");
            AddForeignKey("dbo.Ondernemings", "Gebruiker_GebruikerID", "dbo.Gebruikers", "GebruikerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ondernemings", "Gebruiker_GebruikerID", "dbo.Gebruikers");
            DropIndex("dbo.Ondernemings", new[] { "Gebruiker_GebruikerID" });
            DropColumn("dbo.Ondernemings", "Gebruiker_GebruikerID");
        }
    }
}
