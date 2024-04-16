using System.Net.Http;

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
            client = GetPlatformMessageHandler();
#else
            client = new HttpClient();
#endif

            client.BaseAddress = new Uri(_baseUrl);
        }

        return client;
    }

    private HttpClient GetPlatformMessageHandler()
    {
#if ANDROID
        var handler = new Xamarin.Android.Net.AndroidMessageHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert != null && cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        return new HttpClient(handler);
#elif IOS
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = IsHttpsLocalhost
        };
        return new HttpClient(handler);
#elif WINDOWS
        return new HttpClient();
#else
        throw new PlatformNotSupportedException("Not supported platform.");
        
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
