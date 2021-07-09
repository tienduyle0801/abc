namespace MyDb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name= "Tài Khoản")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số Điện Thoại")]
        public string Sdt { get; set; }

        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
    }
}
