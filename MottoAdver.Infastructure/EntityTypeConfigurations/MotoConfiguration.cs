using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottoAdver.Domain;

namespace MottoAdver.Infastructure.EntityTypeConfigurations;

public class MotoConfiguration : IEntityTypeConfiguration<Motos>
{
    public void Configure(EntityTypeBuilder<Motos> builder)
    {
        builder.ToTable(nameof(Motos));

        builder.HasKey(moto => moto.Id)
            .IsClustered(true)
            .HasName("moto_pk");

        builder.Property(moto => moto.Id)
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(moto => moto.MotoName)
            .HasMaxLength(30)
            .HasColumnOrder(2)
            .HasColumnName("motoName")
            .IsRequired(true);

        builder.Property(moto => moto.Charge)
            .HasMaxLength(50)
            .HasColumnOrder(3)
            .HasColumnName("charge")
            .IsRequired(true);

        builder.Property(moto => moto.DistanceFullCharge)
            .HasMaxLength(50)
            .HasColumnOrder(4)
            .HasColumnName("distanceFullCharge")
            .IsRequired(true);

        builder.Property(moto => moto.MaxWeight)
            .HasColumnOrder(5)
            .HasColumnName("maxWeight")
            .IsRequired(true);

        builder.Property(moto => moto.MaxSpeed)
            .HasColumnOrder(6)
            .HasColumnName("maxSpeed")
            .IsRequired(true);

        builder.Property(moto => moto.Year)
            .HasColumnOrder(7)
            .HasColumnName("makingYear")
            .IsRequired(true);
    }
}
