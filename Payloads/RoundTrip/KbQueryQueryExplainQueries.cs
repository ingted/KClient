using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExplainQueries : IRmQuery<KbQueryQueryExplainQueriesReply>
    {
        public Guid ConnectionId { get; set; }
        public List<string> Statements { get; set; }

        public KbQueryQueryExplainQueries(Guid connectionId, List<string> statements)
        {
            ConnectionId = connectionId;
            Statements = statements;
        }
    }

    public class KbQueryQueryExplainQueriesReply : KbQueryResultCollection, IRmQueryReply
    {
    }
}
