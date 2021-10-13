using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Placid.Layers
{
    public class BrowserFrameLayer : Layer
    {
        /// <summary>
        /// If a URL to an image is passed, Placid will download and insert the image.
        /// If a URL to a web page is passed, Placid will screenshot it, and then insert it.
        /// </summary>
        [Url, Required, JsonProperty(Required = Required.Always)]
        public Uri? Image { get; set; }

        /// <summary>
        /// The width of the viewport to use for screenshots.
        /// </summary>
        [JsonIgnore]
        public uint? ScreenshotViewportWidth { get; set; }

        /// <summary>
        /// The height of the viewport to use for screenshots.
        /// </summary>
        [JsonIgnore]
        public uint? ScreenshotViewportHeight { get; set; }

        [JsonProperty("image_viewport")]
        public string? ScreenshotViewport =>  
            ScreenshotViewportWidth != null && ScreenshotViewportHeight != null
                ? $"{ScreenshotViewportWidth}x{ScreenshotViewportHeight}"
                : null;

        [Url, JsonProperty("url")]
        public string? BrowserBarUrl { get; set; }
    }
}
