using DataAccessLayer.Configurations;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbcontext : IdentityDbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //add configuration
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new FlowerConfiguration());

            //seed data
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Seed();
        }

        public DbSet<Category> Categories { set; get; }

        public DbSet<Flower> Flowers { get; set; }
    }
}