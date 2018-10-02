namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SimpleWebDBContext : DbContext
    {
        public SimpleWebDBContext()
            : base("SimpleWebDBConnectionString")
        {
            Database.SetInitializer<SimpleWebDBContext>(new CreateDatabaseIfNotExists<SimpleWebDBContext>());
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressEntity> AddressEntities { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<CustomProperty> CustomProperties { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuNavigationItem> MenuNavigationItems { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<RolePermissionEntity> RolePermissionEntities { get; set; }
        public virtual DbSet<TableLog> TableLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserRoleEntity> UserRoleEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.aCompanyName)                
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.adrLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.adrLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.adrLine3)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.adrCity)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.adrState)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.AddressEntities)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.aeAddressID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.aeTableName)
                .IsUnicode(false);

            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.aeAddressType)
                .IsUnicode(false);

            modelBuilder.Entity<CustomProperty>()
                .Property(e => e.cpTableName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomProperty>()
                .Property(e => e.cpName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomProperty>()
                .Property(e => e.cpValue)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.medType)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.medFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.mName)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MenuNavigationItems)
                .WithRequired(e => e.Menu)
                .HasForeignKey(e => e.mniMenuID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuNavigationItem>()
                .Property(e => e.mniLinkType)
                .IsUnicode(false);

            modelBuilder.Entity<MenuNavigationItem>()
                .Property(e => e.mniExternalLink)
                .IsUnicode(false);

            modelBuilder.Entity<MenuNavigationItem>()
                .Property(e => e.mniTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.pStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.pVisibility)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.pHeaderTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.pHtmlContent)
                .IsUnicode(false);

            modelBuilder.Entity<RolePermission>()
                .Property(e => e.rpPermissionName)
                .IsUnicode(false);

            modelBuilder.Entity<RolePermission>()
                .Property(e => e.rpPermissionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RolePermission>()
                .HasMany(e => e.RolePermissionEntities)
                .WithRequired(e => e.RolePermission)
                .HasForeignKey(e => e.rpeRolePermissionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TableLog>()
                .Property(e => e.tlType)
                .IsUnicode(false);

            modelBuilder.Entity<TableLog>()
                .Property(e => e.tlDescription)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.uStatus)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.uFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.uLastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.uEmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoleEntities)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ureUserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.urRoleName)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.RolePermissionEntities)
                .WithRequired(e => e.UserRole)
                .HasForeignKey(e => e.rpeUserRoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.UserRoleEntities)
                .WithRequired(e => e.UserRole)
                .HasForeignKey(e => e.ureUserRoleID)
                .WillCascadeOnDelete(false);
        }
    }
}
