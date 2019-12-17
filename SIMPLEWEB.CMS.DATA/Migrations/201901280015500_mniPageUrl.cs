namespace SIMPLEWEB.CMS.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mniPageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuNavigationItem", "mniPageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuNavigationItem", "mniPageUrl");
        }
    }
}
