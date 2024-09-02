using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;
using NTDLS.Katzebase.Client.Types;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbQueryClient
    {
        private readonly KbClient _client;

        public KbQueryClient(KbClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Explains the condition and join operations.
        /// </summary>
        public KbQueryQueryExplainOperationReply ExplainOperation(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainOperation(_client.ServerConnectionId, statement, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Explains the condition and join operations.
        /// </summary>
        public KbQueryQueryExplainOperationReply ExplainOperation(string statement, object userParameters, TimeSpan? queryTimeout = null)
            => ExplainOperation(statement, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Explains the condition and join operations.
        /// </summary>
        public KbQueryQueryExplainOperationsReply ExplainOperations(List<string> statements, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainOperations(_client.ServerConnectionId, statements, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Explains the condition and join operations.
        /// </summary>
        public KbQueryQueryExplainOperationsReply ExplainOperations(List<string> statements, object userParameters, TimeSpan? queryTimeout = null)
            => ExplainOperations(statements, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Explains the condition and join plans, including applicable indexing.
        /// </summary>
        public KbQueryQueryExplainPlanReply ExplainPlan(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainPlan(_client.ServerConnectionId, statement, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Explains the condition and join plans, including applicable indexing.
        /// </summary>
        public KbQueryQueryExplainPlanReply ExplainPlan(string statement, object userParameters, TimeSpan? queryTimeout = null)
            => ExplainPlan(statement, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Explains the condition and join plans, including applicable indexing.
        /// </summary>
        public KbQueryQueryExplainPlansReply ExplainPlans(List<string> statements, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExplainPlans(_client.ServerConnectionId, statements, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Explains the condition and join plans, including applicable indexing.
        /// </summary>
        public KbQueryQueryExplainPlansReply ExplainPlans(List<string> statements, object userParameters, TimeSpan? queryTimeout = null)
            => ExplainPlans(statements, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Fetches documents using the given query and optional parameters.
        /// </summary>
        public KbQueryQueryExecuteQueryReply Fetch(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExecuteQuery(_client.ServerConnectionId, statement, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Fetches documents using the given query and optional parameters.
        /// </summary>
        public KbQueryQueryExecuteQueryReply Fetch(string statement, object userParameters, TimeSpan? queryTimeout = null)
            => Fetch(statement, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Fetches documents using the given query and optional parameters.
        /// </summary>
        public IEnumerable<T> Fetch<T>(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null) where T : new()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            var resultCollection = _client.Connection.Query(
                new KbQueryQueryExecuteQuery(_client.ServerConnectionId, statement, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;

            if (resultCollection.Collection.Count > 1)
            {
                throw new KbMultipleRecordSetsException();
            }
            else if (resultCollection.Collection.Count == 0)
            {
                return new List<T>();
            }

            return resultCollection.Collection[0].MapTo<T>();
        }

        /// <summary>
        /// Fetches documents using the given query and optional parameters.
        /// </summary>
        public IEnumerable<T> Fetch<T>(string statement, object userParameters, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Executes multiple statements and fetches their results given the supplied statement and optional parameters.
        /// </summary>
        public KbQueryQueryExecuteQueriesReply FetchMultiple(List<string> statements, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExecuteQueries(_client.ServerConnectionId, statements, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Executes multiple statements and fetches their results given the supplied statement and optional parameters.
        /// </summary>
        public KbQueryQueryExecuteQueriesReply FetchMultiple(List<string> statements, object userParameters, TimeSpan? queryTimeout = null)
            => FetchMultiple(statements, userParameters.ToUserParameters(), queryTimeout);

        /// <summary>
        /// Executes a statements using the supplied statement and optional parameters.
        /// </summary>
        public KbQueryQueryExecuteNonQueryReply ExecuteNonQuery(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryQueryExecuteNonQuery(_client.ServerConnectionId, statement, userParameters), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Executes a statements using the supplied statement and optional parameters.
        /// </summary>
        public KbQueryQueryExecuteNonQueryReply ExecuteNonQuery(string statement, object userParameters, TimeSpan? queryTimeout = null)
            => ExecuteNonQuery(statement, userParameters.ToUserParameters(), queryTimeout);


        //--Fetch single, singleOrDefault, first, firstOrDefault using parameter collection.

        /// <summary>
        /// Fetches a single document using the given query and optional parameters.
        /// </summary>
        public T FetchSingle<T>(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters, queryTimeout).Single();

        /// <summary>
        /// Fetches a single document. Throws exception if there is more than one match, otherwise return null. Using the given query and optional parameters.
        /// </summary>
        public T? FetchSingleOrDefault<T>(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters, queryTimeout).SingleOrDefault();

        /// <summary>
        /// Fetches the first document. Throws exception if there are no results. Using the given query and optional parameters.
        /// </summary>
        public T FetchFirst<T>(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters, queryTimeout).First();

        /// <summary>
        /// Fetches the first document or null if there are no results. Using the given query and optional parameters.
        /// </summary>
        public T? FetchFirstOrDefault<T>(string statement, KbInsensitiveDictionary<string>? userParameters = null, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters, queryTimeout).FirstOrDefault();

        //--Fetch single, singleOrDefault, first, firstOrDefault using an anonymous parameter type.

        /// <summary>
        /// Fetches a single document using the given query and optional parameters.
        /// </summary>
        public T FetchSingle<T>(string statement, object userParameters, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters.ToUserParameters(), queryTimeout).Single();

        /// <summary>
        /// Fetches a single document. Throws exception if there is more than one match, otherwise return null. Using the given query and optional parameters.
        /// </summary>
        public T? FetchSingleOrDefault<T>(string statement, object userParameters, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters.ToUserParameters(), queryTimeout).SingleOrDefault();

        /// <summary>
        /// Fetches the first document. Throws exception if there are no results. Using the given query and optional parameters.
        /// </summary>
        public T FetchFirst<T>(string statement, object userParameters, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters.ToUserParameters(), queryTimeout).First();

        /// <summary>
        /// Fetches the first document or null if there are no results. Using the given query and optional parameters.
        /// </summary>
        public T? FetchFirstOrDefault<T>(string statement, object userParameters, TimeSpan? queryTimeout = null) where T : new()
            => Fetch<T>(statement, userParameters.ToUserParameters(), queryTimeout).FirstOrDefault();

    }
}
