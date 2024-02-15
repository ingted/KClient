using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryServerStartSession : IRmQuery<KbQueryServerStartSessionReply>
    {
        public KbQueryServerStartSession()
        {
        }
    }

    public class KbQueryServerStartSessionReply : KbBaseActionResponse, IRmQueryReply
    {
        public DateTime? ServerTimeUTC { get; set; }
        public Guid ConnectionId { get; set; }
        public ulong ProcessId { get; set; }
    }
}
