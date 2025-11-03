using GCConnect.Common.Constants;
using GCConnect.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Okta.AspNetCore;

namespace GCConnect.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Okta authentication for Web API
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            })
            .AddOktaWebApi(new OktaWebApiOptions()
            {
                OktaDomain = configuration["Okta:OktaDomain"],
                AuthorizationServerId = configuration["Okta:AuthorizationServerId"],
                Audience = configuration["Okta:Audience"],
            });


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(o =>
            {
                // o.SwaggerDoc("v1", new() { Title = "Task Management API", Version = "v1" });

                // Add Bearer token support for Swagger UI
                o.AddSecurityDefinition(OktaDefaults.ApiAuthenticationScheme, new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Authorization: Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddDbContext<GCConnectDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Sql"), sql =>
                {
                    sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    sql.MigrationsAssembly(typeof(GCConnectDbContext).Assembly.GetName().Name);
                });
            });


            services.AddCors(options =>
            {
                options.AddPolicy(name: Cors.DefaultCorsPolicyName,
                    policy =>
                    {
                        // Read the allowed origins from appsettings.json
                        var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
                        if (allowedOrigins != null && allowedOrigins.Length > 0)
                        {
                            policy.WithOrigins(allowedOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    });
            });


            return services;
        }

    }
}
