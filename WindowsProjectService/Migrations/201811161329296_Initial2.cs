namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Promoties", "Onderneming_OndernemingID", "dbo.Ondernemings");
            DropIndex("dbo.Promoties", new[] { "Onderneming_OndernemingID" });
            RenameColumn(table: "dbo.Promoties", name: "Onderneming_OndernemingID", newName: "OndernemingID");
            AddColumn("dbo.Ondernemings", "TelefoonNummer", c => c.String());
            AddColumn("dbo.Ondernemings", "Website", c => c.String());
            AlterColumn("dbo.Promoties", "OndernemingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Promoties", "OndernemingID");
            AddForeignKey("dbo.Promoties", "OndernemingID", "dbo.Ondernemings", "OndernemingID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promoties", "OndernemingID", "dbo.Ondernemings");
            DropIndex("dbo.Promoties", new[] { "OndernemingID" });
            AlterColumn("dbo.Promoties", "OndernemingID", c => c.Int());
            DropColumn("dbo.Ondernemings", "Website");
            DropColumn("dbo.Ondernemings", "TelefoonNummer");
            RenameColumn(table: "dbo.Promoties", name: "OndernemingID", newName: "Onderneming_OndernemingID");
            CreateIndex("dbo.Promoties", "Onderneming_OndernemingID");
            AddForeignKey("dbo.Promoties", "Onderneming_OndernemingID", "dbo.Ondernemings", "OndernemingID");
        }
    }
}
