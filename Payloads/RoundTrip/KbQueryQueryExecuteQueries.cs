using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExecuteQueries : IRmQuery<KbQueryQueryExecuteQueriesReply>
    {
        public Guid ConnectionId { get; set; }
        public List<string> Statements { get; set; }

        public KbQueryQueryExecuteQueries(Guid connectionId, List<string> statements)
        {
            ConnectionId = connectionId;
            Statements = statements;
        }
    }

    public class KbQueryQueryExecuteQueriesReply : KbQueryResultCollection, IRmQueryReply
    {
    }
}
