using NTDLS.Katzebase.Client.Exceptions;
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

        public KbQueryQueryExplainOperationReply ExplainOperation(string statement, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainOperation(_client.ServerConnectionId, statement), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryQueryExplainOperationsReply ExplainOperations(List<string> statements, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainOperations(_client.ServerConnectionId, statements), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryQueryExplainPlanReply ExplainPlan(string statement, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainPlan(_client.ServerConnectionId, statement), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryQueryExplainPlansReply ExplainPlans(List<string> statements, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainPlans(_client.ServerConnectionId, statements), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryQueryExecuteQueryReply Query(string statement, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExecuteQuery(_client.ServerConnectionId, statement), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public List<T> Query<T>(string statement, TimeSpan? queryTimeout = null) where T : new()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            var resultCollection = _client.Connection.Query(
                new KbQueryQueryExecuteQuery(_client.ServerConnectionId, statement), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;

            if (resultCollection.Collection.Count > 0)
            {
                throw new KbMultipleRecordSetsException();
            }
            else if (resultCollection.Collection.Count == 0)
            {
                return new List<T>();
            }

            return resultCollection.Collection[0].MapTo<T>();
        }

        public T QuerySingle<T>(string statement, TimeSpan? queryTimeout = null) where T : new()
            => Query<T>(statement, queryTimeout).Single();

        public T? SingleOrDefault<T>(string statement, TimeSpan? queryTimeout = null) where T : new()
            => Query<T>(statement, queryTimeout).SingleOrDefault();

        public T QueryFirst<T>(string statement, TimeSpan? queryTimeout = null) where T : new()
            => Query<T>(statement, queryTimeout).First();

        public T? QueryFirstOrDefault<T>(string statement, TimeSpan? queryTimeout = null) where T : new()
            => Query<T>(statement, queryTimeout).FirstOrDefault();

        public KbQueryQueryExecuteQueriesReply Multiple(List<string> statements, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExecuteQueries(_client.ServerConnectionId, statements), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        public KbQueryQueryExecuteNonQueryReply NonQuery(string statement, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExecuteNonQuery(_client.ServerConnectionId, statement), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }
    }
}
