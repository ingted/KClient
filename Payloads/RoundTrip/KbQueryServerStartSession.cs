using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryServerStartSession : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }

        public KbQueryServerStartSession(Guid connectionId)
        {
            ConnectionId = connectionId;
        }
    }

    public class KbQueryServerStartSessionReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
        public DateTime? ServerTimeUTC { get; set; }
        public Guid ConnectionId { get; set; }
        public ulong ProcessId { get; set; }
    }
}
