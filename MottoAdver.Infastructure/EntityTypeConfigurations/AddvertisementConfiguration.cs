using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottoAdver.Domain;

namespace MottoAdver.Infastructure.EntityTypeConfigurations;

public class AddvertisementConfiguration : IEntityTypeConfiguration<Addvertisements>
{
    public void Configure(EntityTypeBuilder<Addvertisements> builder)
    {
        builder.ToTable(nameof(Addvertisements));

        builder.HasKey(add => add.Id)
            .IsClustered(true)
            .HasName("addver_pk");

        builder.Property(add => add.Id)
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(add => add.AddvertiserFullName)
            .HasMaxLength(50)
            .HasColumnName("addvertiserFullName")
            .HasColumnOrder(2)
            .IsRequired(true);

        builder.Property(add => add.AddvertiserTelegramUserName)
            .HasColumnName("addvertiserTelegramId")
            .HasColumnOrder(3)
            .IsRequired(true);

        builder.Property(add => add.AddvertiserTellNumber)
            .HasMaxLength(15)
            .HasColumnName("addvertiserTellNumber")
            .HasColumnOrder(4)
            .IsRequired(true);

        builder.Property(add => add.Price)
            .HasColumnName("motoPrice")
            .HasColumnOrder(5)
            .HasColumnType("decimal")
            .IsRequired(true);

        builder.Property(add => add.AddressId)
            .HasColumnName("addressId")
            .HasColumnOrder(6)
            .IsRequired(true);

        builder.Property(add => add.MotoId)
           .HasColumnName("motoId")
           .HasColumnOrder(7)
           .IsRequired(true);

        builder.HasOne(add => add.Address)
            .WithOne()
            .HasForeignKey<Addvertisements>(add => add.AddressId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(add => add.Moto)
            .WithOne()
            .HasForeignKey<Addvertisements>(add => add.MotoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
