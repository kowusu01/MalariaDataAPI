﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Common.Contants;
using Common.Services;
using EfCoreLayer.Seeding;

using EfCoreLayer;
using Services.Queries;
using Business.QueryTasks;

using DataAccess;
using QueryServices.HealthTest;

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
                                           .WithOrigins(knownDomains)
                                           .WithMethods(allowedMethods)
                                            //.AllowAnyMethod()
                                            //.AllowAnyOrigin()
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
            string dbInstance = builder.Configuration[DBConstants.DBInstance] == null?
                DBSourceValues.DefaultDbInstance : builder.Configuration[DBConstants.DBInstance];
           
            builder.Services.AddDbContext<AppDbContext>(options =>
            options
             .UseInMemoryDatabase(builder.Configuration[DBConstants.DBInstance]) // all we need is db instance name
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
            builder.Services.AddDbContext<AppDbContext>(options =>
                options
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention() // allows table name like customer_order to become CustomerOrder in the model
                    .EnableSensitiveDataLogging()   // use this for debugging and development ONLY!
            );
        }

        public static void SetUpOpenApiInfo(WebApplicationBuilder builder, Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "",
                Title = "World Malaria Cases Api",
                Description = "A simple API for exploring malaria cases data, data loading, and quality  issues. \n Source: https://www.kaggle.com/datasets/imdevskp/malaria-dataset?select=reported_numbers.csv"                    
            });
        }

        public static void SeedDatabase(WebApplicationBuilder builder, WebApplication app)
        {
            if (builder.Configuration[DBConstants.DBSource] == DBSourceValues.InMemory)
            {
                using (var scope = app.Services.CreateScope())
                {
                    app.Logger.LogInformation("Seeding InMemory database..." + DateTime.Now);
                    var services = scope.ServiceProvider;

                    // retrieve the dbconext object from the DI
                    var dbContext = services.GetRequiredService<AppDbContext>();
                    Seeding.SeedMalariaDBAsync(dbContext, "DOTNET_CORE_INMEMORY_DB", "Simple, fast, reliable in-memory database for quick prototyping.");
                    app.Logger.LogInformation("Done seeding InMemory database.  - " + DateTime.Now);
                }
            }
        }

        public static void BindServices(WebApplicationBuilder builder)
        {
            // services
            builder.Services.AddScoped<IDataLoadQueryService, DataLoadQueryService>();
            builder.Services.AddScoped<ICompleteDataQueryService, CompleteDataQueryService>();
            builder.Services.AddScoped<IBadDataQueryService, BadDataQueryService>();
            builder.Services.AddScoped<IDataIssuesDetailsQueryService, DataIssuesDetailsQueryService>();

            // task runners
            builder.Services.AddScoped<IDataLoadQueryTaskRunner, DataLoadQueryTaskRunner>();
            builder.Services.AddScoped<ICompleteDataQueryTaskRunner, CompleteDataQueryTaskRunner>();
            builder.Services.AddScoped<IBadDataQueryTaskRunner, BadDataQueryTaskRunner>();
            builder.Services.AddScoped<IDataIssuesDetailsQueryTaskRunner, DataIssuesDetailsQueryTaskRunner>();
            
            // tasks
            builder.Services.AddScoped<IDataLoadQueryTask, DataLoadQueryTask>();
            builder.Services.AddScoped<ICompleteDataQueryTask, CompleteDataQueryTask>();
            builder.Services.AddScoped<IBadDataQueryTask, BadDataQueryTask>();
            builder.Services.AddScoped<IDataIssuesDetailsQueryTask, DataIssuesDetailsQueryTask>();

            // data access
            builder.Services.AddScoped<IDataAccessLoadStats, DataAccessLoadStats>();
            builder.Services.AddScoped<IDataAccessGoodData, DataAccessCompleteData>();

            builder.Services.AddScoped<IDataAccessBadData, DataAccessBadData>();
            builder.Services.AddScoped<IDataAccessDataIssuesDetails, DataAccessDataIssuesDetails>();

            builder.Services.AddScoped<IHealthCheckInterface, HealthCheckServicecs.HealthTestService>();
            //
        }
    }    
}
