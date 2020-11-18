using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.DTOs.Input
{
    public class UserForCreate
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(50)]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập mail hợp lệ")]
        public string Email { get; set; }


       
        [DataType(DataType.DateTime, ErrorMessage = "Ngày sinh không hợp lệ")]
        public DateTime? DOB { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }


        [Compare(otherProperty: "Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

    }
}
