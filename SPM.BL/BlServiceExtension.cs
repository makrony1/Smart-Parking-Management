using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPM.BL.Interfaces;
using SPM.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.BL
{
    public static class BlServiceExtension
    {
        public static void AddBlServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IParkService, ParkService>();
            services.AddTransient<IReportService, ReportService>();
        }
    }
}
