namespace WindowsProjectService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promoties", "Kortingsbon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promoties", "Kortingsbon");
        }
    }
}
