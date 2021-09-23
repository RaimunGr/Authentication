using Core.DomainModel.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Dal.UserAggregate
{
    public sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(b => b.Id)
                .IsRequired();

            builder
                .Property(b => b.FirstName)
                .IsRequired();

            builder
                .Property(b => b.LastName)
                .IsRequired();

            builder
                .Property(b => b.Username)
                .IsRequired();

            builder
                .Property(b => b.Password)
                .IsRequired();

            builder
                .HasIndex(b => new
                {
                    b.Id,
                    b.Username,
                    b.FirstName,
                    b.LastName,
                    b.CreationDate,
                }, "IX_GetUser");
        }
    }
}
