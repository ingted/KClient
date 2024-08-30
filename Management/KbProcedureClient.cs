using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Payloads;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbProcedureClient
    {
        private readonly KbClient _client;

        public KbIndexesClient Indexes { get; set; }

        public KbProcedureClient(KbClient client)
        {
            _client = client;
            Indexes = new KbIndexesClient(client);
        }

        /// <summary>
        /// Executes a procedure with or without parameters. This method of calling a procedure performs various types of validation.
        /// </summary>
        public KbQueryProcedureExecuteReply Execute(KbProcedure procedure, TimeSpan? queryTimeout = null)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            return _client.Connection.Query(
                new KbQueryProcedureExecute(_client.ServerConnectionId, procedure), (TimeSpan)queryTimeout)
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Executes a procedure with or without parameters. This method of calling a procedure performs various types of validation.
        /// </summary>
        public List<T> Execute<T>(KbProcedure procedure, TimeSpan? queryTimeout = null) where T : new()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            queryTimeout ??= _client.Connection.QueryTimeout;

            var resultCollection = _client.Connection.Query(
                new KbQueryProcedureExecute(_client.ServerConnectionId, procedure), (TimeSpan)queryTimeout)
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

        public T ExecuteSingle<T>(KbProcedure procedure, TimeSpan? queryTimeout = null) where T : new()
            => Execute<T>(procedure, queryTimeout).Single();

        public T? ExecuteSingleOrDefault<T>(KbProcedure procedure, TimeSpan? queryTimeout = null) where T : new()
            => Execute<T>(procedure, queryTimeout).SingleOrDefault();

        public T ExecuteFirst<T>(KbProcedure procedure, TimeSpan? queryTimeout = null) where T : new()
            => Execute<T>(procedure, queryTimeout).First();

        public T? ExecuteFirstOrDefault<T>(KbProcedure procedure, TimeSpan? queryTimeout = null) where T : new()
            => Execute<T>(procedure, queryTimeout).FirstOrDefault();
    }
}
