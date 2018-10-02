namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RolePermissionEntity")]
    public partial class RolePermissionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rpeID { get; set; }

        public int rpeUserRoleID { get; set; }

        public int rpeRolePermissionID { get; set; }

        public virtual RolePermission RolePermission { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
