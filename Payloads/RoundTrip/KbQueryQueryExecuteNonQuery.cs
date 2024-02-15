using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExecuteNonQuery : IRmQuery<KbQueryQueryExecuteNonQueryReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }

        public KbQueryQueryExecuteNonQuery(Guid connectionId, string statement)
        {
            ConnectionId = connectionId;
            Statement = statement;
        }
    }

    public class KbQueryQueryExecuteNonQueryReply : KbActionResponseCollection, IRmQueryReply
    {
    }
}
