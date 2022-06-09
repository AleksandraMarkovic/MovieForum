using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.TypeEntity>
    {
        public void Configure(EntityTypeBuilder<Domain.TypeEntity> builder)
        {
            builder.Property(x => x.MovieType).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Movies).WithOne(x => x.Type).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
