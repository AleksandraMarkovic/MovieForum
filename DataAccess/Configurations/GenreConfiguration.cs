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
    public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.GenreMovies).WithOne(x => x.Genre).HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
