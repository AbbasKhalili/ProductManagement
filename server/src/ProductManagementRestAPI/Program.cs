using Autofac;
using Autofac.Extensions.DependencyInjection;
using ProductManagement.Bootstrap;
using ProductManagement.Migration;
using ProductManagementRestAPI;
using ProductManagementRestAPI.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var hostConfig = new HostConfig();
builder.Configuration.Bind("HostConfig", hostConfig);
builder.Services.Configure<HostConfig>(builder.Configuration.GetSection("HostConfig"));


builder.Services.AddHealthChecks();

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddModule(hostConfig.DBConnection));

builder.Services.AddFluentMigrator(hostConfig.DBConnection, typeof(_0001_Products).Assembly);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetAutofacRoot().RunMigration();

if (!app.Environment.IsDevelopment())
    app.ConfigGravityExceptionMiddleware(ExceptionsResource.ResourceManager);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
