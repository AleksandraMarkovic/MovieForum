using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).IsRequired();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Property(x => x.MailingList).HasDefaultValue("false");

            builder.HasOne(x => x.UserRole).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Ratings).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Watchlists).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
