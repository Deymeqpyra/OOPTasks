using Domain.Admin;
using Domain.Guest;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                value => new UserId(value));

        builder.Property("Name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property("Role")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Admin>("Admin")
            .HasValue<Guest>("Guest");
    }
}