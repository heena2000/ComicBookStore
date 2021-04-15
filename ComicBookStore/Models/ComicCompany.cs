using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStore.Models
{
    public class ComicCompany
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Comic Company Name")]
        public string CompanyName { get; set; }

        public virtual ICollection<ComicInfo> CompanyComic { get; set; }
    }
}
