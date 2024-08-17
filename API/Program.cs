using API.Extensions;
using Application;
using Infrastructure;
using Infrastructure.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add database services
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Host.AddAppConfigurations();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddService();
builder.Services.AddConfigurationSettings(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterQuartz();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();