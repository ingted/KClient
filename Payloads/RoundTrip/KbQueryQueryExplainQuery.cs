using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExplainQuery : IRmQuery<KbQueryQueryExplainQueryReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }

        public KbQueryQueryExplainQuery(Guid connectionId, string statement)
        {
            ConnectionId = connectionId;
            Statement = statement;
        }
    }

    public class KbQueryQueryExplainQueryReply : KbQueryExplain, IRmQueryReply
    {
    }
}
