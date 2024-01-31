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

            _client.Connection.Query<KbQueryDocumentStoreReply>(
                new KbQueryDocumentStore(_client.ServerConnectionId, schema, document)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                });
        }

        /// <summary>
        /// Stores a document in the given schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="document"></param>
        public void Store(string schema, object document)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query<KbQueryDocumentStoreReply>(
                new KbQueryDocumentStore(_client.ServerConnectionId, schema, new KbDocument(document))).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                });
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

            _client.Connection.Query<KbQueryDocumentDeleteByIdReply>(
                new KbQueryDocumentDeleteById(_client.ServerConnectionId, schema, id)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                });
        }

        /// <summary>
        /// Lists the documents within a given schema.
        /// </summary>
        public KbQueryDocumentCatalogReply Catalog(string schema)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query<KbQueryDocumentCatalogReply>(
                new KbQueryDocumentCatalog(_client.ServerConnectionId, schema)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                }).Result;
        }

        /// <summary>
        /// Lists the documents within a given schema with their values.
        /// </summary>
        /// <param name="schema"></param>
        public KbQueryDocumentListReply List(string schema, int count = -1)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query<KbQueryDocumentListReply>(
                new KbQueryDocumentList(_client.ServerConnectionId, schema, count)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                }).Result;
        }

        /// <summary>
        /// Samples the documents within a given schema with their values.
        /// </summary>
        /// <param name="schema"></param>
        public KbQueryDocumentSampleReply Sample(string schema, int count)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query<KbQueryDocumentSampleReply>(
                new KbQueryDocumentSample(_client.ServerConnectionId, schema, count)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                }).Result;
        }
    }
}
