using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryTransactionCommit : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }

        public KbQueryTransactionCommit(Guid connectionId)
        {
            ConnectionId = connectionId;
        }
    }

    public class KbQueryTransactionCommitReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
    }
}
