namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserRoleEntities = new HashSet<UserRoleEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uID { get; set; }

        [Required]
        [StringLength(50)]
        public string uStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string uFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string uLastName { get; set; }

        [Required]
        public string uEmailAddress { get; set; }

        [Required]
        public string uPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoleEntity> UserRoleEntities { get; set; }
    }
}
