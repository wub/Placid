using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Placid.Layers;

namespace Placid
{
    /// <summary>
    /// An image generation request, sent to the Placid API.
    /// https://placid.app/docs/2.0/rest/generate-images#request
    /// </summary>
    public class TemplateRequest
    {
        /// <summary>
        /// The UUID of the template that should be used.
        /// This is found in the purple pill on the "templates" overview page of your project.
        /// </summary>
        [Required, JsonIgnore]
        public string? TemplateUuid { get; set; }

        /// <summary>
        /// After the image is created, Placid will POST the response to this URL.
        /// </summary>
        [Url, JsonProperty("webhook_success")]
        public Uri? WebhookSuccess { get; set; }

        /// <summary>
        /// <para>
        /// Whether to process the image immediately, or to put it in a queue.
        /// If this is false (default), you need to define either a <see cref="WebhookSuccess" /> URL,
        /// or poll the <see cref="TemplateResponse.PollingUrl" /> that gets returned in the <see cref="TemplateResponse" /> 
        /// of a <see cref="PlacidClient.GenerateImage(TemplateRequest)" /> request.
        /// </para>
        /// <para>
        /// This might fail if your worker is too busy or if you start too many simultaneous requests -
        /// check the rate limit: https://placid.app/docs/2.0/rest/rate-limit
        /// </para>
        /// </summary>
        [JsonProperty("create_now")]
        public bool CreateNow { get; set; }

        /// <summary>
        /// This string will be saved and sent in any subsequent webhook requests for this image.
        /// </summary>
        // TODO: Handle arrays.
        // TODO: Investigate how this actually works and improve documentation.
        [StringLength(1024), JsonProperty("passthrough")]
        public string? Passthrough { get; set; }

        /// <summary>
        /// A dictionary of layers, where the key is the layer name. This allows you to dynamically
        /// change the properties of the image layers in the template specified by the <see cref="TemplateUuid" />.
        /// </summary>
        [JsonProperty("layers")]
        public IDictionary<string, Layer> Layers { get; set; } = new Dictionary<string, Layer>();

        /// <summary>
        /// If these are configured, Placid will transfer the generated image to cloud storage.
        /// </summary>
        [JsonProperty("transfer")]
        public TransferOptions? TransferOptions { get; set; }
    }
}
