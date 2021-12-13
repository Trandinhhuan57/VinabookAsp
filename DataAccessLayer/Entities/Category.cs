using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int Order { get; set; }

        public string Notes { get; set; }

        public ICollection<Flower> Flowers { get; set; }
    }
}