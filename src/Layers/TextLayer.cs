using Newtonsoft.Json;

namespace Placid.Layers
{
    /// <summary>
    /// A layer that shows text.
    /// </summary>
    public class TextLayer : Layer
    {
        /// <summary>
        /// Text content of the layer. Line breaks can be forced with \n.
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; set; }

        /// <summary>
        /// The color of the text, as a hex code (#FAFAFA).
        /// </summary>
        [HexCode, JsonProperty("text_color")]
        public string? TextColor { get; set; }
    }
}
