using System.Reflection;
using Application.Services.MailServices;
using FluentValidation;
using Infrastructure.Services.MailServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services.AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly());

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<ISmtpEmailService, SmtpEmailService>();
        return services;
    }
}