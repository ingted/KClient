using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryDocumentDeleteById : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public string Schema { get; set; }
        public uint Id { get; set; }

        public KbQueryDocumentDeleteById(Guid connectionId, string schema, uint id)
        {
            ConnectionId = connectionId;
            Schema = schema;
            Id = id;
        }
    }

    public class KbQueryDocumentDeleteByIdReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
    }
}
