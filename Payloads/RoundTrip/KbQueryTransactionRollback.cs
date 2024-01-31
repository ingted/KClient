using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryTransactionRollback : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }

        public KbQueryTransactionRollback(Guid connectionId)
        {
            ConnectionId = connectionId;
        }
    }

    public class KbQueryTransactionRollbackReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
    }
}
