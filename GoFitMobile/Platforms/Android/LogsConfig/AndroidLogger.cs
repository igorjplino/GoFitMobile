using Microsoft.Extensions.Logging;

namespace GoFitMobile;

public class AndroidLogger : ILogger
{
    private readonly string Category;

    public IDisposable BeginScope<TState>(TState state) => null!;

    public bool IsEnabled(LogLevel logLevel) => true;

    public AndroidLogger(string category)
    {
        Category = category;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string message = formatter(state, exception);

        var throwable = new Java.Lang.Throwable();

        if (exception is not null)
        {
            throwable = Java.Lang.Throwable.FromException(exception);
        }

        switch (logLevel)
        {
            case LogLevel.Trace:
                Android.Util.Log.Verbose(Category, throwable, message);
                break;

            case LogLevel.Debug:
                Android.Util.Log.Debug(Category, throwable, message);
                break;

            case LogLevel.Information:
                Android.Util.Log.Info(Category, throwable, message);
                break;

            case LogLevel.Warning:
                Android.Util.Log.Warn(Category, throwable, message);
                break;

            case LogLevel.Error:
                Android.Util.Log.Error(Category, throwable, message);
                break;

            case LogLevel.Critical:
                Android.Util.Log.Wtf(Category, throwable, message);
                break;
        }
    }
}
