using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Display(Name ="Category Name")]
        [Required]
        public string CategoryName { get; set; }

        [Display(Name = "Order")]
        [Required]
        public int Order { get; set; }

        public string Notes { get; set; }

        public ICollection<FlowerVM> Flowers { get; set; }
    }
}
