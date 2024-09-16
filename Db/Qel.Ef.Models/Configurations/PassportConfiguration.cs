using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Qel.Ef.Models.Configurations;

public class PassportConfiguration : IEntityTypeConfiguration<Passport>
{
    public void Configure(EntityTypeBuilder<Passport> builder)
    {
        builder.ToTable("Passport");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Number)
            .HasMaxLength(16)
            .IsRequired();
        builder.Property(e => e.Serie)
            .HasMaxLength(8)
            .IsRequired();
    }
}