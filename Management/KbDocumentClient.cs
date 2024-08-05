using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Payloads;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbDocumentClient
    {
        private readonly KbClient _client;

        public KbDocumentClient(KbClient client)
        {
            _client = client;
        }



        /// <summary>
        /// Stores a document in the given schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="document"></param>
        public void Store(string schema, KbDocument document)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryDocumentStore(_client.ServerConnectionId, schema, document))
                .ContinueWith(t => _client.ValidateTaskResult(t));
        }

        /// <summary>
        /// Stores a document in the given schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="document"></param>
        public void Store(string schema, object document)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryDocumentStore(_client.ServerConnectionId, schema, new KbDocument(document)))
                .ContinueWith(t => _client.ValidateTaskResult(t));

        }

        /// <summary>
        /// Deletes a document in the given schema by its Id.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="KbAPIResponseException"></exception>
        public void DeleteById(string schema, uint id)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query(
                new KbQueryDocumentDeleteById(_client.ServerConnectionId, schema, id))
                .ContinueWith(t => _client.ValidateTaskResult(t));
        }

        /// <summary>
        /// Lists the documents within a given schema.
        /// </summary>
        public KbQueryDocumentCatalogReply Catalog(string schema)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryDocumentCatalog(_client.ServerConnectionId, schema))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Lists the documents within a given schema with their values.
        /// </summary>
        /// <param name="schema"></param>
        public KbQueryDocumentListReply List(string schema, int count = -1)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryDocumentList(_client.ServerConnectionId, schema, count))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }

        /// <summary>
        /// Samples the documents within a given schema with their values.
        /// </summary>
        /// <param name="schema"></param>
        public KbQueryDocumentSampleReply Sample(string schema, int count)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query(
                new KbQueryDocumentSample(_client.ServerConnectionId, schema, count))
                .ContinueWith(t => _client.ValidateTaskResult(t)).Result;
        }
    }
}
