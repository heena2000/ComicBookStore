using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStore.Models
{
    public class ComicInfo
    {
        [Key]
        public int ComicID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name ="Comic Name")]
        public string ComicName { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name ="Comic Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Number of Pages")]
        public int Pages { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }

        [Required]
        public int CompanyID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CompanyID")]
        [InverseProperty("CompanyComic")]
        public virtual ComicCompany CompanyComic { get; set; }

        [ForeignKey("CategoryID")]
        [InverseProperty("CategoryComic")]
        public virtual ComicCategory CategoryComic { get; set; }

        public virtual ICollection<ComicOrder> ComicOrders { get; set; }
    }

    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
