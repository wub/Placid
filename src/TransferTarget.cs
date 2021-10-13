namespace Placid
{
    /// <summary>
    /// A target to which Placid will transfer generated images.
    /// </summary>
    public class TransferTarget
    {
        /// <summary>
        /// Transfer the generated images to an AWS S3 bucket.
        /// </summary>
        public static TransferTarget S3 { get; }

        static TransferTarget()
        {
            S3 = new TransferTarget("s3");
        }

        private TransferTarget(string value)
        {
            Value = value;
        }

        private string Value { get; set; }

        ///
        public static implicit operator string(TransferTarget transferTarget) => transferTarget.Value;
    }
}
