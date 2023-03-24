using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottoAdver.Domain;

namespace MottoAdver.Infastructure.EntityTypeConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Addresses>
{
    public void Configure(EntityTypeBuilder<Addresses> builder)
    {
        builder.ToTable(nameof(Addresses));

        builder.HasKey(address => address.Id)
            .IsClustered(true)
            .HasName("address_pr");

        builder.Property(address => address.Id)
           .HasColumnName("id")
           .HasColumnOrder(1);

        builder.Property(address => address.Country)
            .HasMaxLength(50)
            .HasColumnName("country")
            .HasColumnOrder(2)
            .IsRequired(true);

        builder.Property(address => address.Region)
           .HasMaxLength(50)
           .HasColumnName("region")
           .HasColumnOrder(3)
           .IsRequired(false);

        builder.Property(address => address.District)
            .HasMaxLength(50)
            .HasColumnName("district")
            .HasColumnOrder(4)
            .IsRequired(false);

        builder.Property(address => address.Street)
           .HasMaxLength(50)
           .HasColumnName("street")
           .HasColumnOrder(5)
           .IsRequired(false);

        builder.Property(address => address.PostalCode)
            .HasColumnName("postalCode")
            .HasColumnOrder(6)
            .IsRequired(true)
            .HasColumnType("int");
    }
}
