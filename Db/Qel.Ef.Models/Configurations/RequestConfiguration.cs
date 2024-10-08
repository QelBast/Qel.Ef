using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Qel.Ef.Models.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Period)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.Summa)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasData([
                new() { Id = 1, Summa = 100000, Period = 12 },
                new() { Id = 2, Summa = 1230900, Period = 36 }
            ]);
    }
}