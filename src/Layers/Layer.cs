using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Placid.Layers
{
    public class Layer
    {
        [Required, JsonProperty(Required = Required.Always)]
        public string? LayerName { get; set; }

        public bool Hide { get; set; }

        public string? PositionX { get; set; }

        public string? PositionY { get; set; }

        public string? Width { get; set; }

        public string? Height { get; set; }
    }
}
