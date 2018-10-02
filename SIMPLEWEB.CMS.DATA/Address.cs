namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            AddressEntities = new HashSet<AddressEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adrID { get; set; }

        [Required]
        public string adrLine1 { get; set; }

        public string adrLine2 { get; set; }

        public string adrLine3 { get; set; }

        [Required]
        public string adrCity { get; set; }

        [Required]
        [StringLength(50)]
        public string adrState { get; set; }

        public int adrZipCode { get; set; }

        public int? adrZipPlusFour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressEntity> AddressEntities { get; set; }
    }
}
