using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryProcedureExecute : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public KbProcedure Procedure { get; set; }

        public KbQueryProcedureExecute(Guid connectionId, KbProcedure procedure)
        {
            ConnectionId = connectionId;
            Procedure = procedure;
        }
    }

    public class KbQueryProcedureExecuteReply : KbQueryResultCollection, IFramePayloadQueryReply
    {
    }
}
