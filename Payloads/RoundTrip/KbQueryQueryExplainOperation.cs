﻿using NTDLS.Katzebase.Client.Types;
using NTDLS.ReliableMessaging;

namespace NTDLS.Katzebase.Client.Payloads.RoundTrip
{
    public class KbQueryQueryExplainOperation : IRmQuery<KbQueryQueryExplainOperationReply>
    {
        public Guid ConnectionId { get; set; }
        public string Statement { get; set; }
        public KbInsensitiveDictionary<string?>? UserParameters { get; set; }

        public KbQueryQueryExplainOperation(Guid connectionId, string statement, KbInsensitiveDictionary<string?>? userParameters)
        {
            ConnectionId = connectionId;
            Statement = statement;
            UserParameters = userParameters;
        }
    }

    public class KbQueryQueryExplainOperationReply : KbQueryExplainCollection, IRmQueryReply
    {
    }
}
