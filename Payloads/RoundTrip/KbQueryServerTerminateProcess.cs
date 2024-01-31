using NTDLS.StreamFraming.Payloads;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryServerTerminateProcess : IFramePayloadQuery
    {
        public Guid ConnectionId { get; set; }
        public ulong ReferencedProcessId { get; set; }

        public KbQueryServerTerminateProcess(Guid connectionId, ulong referencedProcessId)
        {
            ConnectionId = connectionId;
            ReferencedProcessId = referencedProcessId;
        }
    }

    public class KbQueryServerTerminateProcessReply : KbBaseActionResponse, IFramePayloadQueryReply
    {
    }
}
