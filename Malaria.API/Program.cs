using API.Startup;
using Common.Contants;
using EfCoreLayer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

// add logging support
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
StartupHelper.BindServices(builder);

// if db source not set, throw an exception or set to some default
string dataSourceType = DBSourceValues.InMemory;
bool dataSourceTypeSpecified = false;
if (builder.Configuration[DBConstants.DBSource] != null)
{
    dataSourceType = builder.Configuration[DBConstants.DBSource];
    dataSourceTypeSpecified = true;
}

// use InMemory DB for quick prototyping
if (dataSourceType == DBSourceValues.InMemory)
{
    StartupHelper.ConfigureInMemoryData(builder);
}
else
{
    if (builder.Configuration[DBConstants.DBServer] == null || builder.Configuration[DBConstants.DBInstance] == null ||
        builder.Configuration[DBConstants.DBUser] == null || builder.Configuration[DBConstants.DBPassword] == null)
    {
        throw new Exception("One or more of the properties needed to configure the database was not set.");
    }
    // configure server database, local or cloud
    StartupHelper.ConfigureServerDatabase(builder);
}

StartupHelper.ConfigureCORS(builder);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options => StartupHelper.SetUpOpenApiInfo(builder, options));


var app = builder.Build();

if (!dataSourceTypeSpecified)
{
    app.Logger.LogInformation("Starting app. [DataSourceType] property was not found, using default: InMemory - " + DateTime.Now);
}

if (dataSourceType == DBSourceValues.InMemory)
{ 
    app.Logger.LogInformation(string.Format("Using {0} Db instance: {1}  - {2}", builder.Configuration[DBConstants.DBSource],
           builder.Configuration[DBConstants.DBInstance], DateTime.Now));
}
else
{
    app.Logger.LogInformation("Starting app using " + builder.Configuration[DBConstants.DBSource] + " database - " + DateTime.Now);
    app.Logger.LogInformation(string.Format(DBConstants.ConnectionStringTemplate,
            builder.Configuration[DBConstants.DBServer], builder.Configuration[DBConstants.DBInstance], "********", "********"));
}

if (!string.IsNullOrEmpty(builder.Configuration[CorsConfig.CORS_ALLOWED_DOMAIN_KEY]))
{
    app.Logger.LogInformation($"CORS KNOWN DOMAINS: {builder.Configuration[CorsConfig.CORS_ALLOWED_DOMAIN_KEY]}");
    app.Logger.LogInformation($"Currently allowing requests from localhost port: {builder.Configuration[CorsConfig.CORS_ALLOWED_DOMAIN_KEY]}");
}


if (!string.IsNullOrEmpty(builder.Configuration[CorsConfig.CORS_ALLOWED_METHODS_KEY]))
{
    app.Logger.LogInformation($"CORS KNOWN DOMAINS: {builder.Configuration[CorsConfig.CORS_ALLOWED_METHODS_KEY]}");
    app.Logger.LogInformation($"no config was found to configure cross domain requests, default: {builder.Configuration[CorsConfig.CORS_ALLOWED_METHODS_KEY]}");
}

// seed the database if using InMemory
StartupHelper.SeedDatabase(builder, app);


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(CorsConfig.CORS_POLICY_ALLOWS_KNOWN_ORIGINS);
app.UseAuthorization();

app.MapControllers();

app.Logger.LogInformation("Calling app.Run()...  " + DateTime.Now);

app.Start();

var server = app.Services.GetService<IServer>();

// get address that the server is running on 
var serverAddress = server?.Features.Get<IServerAddressesFeature>();
if (serverAddress != null)
{
    Console.WriteLine("App is listening on:");
    serverAddress.Addresses.ToList<string>().ForEach(a => Console.WriteLine(a));
}

app.WaitForShutdown();