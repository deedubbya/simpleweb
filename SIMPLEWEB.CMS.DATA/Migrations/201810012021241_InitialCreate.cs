namespace SIMPLEWEB.CMS.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        aID = c.Int(nullable: false, identity: true),
                        aStatus = c.String(nullable: false),
                        aCompanyName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.aID);
            
            CreateTable(
                "dbo.AddressEntity",
                c => new
                    {
                        aeID = c.Int(nullable: false, identity: true),
                        aeAddressID = c.Int(nullable: false),
                        aeTableName = c.String(nullable: false, maxLength: 50, unicode: false),
                        aeTableID = c.Int(nullable: false),
                        aeAddressType = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.aeID)
                .ForeignKey("dbo.Address", t => t.aeAddressID)
                .Index(t => t.aeAddressID);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        adrID = c.Int(nullable: false, identity: true),
                        adrLine1 = c.String(nullable: false, unicode: false),
                        adrLine2 = c.String(unicode: false),
                        adrLine3 = c.String(unicode: false),
                        adrCity = c.String(nullable: false, unicode: false),
                        adrState = c.String(nullable: false, maxLength: 50, unicode: false),
                        adrZipCode = c.Int(nullable: false),
                        adrZipPlusFour = c.Int(),
                    })
                .PrimaryKey(t => t.adrID);
            
            CreateTable(
                "dbo.__RefactorLog",
                c => new
                    {
                        OperationKey = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OperationKey);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomProperties",
                c => new
                    {
                        cpID = c.Int(nullable: false, identity: true),
                        cpTableName = c.String(unicode: false),
                        cpTableID = c.Int(),
                        cpName = c.String(nullable: false, unicode: false),
                        cpValue = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.cpID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        medID = c.Int(nullable: false, identity: true),
                        medType = c.String(nullable: false, maxLength: 50, unicode: false),
                        medFileName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.medID);
            
            CreateTable(
                "dbo.MenuNavigationItem",
                c => new
                    {
                        mniID = c.Int(nullable: false, identity: true),
                        mniMenuID = c.Int(nullable: false),
                        mniMenuHierarchy = c.Int(nullable: false),
                        mniMenuSort = c.Int(nullable: false),
                        mniLinkType = c.String(nullable: false, maxLength: 50, unicode: false),
                        mniPageID = c.Int(),
                        mniExternalLink = c.String(unicode: false),
                        mniTitle = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.mniID)
                .ForeignKey("dbo.Menu", t => t.mniMenuID)
                .Index(t => t.mniMenuID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        mID = c.Int(nullable: false, identity: true),
                        mName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.mID);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        pID = c.Int(nullable: false, identity: true),
                        pStatus = c.String(nullable: false, maxLength: 50, unicode: false),
                        pIsHomePage = c.Boolean(nullable: false),
                        pVisibility = c.String(nullable: false, maxLength: 50, unicode: false),
                        pHeaderTitle = c.String(unicode: false),
                        pHtmlContent = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.pID);
            
            CreateTable(
                "dbo.RolePermissionEntity",
                c => new
                    {
                        rpeID = c.Int(nullable: false, identity: true),
                        rpeUserRoleID = c.Int(nullable: false),
                        rpeRolePermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.rpeID)
                .ForeignKey("dbo.RolePermission", t => t.rpeRolePermissionID)
                .ForeignKey("dbo.UserRole", t => t.rpeUserRoleID)
                .Index(t => t.rpeUserRoleID)
                .Index(t => t.rpeRolePermissionID);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        rpID = c.Int(nullable: false, identity: true),
                        rpPermissionName = c.String(nullable: false, maxLength: 50, unicode: false),
                        rpPermissionDescription = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.rpID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        urID = c.Int(nullable: false, identity: true),
                        urRoleName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.urID);
            
            CreateTable(
                "dbo.UserRoleEntity",
                c => new
                    {
                        ureID = c.Int(nullable: false, identity: true),
                        ureUserID = c.Int(nullable: false),
                        ureUserRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ureID)
                .ForeignKey("dbo.User", t => t.ureUserID)
                .ForeignKey("dbo.UserRole", t => t.ureUserRoleID)
                .Index(t => t.ureUserID)
                .Index(t => t.ureUserRoleID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        uID = c.Int(nullable: false, identity: true),
                        uStatus = c.String(nullable: false, maxLength: 50, unicode: false),
                        uFirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        uLastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        uEmailAddress = c.String(nullable: false, unicode: false),
                        uPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.uID);
            
            CreateTable(
                "dbo.TableLog",
                c => new
                    {
                        tlID = c.Int(nullable: false, identity: true),
                        tlType = c.String(maxLength: 50, unicode: false),
                        tlUserID = c.Int(),
                        tlDate = c.DateTime(),
                        tlDescription = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.tlID);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        uaId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.uaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleEntity", "ureUserRoleID", "dbo.UserRole");
            DropForeignKey("dbo.UserRoleEntity", "ureUserID", "dbo.User");
            DropForeignKey("dbo.RolePermissionEntity", "rpeUserRoleID", "dbo.UserRole");
            DropForeignKey("dbo.RolePermissionEntity", "rpeRolePermissionID", "dbo.RolePermission");
            DropForeignKey("dbo.MenuNavigationItem", "mniMenuID", "dbo.Menu");
            DropForeignKey("dbo.AddressEntity", "aeAddressID", "dbo.Address");
            DropIndex("dbo.UserRoleEntity", new[] { "ureUserRoleID" });
            DropIndex("dbo.UserRoleEntity", new[] { "ureUserID" });
            DropIndex("dbo.RolePermissionEntity", new[] { "rpeRolePermissionID" });
            DropIndex("dbo.RolePermissionEntity", new[] { "rpeUserRoleID" });
            DropIndex("dbo.MenuNavigationItem", new[] { "mniMenuID" });
            DropIndex("dbo.AddressEntity", new[] { "aeAddressID" });
            DropTable("dbo.UserAccount");
            DropTable("dbo.TableLog");
            DropTable("dbo.User");
            DropTable("dbo.UserRoleEntity");
            DropTable("dbo.UserRole");
            DropTable("dbo.RolePermission");
            DropTable("dbo.RolePermissionEntity");
            DropTable("dbo.Page");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuNavigationItem");
            DropTable("dbo.Media");
            DropTable("dbo.CustomProperties");
            DropTable("dbo.Content");
            DropTable("dbo.__RefactorLog");
            DropTable("dbo.Address");
            DropTable("dbo.AddressEntity");
            DropTable("dbo.Account");
        }
    }
}
