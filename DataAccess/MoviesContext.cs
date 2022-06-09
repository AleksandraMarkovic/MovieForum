using DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class MoviesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EN510445\SQLEXPRESS;Initial Catalog=Movies2;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new FinanceConfiguration());

            //modelBuilder.Entity<RatingEntity>().HasKey(x => new { x.MovieId, x.UserId });
            //modelBuilder.Entity<CommentEntity>().HasKey(x => new { x.MovieId, x.UserId });
            //modelBuilder.Entity<WatchlistEntity>().HasKey(x => new { x.MovieId, x.UserId });
            //modelBuilder.Entity<MovieGenreEntity>().HasKey(x => new { x.MovieId, x.GenreId });
            //modelBuilder.Entity<PersonRoleMovieEntity>().HasKey(x => new { x.MovieId, x.PersonId, x.RoleId });
        }

        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<FinanceEntity> Finances { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<MovieGenreEntity> MovieGenres { get; set; }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<PersonRoleMovieEntity> PersonRoleMovies { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<Domain.TypeEntity> Types { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<WatchlistEntity> Watchlists { get; set; }
    }
}
