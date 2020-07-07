using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Common
{
    public class UserSignupModel
    {
        [Required(ErrorMessage = "Họ không được để trống")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string UserName_S { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Mật khẩu phải 6 đến 10 ký tự")]
        public string Password_S { get; set; }

        [Compare("Password_S", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
    }
}
