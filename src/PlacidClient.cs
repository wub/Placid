using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Placid
{
    public static class PlacidClient
    {
        private static string? _apiKey;

        public static void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public static async Task<TemplateResponse> GenerateImage(this TemplateRequest templateRequest)
        {
            var response = await "https://placid.app/api/rest"
                .WithHeader("User-Agent", "Placid")
                .WithOAuthBearerToken(_apiKey)
                .AppendPathSegment(templateRequest.TemplateUuid)
                .PostJsonAsync(templateRequest)
                .ReceiveJson<TemplateResponse>();

            return response;
        }
    }
}
