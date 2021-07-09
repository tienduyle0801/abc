using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class DangkyModel
    {
        [Key]
        public long Id { set; get; }

        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Nhập Tên Tài Khoản")]

        public string UserName { set; get; }

        [Display(Name = "Mật Khẩu")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "mật khẩu phải ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Nhập Mật Khẩu")]
        public string Password { set; get; }

        [Display(Name = "Xác Nhận Mật Khẩu")]
        [Compare("Password", ErrorMessage = "Mật Khẩu Không Trùng Khớp")]
        public string NhaplaiPassword { set; get; }

        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "Nhập Họ Tên")]
        public string Name { set; get; }

        [Display(Name = "Địa Chỉ")]

        public string Diachi { set; get; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nhập Email")]
        public string Email { set; get; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Nhập Số Điện Thoại")]
        public string Sdt { set; get; }

        [Display(Name = "Tỉnh/Thành")]
        public string ProvinceId { set; get; }

        [Display(Name = "Quận/Huyện")]
        public string DistrictId { set; get; }

    }
}