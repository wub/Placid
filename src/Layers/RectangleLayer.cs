using Newtonsoft.Json;

namespace Placid.Layers
{
    public class RectangleLayer : Layer
    {
        [HexCode, JsonProperty("background_color")]
        public string? BackgroundColor { get; set; }

        [HexCode, JsonProperty("border_color")]
        public string? BorderColor { get; set; }

        [JsonProperty("border_radius")]
        public uint? BorderRadius { get; set; }

        [JsonProperty("border_width")]
        public uint? BorderWidth { get; set; }
    }
}
