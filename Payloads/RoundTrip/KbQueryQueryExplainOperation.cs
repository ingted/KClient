using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExplainOperation : IRmQuery<KbQueryQueryExplainOperationReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }

        public KbQueryQueryExplainOperation(Guid connectionId, string statement)
        {
            ConnectionId = connectionId;
            Statement = statement;
        }
    }

    public class KbQueryQueryExplainOperationReply : KbQueryExplainCollection, IRmQueryReply
    {
    }
}
