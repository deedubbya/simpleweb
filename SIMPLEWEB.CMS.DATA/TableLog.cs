namespace SIMPLEWEB.CMS.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableLog")]
    public partial class TableLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tlID { get; set; }

        [StringLength(50)]
        public string tlType { get; set; }

        public int? tlUserID { get; set; }

        public DateTime? tlDate { get; set; }

        [Column(TypeName = "text")]
        public string tlDescription { get; set; }
    }
}
