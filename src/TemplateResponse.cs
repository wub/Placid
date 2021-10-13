using System;
using Newtonsoft.Json;

namespace Placid
{
    /// <summary>
    /// An image generation response, returned from the Placid API.
    /// https://placid.app/docs/2.0/rest/generate-images#response
    /// </summary>
    public class TemplateResponse
    {
        /// <summary>
        /// A unique image ID for internal reference.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// A string representing the status of the request. Possible values are:
        /// <list>
        /// <item>
        ///     <term>"queued"</term>
        ///     <description>The image request is now queued for processing.</description>
        /// </item>
        /// <item>
        ///     <term>"finished"</term>
        ///     <description>The image request has successfully completed.</description>
        /// </item>
        /// <item>
        ///     <term>"error"</term>
        ///     <description>An error has occurred when servicing the image generation request.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; } // queued, finished, error

        /// <summary>
        /// If <see cref="TemplateRequest.CreateNow" /> is true, and <see cref="Status" /> is "finished", this will
        /// be a URL to the generated image. If <see cref="Status" /> is "queued" or "error", this will be null.
        /// </summary>
        [JsonProperty("image_url")]
        public Uri? ImageUrl { get; set; }

        /// <summary>
        /// An endpoint that can be polled for status updates.
        /// </summary>
        [JsonProperty("polling_url")]
        public Uri? PollingUrl { get; set; }
    }
}
