using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryIndexExists : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public string Schema { get; set; }
        public string IndexName { get; set; }

        public KbQueryIndexExists(Guid connectionId, string schema, string indexName)
        {
            ConnectionId = connectionId;
            Schema = schema;
            IndexName = indexName;
        }
    }

    public class KbQueryIndexExistsReply : KbActionResponseBoolean, IFramePayloadQueryReply
    {
        public KbQueryIndexExistsReply()
        {

        }

        public KbQueryIndexExistsReply(bool value) : base(value) { }
    }
}
