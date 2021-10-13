namespace Placid
{
    public class TransferTarget
    {
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

        public static implicit operator string(TransferTarget transferTarget) => transferTarget.Value;
    }
}
