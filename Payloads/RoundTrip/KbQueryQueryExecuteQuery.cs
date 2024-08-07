using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExecuteQuery : IRmQuery<KbQueryQueryExecuteQueryReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }

        public KbQueryQueryExecuteQuery(Guid connectionId, string statement)
        {
            ConnectionId = connectionId;
            Statement = statement;
        }
    }

    public class KbQueryQueryExecuteQueryReply : KbQueryResultCollection, IRmQueryReply
    {
    }
}
