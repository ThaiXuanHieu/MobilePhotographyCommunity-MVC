using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Common
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Mật khẩu phải 6 đến 10 ký tự")]
        public string Password { get; set; }
    }
}
