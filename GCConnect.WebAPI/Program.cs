using GCConnect.WebAPI.Extensions;

namespace GCConnect.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Register services in the extension method and keep Program.cs clean
            builder.Services.ConfigureServices(builder.Configuration);
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                await app.UseDevDatabaseAsync();   // migrations and seeds
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
