using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SpeiderappAPI.Database;
using SpeiderappAPI.Utilities;

namespace SpeiderappAPI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true) //load local settings
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //load environment settings
                .AddJsonFile($"appsettings.{env.EnvironmentName}.local.json", optional: true) //load local environment settings
                .AddEnvironmentVariables();

            // Load secrets from the designated directory or using a default
            var secretsDirectory = System.Environment.GetEnvironmentVariable(Constants.EnvKeySecretsDirectory) ?? Constants.EnvDefaultSecretsDirectory;
            if (Directory.Exists(secretsDirectory))
            {
                // System.Console.WriteLine($"Adding secrets from {secretsDirectory}");
                builder.AddKeyPerFile(secretsDirectory); //load secrets
            }

            // If running in development-environment, check to see if any secrets should be loaded
            if (env.IsDevelopment())
            {
                var dir = Path.Combine(
                    Directory.GetParent(Directory.GetCurrentDirectory())?.FullName ?? Directory.GetCurrentDirectory(),
                    Path.Combine(Constants.DevSecretsDirectoryRelative)
                );
                if (Directory.Exists(dir))
                {
                    // System.Console.WriteLine($"Adding development secrets from {dir}");
                    builder.AddKeyPerFile(dir);
                }
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = string.Format(
                        Constants.DefaultConnectionString,
                        Configuration.GetValue(Constants.ConfKeyDatabaseHostname, Constants.ConfDefaultDatabaseHostname),
                        Configuration.GetValue(Constants.ConfKeyDatabasePort, Constants.ConfDefaultDatabasePort),
                        Configuration.GetValue(Constants.ConfKeyDatabaseDatabase, Constants.ConfDefaultDatabaseDatabase),
                        Configuration.GetValue(Constants.ConfKeyDatabaseUsername, Constants.ConfDefaultDatabaseUsername),
                        Configuration.GetValue(Constants.ConfKeyDatabasePassword, Constants.ConfDefaultDatabasePassword)
                    );
                }

                opt.UseLazyLoadingProxies();

                opt.UseNpgsql(connectionString);

                opt.EnableSensitiveDataLogging(Configuration.GetValue("EnableSensitiveDataLogging", false));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
