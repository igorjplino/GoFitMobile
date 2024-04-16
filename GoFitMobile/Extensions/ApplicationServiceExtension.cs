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
#if WINDOWS
            var baseUrl = configuration.GetSection("AppSettings")["GoFitApiUrlWindows"];
#else
            var baseUrl = configuration.GetSection("AppSettings")["GoFitApiUrl"];
#endif
            var handler = new HttpsClientHandler(baseUrl);

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

        services.AddScoped<AddExerciseToWorkoutPage>();
        services.AddScoped<AddExerciseToWorkoutViewModel>();

        services.AddScoped<IWorkoutService, WorkoutService>();
        services.AddScoped<IExerciseService, ExerciseService>();

        return services;
    }
}
