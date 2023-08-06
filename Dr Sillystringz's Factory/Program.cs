using Dr_Sillystringz_s_Factory.Models;
using Dr_Sillystringzs_Factory.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dr_Sillystringz_s_Factory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Apply any pending database migrations on application startup
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<FactoryDbContext>();
                dbContext.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Add the required services for controllers
                        services.AddControllers();

                        // Add the DbContext to the service collection
                        services.AddDbContext<FactoryDbContext>(options =>
                        {
                            IConfiguration configuration = hostContext.Configuration;
                            string connectionString = configuration.GetConnectionString("DefaultConnection");
                            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
                        });
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            // Map the controllers
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
