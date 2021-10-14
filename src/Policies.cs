using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Bulkhead;
using Polly.Retry;
using Polly.Timeout;
using Polly.Wrap;

namespace Placid
{
    /// <summary>
    /// A collection of policies used by this library to ensure that
    /// transient errors are handled when dealing with the Placid API.
    /// </summary>
    public static class Policies
    {
        private static AsyncTimeoutPolicy<HttpResponseMessage> TimeoutPolicy => Policy
            .TimeoutAsync<HttpResponseMessage>(60, (context, timeSpan, task) =>
            {
                Debug.WriteLine($"[Placid|Policy]: Timeout delegate fired after {timeSpan.TotalSeconds} seconds.");
                return Task.CompletedTask;
            });

        private static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy => Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(5),
            },
            (delegateResult, retryCount) =>
            {
                Debug.WriteLine($"[Placid|Policy] Retry delegate fired, attempt {retryCount}.");
            });

        private static AsyncBulkheadPolicy<HttpResponseMessage> BulkheadPolicy => Policy
            .BulkheadAsync<HttpResponseMessage>(2, 1024, context =>
            {
                Debug.WriteLine($"[Placid|Policy] Bulkhead delegate fired.");
                return Task.CompletedTask;
            });

        /// <summary>
        /// This strategy mitigates issues when dealing with the Placid API. It will:
        /// handle timeouts, automatic retries, and prevent the client from executing
        /// more than 2 requests at any one time (Placid API limit).
        /// </summary>
        public static AsyncPolicyWrap<HttpResponseMessage> PolicyStrategy => Policy
            .WrapAsync(BulkheadPolicy, RetryPolicy, TimeoutPolicy);
    }
}
