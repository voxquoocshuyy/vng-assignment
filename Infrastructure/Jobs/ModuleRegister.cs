using Application.Features.Users;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Infrastructure.Jobs;

public static class ModuleRegister
{
    [Obsolete("Obsolete")]
    public static void RegisterQuartz(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory(opt =>
            {
                opt.AllowDefaultConstructor = true;
            });
            var startUpdatePassword = new JobKey("UpdatePasswordStatusJob", "UserGroup");
            
            q.AddJob<UpdatePasswordStatusJob>(o => o.WithIdentity(startUpdatePassword));
            
            q.AddTrigger(opts => opts.ForJob(startUpdatePassword)
                .WithIdentity("UpdatePasswordStatusTrigger")
                //0h0m0s every day
                // .WithCronSchedule("0 0 0 ? * *"));
                //every minute
                .WithCronSchedule("0 * * ? * *"));
            
            q.InterruptJobsOnShutdown = true;
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        services.AddTransient<IJob, UpdatePasswordStatusJob>();
    }
}