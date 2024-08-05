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

            _client.Connection.Query(
                new KbQueryTransactionBegin(_client.ServerConnectionId))
                .ContinueWith(t => _client.ValidateTaskResult(t));
        }

        public void Commit()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryTransactionCommit(_client.ServerConnectionId))
                .ContinueWith(t => _client.ValidateTaskResult(t));
        }

        public void Rollback()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryTransactionRollback(_client.ServerConnectionId))
                .ContinueWith(t => _client.ValidateTaskResult(t));
        }
    }
}
