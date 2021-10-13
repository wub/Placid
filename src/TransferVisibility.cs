namespace Placid
{
    public class TransferVisibility
    {
        public static TransferVisibility Public { get; }

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

        public static implicit operator string(TransferVisibility transferVisibility) => transferVisibility.Value;
    }
}
