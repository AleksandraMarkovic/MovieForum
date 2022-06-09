using BusinessLogic.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class ConfigurationValidators
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<AddGenreValidation>();
            services.AddTransient<UpdateGenreValidation>();
            services.AddTransient<AddMovieValidation>();
            services.AddTransient<UpdateMovieValidation>();
            services.AddTransient<AddUserValidation>();
            services.AddTransient<UpdateUserValidation>();
            services.AddTransient<AddCountryValidation>();
            services.AddTransient<UpdateCountryValidation>();
            services.AddTransient<CommentValidation>();
            services.AddTransient<RatingValidation>();
            services.AddTransient<WatchlistValidation>();
            services.AddTransient<AddRoleValidation>();
            services.AddTransient<UpdateRoleValidation>();
            services.AddTransient<PersonValidation>();
            services.AddTransient<AddTypeValidation>();
            services.AddTransient<UpdateTypeValidation>();
        }
    }
}
