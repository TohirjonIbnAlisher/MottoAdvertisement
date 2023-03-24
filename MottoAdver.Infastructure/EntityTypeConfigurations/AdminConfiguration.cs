using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottoAdver.Domain;

namespace MottoAdver.Infastructure.EntityTypeConfigurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admins>
{
    public void Configure(EntityTypeBuilder<Admins> builder)
    {
        builder.ToTable(nameof(Admins));

        builder.HasKey(admin => admin.Id)
            .IsClustered(true)
            .HasName("admin_prKey");

        builder.Property(admin => admin.Id)
            .HasColumnName("id")
            .HasColumnOrder(1);
            
        builder.HasAlternateKey(admin => admin.Email)
            .IsClustered(false)
            .HasName("Email");

        builder.Property(admin => admin.Email)
            .HasMaxLength(30)
            .HasColumnOrder(3)
            .HasColumnName("email")
            .IsRequired(true);

        builder.Property(admin => admin.FullName)
            .HasMaxLength(50)
            .HasColumnName("fullName")
            .HasColumnOrder(2)
            .IsRequired(true);

        builder.Property(admin => admin.TellNumber)
            .HasMaxLength(20)
            .HasColumnName("tellNumber")
            .HasColumnOrder(6)
            .IsRequired(true);

        builder.Property(admin => admin.TelegramId)
            .HasColumnOrder(7)
            .HasColumnName("telegramId")
            .IsRequired(true);

        builder.Property(admin => admin.RefreshToken)
            .HasColumnName("refreshToken")
            .HasColumnOrder(8)
            .IsRequired(false);
                            
        builder.Property(admin => admin.RefreshTokenExpireDate)
            .HasColumnOrder(9)
            .HasColumnName("refreshTokenExpireDate")
            .IsRequired(false);

        builder.Property(admin => admin.PasswordHash)
            .HasColumnName("passwordHash")
            .HasColumnOrder(4)
            .IsRequired(true);

        builder.Property(admin => admin.PasswordSalt)
            .HasColumnName("passwordSalt")
            .HasColumnOrder(5)
            .IsRequired(true);

        builder.HasData(
            new Admins()
            {
                Id = Guid.NewGuid(),
                FullName = "admin",
                Email = "admin@gmail.com",
                TelegramId = 1001896758986,
                TellNumber = "931239658",
                PasswordHash = "admin",
                PasswordSalt = "admin",
            });
    }
}
