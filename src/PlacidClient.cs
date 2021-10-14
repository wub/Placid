using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Placid
{
    /// <summary>
    /// A client that interacts with the Placid service.
    /// </summary>
    public class PlacidClient
    {
        private readonly string? _apiToken;

        /// <inheritdoc cref="PlacidClient" />
        /// <param name="apiToken">
        /// Your "Private Token" API token for Placid. Found in project settings.
        /// This usually starts with "placid-".
        /// </param>
        public PlacidClient(string apiToken)
        {
            _apiToken = apiToken;

            FlurlHttp.Configure(settings =>
            {
                settings.HttpClientFactory = new PollyHttpClientFactory();
            });
        }

        /// <summary>
        /// Generates an image with the Placid service.
        /// </summary>
        /// <returns>A <see cref="TemplateResponse" /> with image generation details.</returns>
        public async Task<TemplateResponse> GenerateImage(TemplateRequest templateRequest)
        {
            var response = await "https://placid.app/api/rest"
                .WithHeader("User-Agent", "Placid (+https://github.com/wub/Placid)")
                .WithOAuthBearerToken(_apiToken)
                .AppendPathSegment(templateRequest.TemplateUuid)
                .PostJsonAsync(templateRequest)
                .ReceiveJson<TemplateResponse>();

            return response;
        }
    }
}
