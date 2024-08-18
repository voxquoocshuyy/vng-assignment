using API.Extensions;
using Application;
using Infrastructure;
using Infrastructure.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Host.AddAppConfigurations();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddService();
builder.Services.AddConfigurationSettings(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterQuartz();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfigurationSwagger();
builder.Services.AddConfigurationFilterService();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();