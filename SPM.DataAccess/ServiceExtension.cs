using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess
{
    public static class ServiceExtension
    {
        public static void AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SPMDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        }
    }
}
