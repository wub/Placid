using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Placid
{
    /// <summary>
    /// Wraps the default request handler with policies defined in the <see cref="Policies" /> class.
    /// </summary>
    public class PolicyHandler : DelegatingHandler
    {
        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Policies.PolicyStrategy.ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
        }
    }
}
