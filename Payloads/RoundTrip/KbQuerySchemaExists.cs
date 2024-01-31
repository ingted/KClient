using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQuerySchemaExists : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public string Schema { get; set; }

        public KbQuerySchemaExists(Guid connectionId, string schema)
        {
            ConnectionId = connectionId;
            Schema = schema;
        }
    }

    public class KbQuerySchemaExistsReply : KbActionResponseBoolean, IFramePayloadQueryReply
    {
        public KbQuerySchemaExistsReply()
        {

        }
        public KbQuerySchemaExistsReply(bool value) : base(value)
        {
        }
    }
}
