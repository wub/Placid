using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Placid
{
    /// <summary>
    /// Options that specify where Placid should store the generated image.
    /// </summary>
    public class TransferOptions
    {
        /// <summary>
        /// The storage target. Currently only AWS S3 is supported.
        /// </summary>
        [Required, JsonProperty("to", Required = Required.Always)]
        public TransferTarget To { get; set; } = TransferTarget.S3;

        /// <summary>
        /// Your AWS access key.
        /// </summary>
        [Required, JsonProperty("key", Required = Required.Always)]
        public string? Key { get; set; }

        /// <summary>
        /// Your AWS secret.
        /// </summary>
        [Required, JsonProperty("secret", Required = Required.Always)]
        public string? Secret { get; set; }

        /// <summary>
        /// Whether the resulting image should be public or private. This defaults to private.
        /// </summary>
        [Required, JsonProperty("visibility")]
        public TransferVisibility Visibility { get; set; } = TransferVisibility.Private;

        /// <summary>
        /// The full image path starting from the root directory of your bucket, including filename 
        /// and file extension. Placid will overwrite existing files in the specified directory.
        /// </summary>
        public string? Path { get; set; }
    }
}
