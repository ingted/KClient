using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExplain : IRmQuery<KbQueryQueryExplainReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }

        public KbQueryQueryExplain(Guid connectionId, string statement)
        {
            ConnectionId = connectionId;
            Statement = statement;
        }
    }

    public class KbQueryQueryExplainReply : KbQueryResultCollection, IRmQueryReply
    {
    }
}
