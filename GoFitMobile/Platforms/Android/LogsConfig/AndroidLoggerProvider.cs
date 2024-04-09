using Microsoft.Extensions.Logging;

namespace GoFitMobile;
public class AndroidLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        int lastDotPos = categoryName.LastIndexOf('.');
        if (lastDotPos > 0)
        {
            categoryName = categoryName.Substring(lastDotPos + 1);
        }

        return new AndroidLogger(categoryName);
    }

    public void Dispose()
    {
       
    }
}
