using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Placid.Layers;

namespace Placid
{
    public class TemplateRequest
    {
        [Required, JsonIgnore]
        public string? TemplateUuid { get; set; }

        [Url]
        public Uri? WebhookSuccess { get; set; }

        public bool CreateNow { get; set; }

        // TODO: Handle arrays.
        [StringLength(1024)]
        public string? Passthrough { get; set; }

        /// <summary>
        /// A dictionary of layers, where the key is the layer name.
        /// </summary>
        public IDictionary<string, Layer> Layers { get; set; } = new Dictionary<string, Layer>();
    }
}
