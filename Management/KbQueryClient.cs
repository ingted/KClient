using NTDLS.Katzebase.Client.Payloads;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbQueryClient
    {
        private readonly KbClient _client;

        public KbQueryClient(KbClient client)
        {
            _client = client;
        }

        public KbQueryResultCollection ExplainQuery(string statement)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExplain(_client.ServerConnectionId, statement))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryResultCollection ExecuteQuery(string statement)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExecuteQuery(_client.ServerConnectionId, statement))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryResultCollection ExecuteQueries(List<string> statements)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExecuteQueries(_client.ServerConnectionId, statements))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbActionResponseCollection ExecuteNonQuery(string statement)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExecuteNonQuery(_client.ServerConnectionId, statement))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }
    }
}
