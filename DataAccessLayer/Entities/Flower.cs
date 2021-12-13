using System;

namespace DataAccessLayer.Entities
{
    public class Flower
    {
        public int Id { get; set; }

        public string FLowerName { get; set; }

        public string Discription { get; set; }

        public enum ColorType { Red, Pink, Blue, Lavender, Orange, Purple }

        public ColorType Color { get; set; }

        public byte[] Images { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public DateTime StoreDate { get; set; }

        public int StoreInventory { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}