using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.DTOs.Output
{
    public class UserForView
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
    }
}
