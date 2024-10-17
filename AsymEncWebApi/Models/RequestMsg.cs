namespace AsymEncWebApi.Models
{
    public class RequestMsg
    {
        public string MsgData { get; set; }
        public string Key { get; set; } = string.Empty;
    }

    public class RequestSig
    {
        public string MsgData { get; set; }
        public string? SigData { get; set; }
        public string Key { get; set; } = string.Empty;
    }

    public class KeysModel
    {
        public string privateKey { get; set; }
        public string? publicKey { get; set; }
    }
}
