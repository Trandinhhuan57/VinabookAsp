using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DataAccessLayer.Entities.Flower;

namespace WebApplication.Models
{
    public class FlowerVM
    {
        public int Id { get; set; }

        [Display(Name = "Flower name")]
        [Required]
        public string FLowerName { get; set; }

        public string Discription { get; set; }

        public enum ColorType { Red, Pink, Blue, Lavender, Orange, Purple }
        public ColorType Color { get; set; }

        public byte[] Images { get; set; }
        public IFormFile[] ImagesList { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Sale price")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Store Date")]
        [Required]
        public DateTime StoreDate { get; set; }

        [Display(Name = "Store Inventory")]
        [Required]
        public int StoreInventory { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}