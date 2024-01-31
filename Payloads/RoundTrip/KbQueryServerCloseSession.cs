using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryServerCloseSession : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }

        public KbQueryServerCloseSession(Guid connectionId)
        {
            ConnectionId = connectionId;
        }
    }

    public class KbQueryServerCloseSessionReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
    }
}
