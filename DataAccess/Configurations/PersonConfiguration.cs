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
    public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Bio).IsRequired();
            builder.Property(x => x.PlaceOfBirth).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.PersonRoleMovies).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
