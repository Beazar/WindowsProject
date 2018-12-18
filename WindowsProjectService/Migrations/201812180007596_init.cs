namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promoties", "Kortingsbon", c => c.String());
            AddColumn("dbo.Gebruikers", "Abonnementen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gebruikers", "Abonnementen");
            DropColumn("dbo.Promoties", "Kortingsbon");
        }
    }
}
