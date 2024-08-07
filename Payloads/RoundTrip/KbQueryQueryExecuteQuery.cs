using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExecuteQuery : IRmQuery<KbQueryQueryExecuteQueryReply>
    {
        public Guid ConnectionId { get; set; }
        public List<string> Statements { get; set; }

        public KbQueryQueryExecuteQuery(Guid connectionId, List<string> statements)
        {
            ConnectionId = connectionId;
            Statements = statements;
        }
    }

    public class KbQueryQueryExecuteQueryReply : KbQueryResultCollection, IRmQueryReply
    {
    }
}
