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
    public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.Property(x => x.CountryName).IsRequired();
            builder.HasIndex(x => x.CountryName).IsUnique();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Movies).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
