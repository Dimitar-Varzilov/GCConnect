using GCConnect.Services.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.WebAPI.Extensions
{
	public static class ServiceExtensions
	{
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["Okta:Authority"];
                    options.Audience = configuration["Okta:Audience"];
                });
            services.AddControllers();
            
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();
            services.AddDbContext<GCConnectDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Sql"), sql =>
                {
                    sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    sql.MigrationsAssembly(typeof(GCConnectDbContext).Assembly.GetName().Name);
                });
            });

            return services;
        }

    }
}
