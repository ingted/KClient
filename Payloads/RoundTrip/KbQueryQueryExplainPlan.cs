using NTDLS.Katzebase.Client.Types;
using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExplainPlan : IRmQuery<KbQueryQueryExplainPlanReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }
        public KbInsensitiveDictionary<string>? UserParameters { get; set; }

        public KbQueryQueryExplainPlan(Guid connectionId, string statement, KbInsensitiveDictionary<string>? userParameters)
        {
            ConnectionId = connectionId;
            Statement = statement;
            UserParameters = userParameters;
        }
    }

    public class KbQueryQueryExplainPlanReply : KbQueryExplainCollection, IRmQueryReply
    {
    }
}
