using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQuerySchemaCreate : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public string Schema { get; set; }
        public uint PageSize { get; set; }

        public KbQuerySchemaCreate(Guid connectionId, string schema, uint pageSize)
        {
            ConnectionId = connectionId;
            Schema = schema;
            PageSize = pageSize;
        }
    }

    public class KbQuerySchemaCreateReply : KbActionResponseBoolean, IFramePayloadQueryReply
    {
    }
}
