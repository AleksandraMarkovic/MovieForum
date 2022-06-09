using Application.Repositories;
using Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public static class Configuration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IWatchlistRepository, WatchlistRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
        }
    }
}
