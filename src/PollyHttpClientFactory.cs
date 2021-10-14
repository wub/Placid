using System.Net.Http;
using Flurl.Http.Configuration;

namespace Placid
{
    /// <summary>
    /// Applies a custom message handler to ensure policies in <see cref="Policies" /> are applied.
    /// </summary>
    public class PollyHttpClientFactory : DefaultHttpClientFactory
    {
        ///
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new PolicyHandler
            {
                InnerHandler = base.CreateMessageHandler()
            };
        }
    }
}
