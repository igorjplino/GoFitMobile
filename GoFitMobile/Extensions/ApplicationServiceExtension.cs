using GoFitMobile.Data;
using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using GoFitMobile.Pages;
using GoFitMobile.Pages.WorkoutPlans;
using GoFitMobile.Services;
using GoFitMobile.ViewModel;
using Microsoft.Extensions.Configuration;

namespace GoFitMobile.Extensions;
public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        services.AddSingleton(_ =>
        {
            var handler = new HttpsClientHandler(configuration.GetSection("AppSettings")["GoFitApiUrl"]);

            return handler.GetHttpClient();
        });

        services.AddScoped<MainPage>();
        services.AddScoped<HomePage>();

        services.AddScoped<WorkoutPlansPage>();
        services.AddScoped<WorkoutPlanViewModel>();

        services.AddScoped<CreateWorkoutPlanPage>();
        services.AddScoped<CreateWorkoutPlanViewModel>();

        services.AddScoped<CreateWorkoutPage>();
        services.AddScoped<CreateWorkoutViewModel>();

        services.AddScoped<IWorkoutService, WorkoutService>();

        return services;
    }
}
