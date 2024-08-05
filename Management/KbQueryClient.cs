using NTDLS.Katzebase.Client.Exceptions;
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
                new KbQueryQueryExplain(_client.ServerConnectionId, statement)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                    return t.Result;
                }).Result;
        }

        public KbQueryResultCollection ExecuteQuery(string statement)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExecuteQuery(_client.ServerConnectionId, statement)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                    return t.Result;
                }).Result;
        }

        public KbQueryResultCollection ExecuteQueries(List<string> statements)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExecuteQueries(_client.ServerConnectionId, statements)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                    return t.Result;
                }).Result;
        }

        public KbActionResponseCollection ExecuteNonQuery(string statement)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryQueryExecuteNonQuery(_client.ServerConnectionId, statement)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                    return t.Result;
                }).Result;
        }
    }
}
