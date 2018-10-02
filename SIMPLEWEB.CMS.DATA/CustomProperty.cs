namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cpID { get; set; }

        public string cpTableName { get; set; }

        public int? cpTableID { get; set; }

        [Required]
        public string cpName { get; set; }

        [Required]
        public string cpValue { get; set; }
    }
}
