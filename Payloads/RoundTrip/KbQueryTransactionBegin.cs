using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryTransactionBegin : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }

        public KbQueryTransactionBegin(Guid connectionId)
        {
            ConnectionId = connectionId;
        }
    }

    public class KbQueryTransactionBeginReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
    }
}
