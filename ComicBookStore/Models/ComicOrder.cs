using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStore.Models
{
    public class ComicOrder
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(200)]
        public string UserID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public float Total { get; set; }

        [Required]
        public int ComicID { get; set; }

        public ComicInfo ComicInfo { get; set; }
    }
}
