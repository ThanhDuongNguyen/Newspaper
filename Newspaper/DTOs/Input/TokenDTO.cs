using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.DTOs.Input
{
    public class TokenDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Token không hợp lệ")]
        public string AccessToken { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Token không hợp lệ")]
        public string RefreshToken { get; set; }
    }
}
