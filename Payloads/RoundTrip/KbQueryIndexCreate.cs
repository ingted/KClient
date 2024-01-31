using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryIndexCreate : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public string Schema { get; set; }
        public KbIndex Index { get; set; }

        public KbQueryIndexCreate(Guid connectionId, string schema, KbIndex index)
        {
            ConnectionId = connectionId;
            Schema = schema;
            Index = index;
        }
    }

    public class KbQueryIndexCreateReply : KbActionResponseGuid, IFramePayloadQueryReply
    {
        public KbQueryIndexCreateReply()
        {

        }

        public KbQueryIndexCreateReply(Guid id) : base(id)
        {
        }
    }
}
