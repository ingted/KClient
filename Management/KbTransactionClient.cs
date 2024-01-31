using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbTransactionClient
    {
        private readonly KbClient _client;

        public KbTransactionClient(KbClient client)
        {
            _client = client;
        }

        public void Begin()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query<KbQueryTransactionBeginReply>(
                new KbQueryTransactionBegin(_client.ServerConnectionId)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                });
        }

        public void Commit()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query<KbQueryTransactionCommitReply>(
                new KbQueryTransactionCommit(_client.ServerConnectionId)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                });
        }

        public void Rollback()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query<KbQueryTransactionRollbackReply>(
                new KbQueryTransactionRollback(_client.ServerConnectionId)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                });
        }

    }
}
