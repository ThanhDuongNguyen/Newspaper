using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public Category ParentCatID { get; set; }

        [Required]
        public string CategoryName {get; set;}

        public ICollection<NewspaperModel> Newspapers { get; set; }
    }
}
