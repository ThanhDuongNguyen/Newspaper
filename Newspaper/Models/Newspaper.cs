using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Models
{
    [Table("Newspaper")]
    public class Newspaper
    {
        [Key]
        public int PageID { get; set; }
        
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        

        [Required]
        [StringLength(1000)]
        public string TinyContent { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int? CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        public double View { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string ImageAvatar { get; set; }

        [Required]
        public int? UserID { get; set; }
        public User Author { get; set; }

        public bool Status { get; set; }
    }
}
