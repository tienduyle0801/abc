using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class DangnhapModel
    {
        [Key]
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Nhập Tài Khoản")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Nhập Mật Khẩu")]
        [Display(Name = "Mật Khẩu")]
        public string Password { set; get; }
    }
}