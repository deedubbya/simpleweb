namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int medID { get; set; }

        [Required]
        [StringLength(50)]
        public string medType { get; set; }

        [Required]
        public string medFileName { get; set; }
    }
}
