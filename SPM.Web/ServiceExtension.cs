using SPM.DataAccess;

namespace SPM.Web
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
