using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Extensions
{
    public static class ModelBuiderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category() { Id = 1, CategoryName = "Category 1", Order = 1 },
                new Category() { Id = 2, CategoryName = "Category 2", Order = 1 },
                new Category() { Id = 3, CategoryName = "Category 3", Order = 1 }
                );

            builder.Entity<Flower>().HasData(
                new Flower() { Id = 1, FLowerName = "Flower 1", Price = 100, StoreDate = DateTime.Now, StoreInventory = 1, CategoryId = 1 },
                new Flower() { Id = 2, FLowerName = "Flower 2", Price = 100, StoreDate = DateTime.Now, StoreInventory = 1, CategoryId = 1 },
                new Flower() { Id = 3, FLowerName = "Flower 3", Price = 100, StoreDate = DateTime.Now, StoreInventory = 1, CategoryId = 1 },
                new Flower() { Id = 4, FLowerName = "Flower 4", Price = 100, StoreDate = DateTime.Now, StoreInventory = 1, CategoryId = 1 }
                );
        }
    }
}