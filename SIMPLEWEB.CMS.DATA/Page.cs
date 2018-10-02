namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Page")]
    public partial class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pID { get; set; }

        [Required]
        [StringLength(50)]
        public string pStatus { get; set; }

        public bool pIsHomePage { get; set; }

        [Required]
        [StringLength(50)]
        public string pVisibility { get; set; }

        public string pHeaderTitle { get; set; }

        [Column(TypeName = "text")]
        public string pHtmlContent { get; set; }
    }
}
