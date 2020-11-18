using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.DTOs.Input
{
    public class NewspaperForCreate
    {

        [Required]
        [StringLength(150)]
        public string Title { get; set; }


        [Required]
        [StringLength(1000)]
        public string TinyContent { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string ImageAvatar { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
