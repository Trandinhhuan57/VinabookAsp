using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.ToTable("Flowers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FLowerName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.StoreDate).IsRequired();
            builder.Property(x => x.StoreInventory).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Flowers).HasForeignKey(x => x.CategoryId);
        }
    }
}