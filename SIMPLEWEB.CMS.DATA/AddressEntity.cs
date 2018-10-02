namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddressEntity")]
    public partial class AddressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int aeID { get; set; }

        public int aeAddressID { get; set; }

        [Required]
        [StringLength(50)]
        public string aeTableName { get; set; }

        public int aeTableID { get; set; }

        [StringLength(50)]
        public string aeAddressType { get; set; }

        public virtual Address Address { get; set; }
    }
}
