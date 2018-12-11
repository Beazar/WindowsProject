namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ondernemings", "Afbeelding", c => c.String());
            DropColumn("dbo.Ondernemings", "Afbeeldingen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ondernemings", "Afbeeldingen", c => c.String());
            DropColumn("dbo.Ondernemings", "Afbeelding");
        }
    }
}
