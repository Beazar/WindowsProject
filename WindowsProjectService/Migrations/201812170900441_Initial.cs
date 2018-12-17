namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        StartDatum = c.DateTime(nullable: false),
                        EindDatum = c.DateTime(nullable: false),
                        OndernemingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Ondernemings", t => t.OndernemingID, cascadeDelete: true)
                .Index(t => t.OndernemingID);
            
            CreateTable(
                "dbo.Ondernemings",
                c => new
                    {
                        OndernemingID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Plaats = c.String(),
                        Beschrijving = c.String(),
                        Categorie = c.String(),
                        TelefoonNummer = c.String(),
                        Website = c.String(),
                        Gebruikersnaam = c.String(),
                        Wachtwoord = c.String(),
                        Afbeelding = c.String(),
                    })
                .PrimaryKey(t => t.OndernemingID);
            
            CreateTable(
                "dbo.Promoties",
                c => new
                    {
                        PromotieID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        StartDatum = c.DateTime(nullable: false),
                        EindDatum = c.DateTime(nullable: false),
                        OndernemingID = c.Int(nullable: false),
                        Kortingsbon = c.String(),
                    })
                .PrimaryKey(t => t.PromotieID)
                .ForeignKey("dbo.Ondernemings", t => t.OndernemingID, cascadeDelete: true)
                .Index(t => t.OndernemingID);
            
            CreateTable(
                "dbo.Gebruikers",
                c => new
                    {
                        GebruikerID = c.Int(nullable: false, identity: true),
                        Gebruikersnaam = c.String(),
                        Wachtwoord = c.String(),
                    })
                .PrimaryKey(t => t.GebruikerID);
            
            CreateTable(
                "dbo.KortingsBons",
                c => new
                    {
                        KortingsBonID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Procent = c.Double(nullable: false),
                        VervalDatum = c.DateTime(nullable: false),
                        OndernemingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KortingsBonID)
                .ForeignKey("dbo.Promoties", t => t.OndernemingID, cascadeDelete: true)
                .Index(t => t.OndernemingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KortingsBons", "OndernemingID", "dbo.Promoties");
            DropForeignKey("dbo.Events", "OndernemingID", "dbo.Ondernemings");
            DropForeignKey("dbo.Promoties", "OndernemingID", "dbo.Ondernemings");
            DropIndex("dbo.KortingsBons", new[] { "OndernemingID" });
            DropIndex("dbo.Promoties", new[] { "OndernemingID" });
            DropIndex("dbo.Events", new[] { "OndernemingID" });
            DropTable("dbo.KortingsBons");
            DropTable("dbo.Gebruikers");
            DropTable("dbo.Promoties");
            DropTable("dbo.Ondernemings");
            DropTable("dbo.Events");
        }
    }
}
