using Newtonsoft.Json;

namespace Placid
{
    public class TransferOptions
    {
        [JsonProperty("to")]
        public TransferTarget To { get; set; } = TransferTarget.S3;

        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("secret")]
        public string? Secret { get; set; }

        /// <summary>
        /// Whether the resulting image should be public or private. This defaults to private.
        /// </summary>
        [JsonProperty("visibility")]
        public TransferVisibility Visibility { get; set; } = TransferVisibility.Private;

        public string? Path { get; set; }
    }
}
