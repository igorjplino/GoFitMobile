namespace GoFitMobile.Data;

public class HttpsClientHandler
{
    private HttpClient? client;
    private readonly string _baseUrl;

    public HttpsClientHandler(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public HttpClient GetHttpClient()
    {
        if (client is null)
        {
#if DEBUG
            client = new HttpClient(GetPlatformMessageHandler());
#else
            client = new HttpClient();
#endif
        }

        return client;
    }

    private HttpMessageHandler GetPlatformMessageHandler()
    {
#if ANDROID
        var handler = new Xamarin.Android.Net.AndroidMessageHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert != null && cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        return handler;
#elif IOS
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = IsHttpsLocalhost
        };
        return handler;
#else
        throw new PlatformNotSupportedException("Only Android and iOS supported.");
#endif
    }

#if IOS
    public bool IsHttpsLocalhost(NSUrlSessionHandler sender, string url, Security.SecTrust trust)
    {
        if (url.StartsWith(_baseUrl))
            return true;
        return false;
    }
#endif


}
