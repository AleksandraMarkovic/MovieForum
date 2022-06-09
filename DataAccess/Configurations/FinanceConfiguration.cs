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
    public class FinanceConfiguration : IEntityTypeConfiguration<FinanceEntity>
    {
        public void Configure(EntityTypeBuilder<FinanceEntity> builder)
        {
            builder.Property(x => x.Budget).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.Movie).WithMany(x => x.Finances).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
