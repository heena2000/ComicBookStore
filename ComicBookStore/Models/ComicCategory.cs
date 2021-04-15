using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStore.Models
{
    public class ComicCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Comic Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<ComicInfo> CategoryComic { get; set; }
    }
}
