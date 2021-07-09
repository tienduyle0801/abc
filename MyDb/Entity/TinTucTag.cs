namespace MyDb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTucTag")]
    public partial class TinTucTag
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TinTucId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TagId { get; set; }
    }
}
