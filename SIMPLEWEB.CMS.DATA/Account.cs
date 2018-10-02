namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int aID { get; set; }

        [Required]
        public string aStatus { get; set; }

        [Required]
        public string aCompanyName { get; set; }

    }
}
