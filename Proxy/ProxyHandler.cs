using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Proxy
{
    public class ProxyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            UriBuilder forwardUri = new UriBuilder(request.RequestUri);
            var relativePath = forwardUri.Path.ToLower();
            //have to explicitly null it to avoid protocol violation
            if (request.Method == HttpMethod.Get)
                request.Content = null;
            //We can retrive hosts and ports from config files, 
            //so we can handle diferent ambients, like testing production and development.
            if (relativePath.StartsWith("/api/user"))
            {                
                forwardUri.Port = 5000;
                forwardUri.Host = "localhost";//Users web service host;
            }
            else
            {
                forwardUri.Port = 4000;
                forwardUri.Host = "localhost";//CareOptimizationServiecs host;
            }

            //send it on to the requested URL
            request.RequestUri = forwardUri.Uri;
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return response;
        }
    }
}