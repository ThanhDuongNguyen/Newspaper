using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.DTOs.Input
{
    public class LoginDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
    }
}
