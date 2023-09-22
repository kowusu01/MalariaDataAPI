
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Common.Contants;
using EfCoreLayer.Seeding;

using EfCoreLayer.WorldInfo;
using Services.Queries;

using DataAccess;
using Services.HealthCheck;
using BusinessQueries.TaskRunners.WorldInfo;
using BusinessQueries.Tasks.WorldInfo;
using QueryServices.Interfaces;

namespace API.Startup
{
    public class StartupHelper
    {

        public static void ConfigureCORS(WebApplicationBuilder builder)
        {
            
            string configKnownDomains = builder.Configuration[CorsConfig.CORS_ALLOWED_DOMAIN_KEY];
            string configAllowedMethods = builder.Configuration[CorsConfig.CORS_ALLOWED_METHODS_KEY];
            if (!string.IsNullOrEmpty(configKnownDomains))
            {
                var knownDomains = configKnownDomains.Split(new char[] {';'});
                var allowedMethods = configAllowedMethods.Split(new char[] { ';' });
                var policyName = CorsConfig.CORS_POLICY_ALLOWS_KNOWN_ORIGINS;

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy(name: policyName,
                                      builder =>
                                      {
                                          builder
                                           //.WithOrigins(knownDomains)
                                           //.WithMethods(allowedMethods)
                                            .AllowAnyMethod()
                                            .AllowAnyOrigin()
                                           .AllowAnyHeader();

                                      });
                });
            }
        }
        /// <summary>
        /// The only parameter needed to setup InMemory database is the DB instance name, an empty database will be created at runtime 
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureInMemoryData(WebApplicationBuilder builder)
        {
            string dbInstance = builder.Configuration[DBConstants.DBInstance] ?? DBSourceValues.DefaultDbInstance;
           
            builder.Services.AddDbContext<WorlInfoApiDbContext>(options =>
            options
             .UseInMemoryDatabase(dbInstance) // all we need is db instance name
             .EnableSensitiveDataLogging()  // for debugging and development ONLY!
             .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            );
        }

        /// <summary>
        /// configures any database with a standard connection string
        /// in this case, we are just using postgres (UseNpgsql)
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureServerDatabase(WebApplicationBuilder builder)
        {
            // we are using Postgres, we just need to figure out where the config is coming from
            // use local postgres instance hosted by docker, read config from app settings, no big deal
            
            // now build the connection string
            string connectionString = string.Format(DBConstants.ConnectionStringTemplate, builder.Configuration[DBConstants.DBServer],
                builder.Configuration[DBConstants.DBInstance], builder.Configuration[DBConstants.DBUser], builder.Configuration[DBConstants.DBPassword]);

            // configure the db context
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<WorlInfoApiDbContext>(options =>
                    options
                        .UseNpgsql(connectionString)
                        .UseSnakeCaseNamingConvention() // allows table name like customer_order to become CustomerOrder in the model
                        .EnableSensitiveDataLogging()   // use this for debugging and development ONLY!
                );
            }
            else
            {
                builder.Services.AddDbContext<WorlInfoApiDbContext>(options =>
                    options
                        .UseNpgsql(connectionString)
                        .UseSnakeCaseNamingConvention() // allows table name like customer_order to become CustomerOrder in the model
                );
            }

        }

        public static void SetUpOpenApiInfo(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "",
                Title = "World Facts Api",
                Description = "A simple API for serving world countries, and information related to World Health Organization Malaria data."
            });
        }

        public static void SeedDatabase(WebApplicationBuilder builder, WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            app.Logger.LogInformation("Seeding database..." + DateTime.Now);
            var services = scope.ServiceProvider;

            // retrieve the dbcontext object from the DI
            
            var dbContext = services.GetRequiredService<WorlInfoApiDbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Seeding.CreateCountryListAsync(dbContext, builder.Configuration[EnvironmentConstants.Name], builder.Configuration[EnvironmentConstants.Descr]);
            app.Logger.LogInformation("Done seeding InMemory database.  - " + DateTime.Now);
        }

        public static void BindServices(WebApplicationBuilder builder)
        {
            // services
            builder.Services.AddScoped<ICountriesQueryService, CountriesQueryService>();
            
            // task runners
            builder.Services.AddScoped<ICountriesQueryTaskRunner, CountriesQueryTaskRunner>();
            
            // tasks
            builder.Services.AddScoped<ICountriesQueryTask, CountriesQueryTask>();
            
            // data access
            builder.Services.AddScoped<IDataAccessCountries, DataAccessCountries>();

            // healthcheck
            builder.Services.AddScoped<IHealthCheckInterface, WorldInfoApiHealthCheckService>();
            
        }
    }    
}
