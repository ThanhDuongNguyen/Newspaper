using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; } 

        [Required]
        public string RoleName { get; set; }
    }
}
