namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuNavigationItem")]
    public partial class MenuNavigationItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int mniID { get; set; }

        public int mniMenuID { get; set; }

        public int mniMenuHierarchy { get; set; }

        public int mniMenuSort { get; set; }

        [Required]
        [StringLength(50)]
        public string mniLinkType { get; set; }

        public int? mniPageID { get; set; }

        public string mniExternalLink { get; set; }

        [Required]
        public string mniTitle { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
