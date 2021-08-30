using System.IO;
using System.Text.Json.Serialization;
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
            var secretsDirectory = System.Environment.GetEnvironmentVariable(Constants.ENV_KEY__SECRETS_DIRECTORY) ?? Constants.ENV_DEFAULT__SECRETS_DIRECTORY;
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
                    Path.Combine(Constants.DEV__SECRETS_DIRECTORY_RELATIVE)
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
            // services.AddMvc()
            //     .AddJsonOptions(
            //         options => options.JsonSerializerOptions.ReferenceHandler = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //     );

            services.AddMvc().AddJsonOptions(
                opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
            );

            services.AddDbContext<ApiContext>(opt =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = string.Format(
                        Constants.DEFAULT_CONNECTION_STRING,
                        Configuration.GetValue(Constants.CONF_KEY__DATABASE_HOSTNAME, Constants.CONF_DEFAULT__DATABASE_HOSTNAME),
                        Configuration.GetValue(Constants.CONF_KEY__DATABASE_PORT, Constants.CONF_DEFAULT__DATABASE_PORT),
                        Configuration.GetValue(Constants.CONF_KEY__DATABASE_DATABASE, Constants.CONF_DEFAULT__DATABASE_DATABASE),
                        Configuration.GetValue(Constants.CONF_KEY__DATABASE_USERNAME, Constants.CONF_DEFAULT__DATABASE_USERNAME),
                        Configuration.GetValue(Constants.CONF_KEY__DATABASE_PASSWORD, Constants.CONF_DEFAULT__DATABASE_PASSWORD)
                    );
                }

                opt.UseLazyLoadingProxies();

                opt.UseNpgsql(connectionString);

                opt.EnableSensitiveDataLogging(Configuration.GetValue("EnableSensitiveDataLogging", false));
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
