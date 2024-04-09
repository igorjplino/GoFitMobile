using CommunityToolkit.Maui;
using GoFitMobile.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GoFitMobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //var config = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("GoFitMobile.appsettings.json");

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

        builder.Configuration.AddConfiguration(config);

        builder.Services.AddApplicationService(builder.Configuration);

#if DEBUG
#if ANDROID
        builder.Logging
            .AddDebug()
            .AddConsole()
            .AddProvider(new AndroidLoggerProvider())
            .AddFilter("GoFitMobile", LogLevel.Debug);
#else
        builder.Logging
            .AddDebug()
            .AddConsole();   
#endif
#endif

        return builder.Build();
    }
}
