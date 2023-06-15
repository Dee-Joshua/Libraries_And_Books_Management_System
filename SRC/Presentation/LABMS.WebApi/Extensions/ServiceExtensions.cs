using LABMS.Application.Common;
using LABMS.Controller.ActionFilters;
using LABMS.Persistence.Common;
using LABMS.ServiceContract.Common;
using LABMS.ServiceRepository.Common;
using LoggerService;
using Microsoft.EntityFrameworkCore;

namespace LABMS.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option=>
            {
                option.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSQLServer(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        public static void ConfigureValidationActionFilter(this IServiceCollection services)=> services.AddScoped<ValidationFilterAttribute> ();
    }
}
 