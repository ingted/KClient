using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Payloads;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbIndexesClient
    {
        private readonly KbClient _client;

        public KbIndexesClient(KbClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Creates an index on the given schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="index"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="KbAPIResponseException"></exception>
        public void Create(string schema, KbIndex index)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryIndexCreate(_client.ServerConnectionId, schema, index)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                });
        }

        /// <summary>
        /// Checks for the existence of an index.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="indexName"></param>
        public bool Exists(string schema, string indexName)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryIndexExists(_client.ServerConnectionId, schema, indexName)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                    return t.Result;
                }).Result.Value;
        }

        /// <summary>
        /// Gets an index from a specific schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="indexName"></param>
        public KbActionResponseIndex Get(string schema, string indexName)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryIndexGet(_client.ServerConnectionId, schema, indexName)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                    return t.Result;
                }).Result;
        }

        /// <summary>
        /// Rebuilds a given index.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="indexName"></param>
        /// <param name="newPartitionCount"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="KbAPIResponseException"></exception>
        public void Rebuild(string schema, string indexName, uint newPartitionCount = 0)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryIndexRebuild(_client.ServerConnectionId, schema, indexName, newPartitionCount)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                });
        }

        /// <summary>
        /// Deletes a given index.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="indexName"></param>
        public void Drop(string schema, string indexName)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryIndexDrop(_client.ServerConnectionId, schema, indexName)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Exception?.Message ?? "Unspecified api error has occurred.");
                    }
                });
        }

        /// <summary>
        /// Lists all indexes on a given schema
        /// </summary>
        /// <param name="schema"></param>
        public KbActionResponseIndexes List(string schema)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryIndexList(_client.ServerConnectionId, schema)).ContinueWith(t =>
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
