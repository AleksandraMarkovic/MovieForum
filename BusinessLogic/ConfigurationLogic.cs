using BusinessLogic.Implementation;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class ConfigurationLogic
    {
        public static void AddLogic(this IServiceCollection services)
        {
            services.AddTransient<IGenreLogic, GenreLogic>();
            services.AddTransient<ICountryLogic, CountryLogic>();
            services.AddTransient<ITypeLogic, TypeLogic>();
            services.AddTransient<IMovieLogic, MovieLogic>();
            services.AddTransient<IRoleLogic, RoleLogic>();
            services.AddTransient<IPersonLogic, PersonLogic>();
            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<ICommentLogic, CommentLogic>();
            services.AddTransient<IWatchlistLogic, WatchlistLogic>();
            services.AddTransient<IRateLogic, RateLogic>();
        }
    }
}
