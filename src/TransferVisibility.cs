namespace Placid
{
    /// <summary>
    /// Visibility setting for files that have been transferred to a <see cref="TransferTarget" />.
    /// </summary>
    public class TransferVisibility
    {
        /// <summary>
        /// Allow public access to the generated images.
        /// </summary>
        public static TransferVisibility Public { get; }

        /// <summary>
        /// Don't allow public access to the generated images.
        /// </summary>
        public static TransferVisibility Private { get; }

        static TransferVisibility()
        {
            Public = new TransferVisibility("public");
            Private = new TransferVisibility("private");
        }

        private TransferVisibility(string value)
        {
            Value = value;
        }

        private string Value { get; set; }

        ///
        public static implicit operator string(TransferVisibility transferVisibility) => transferVisibility.Value;
    }
}
