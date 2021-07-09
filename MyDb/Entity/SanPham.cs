namespace MyDb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        public long Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Masp { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Hinh { get; set; }

        [Column(TypeName = "xml")]
        public string MoreHinh { get; set; }

        public decimal? Gia { get; set; }

        public decimal? Giakhuyenmai { get; set; }

        public bool? ThueVAT { get; set; }

        public int? SoLuong { get; set; }

        public long? DanhmucId { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Baohanh { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MeteKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public DateTime? Topsp { get; set; }

        public int? ViewCount { get; set; }
    }
}
