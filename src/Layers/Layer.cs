using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Placid.Layers
{
    /// <summary>
    /// Base layer properties.
    /// </summary>
    public abstract class Layer
    {
        /// <summary>
        /// If Hide is set to true, the layer will be hidden. Defaults to false.
        /// </summary>
        public bool Hide { get; set; }

        /// <summary>
        /// The horizontal position of the layer.
        /// </summary>
        public string? PositionX { get; set; }

        /// <summary>
        /// The vertical position of the layer.
        /// </summary>
        public string? PositionY { get; set; }

        /// <summary>
        /// The width of the layer. You can use either relative or absolute sizing:
        /// <para>
        /// Relative: "+10px" - add 10px to the width. "-10px" - remove 10px from the width.
        /// </para>
        /// <para>
        /// Absolute: "10px" - set width to 10px. "50%" - set width to 50% of default layer width.
        /// </para>
        /// </summary>
        public string? Width { get; set; }

        /// <summary>
        /// The height of the layer. You can use either relative or absolute sizing:
        /// <para>
        /// Relative: "+10px" - add 10px to the height. "-10px" - remove 10px from the height.
        /// </para>
        /// <para>
        /// Absolute: "10px" - set height to 10px. "50%" - set height to 50% of default layer height.
        /// </para>
        /// </summary>
        public string? Height { get; set; }
    }
}
