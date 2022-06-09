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
    public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.HasIndex(x => x.Title).IsUnique();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Poster).IsRequired();
            builder.Property(x => x.CoverImg).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Popularity).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.Country).WithMany(x => x.Movies).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Type).WithMany(x => x.Movies).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.MovieGenres).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Finances).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.PersonRoleMovies).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Ratings).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Comments).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Watchlists).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
