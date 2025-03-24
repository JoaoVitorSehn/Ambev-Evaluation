using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(si => si.ProductId)
                   .HasColumnType("uuid")
                   .IsRequired();

            builder.Property(si => si.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);

            builder.Property(si => si.UnitPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(si => si.Discount)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.Property(si => si.SaleId)
                   .HasColumnType("uuid")
                   .IsRequired();

            builder.HasOne(si => si.Sale)
                   .WithMany(s => s.SaleItems)
                   .HasForeignKey(si => si.SaleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(si => si.Status)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(si => si.TotalItemAmount)
                   .HasComputedColumnSql("([UnitPrice] * [Quantity]) - [Discount]");

            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}