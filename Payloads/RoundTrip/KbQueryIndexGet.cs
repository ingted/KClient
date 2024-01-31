using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryIndexGet : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public string Schema { get; set; }
        public string IndexName { get; set; }

        public KbQueryIndexGet(Guid connectionId, string schema, string indexName)
        {
            ConnectionId = connectionId;
            Schema = schema;
            IndexName = indexName;
        }
    }

    public class KbQueryIndexGetReply : KbActionResponseIndex, IFramePayloadQueryReply
    {
        public KbQueryIndexGetReply()
        {
        }

        public KbQueryIndexGetReply(KbIndex? index) : base(index) { }
    }
}
