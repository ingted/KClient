using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Payloads.RoundTrip;

namespace NTDLS.Katzebase.Client.Management
{
    public class KbServerClient
    {
        private readonly KbClient _client;

        public KbServerClient(KbClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Starts a session on the server
        /// </summary>
        /// <returns></returns>
        /// <exception cref="KbAPIResponseException"></exception>
        public KbQueryServerStartSessionReply StartSession()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            return _client.Connection.Query<KbQueryServerStartSessionReply>(
                new KbQueryServerStartSession(_client.ServerConnectionId)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                }).Result;
        }

        /// <summary>
        /// Closes the connected process on the server and rolls back any open transactions.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="KbAPIResponseException"></exception>
        public void CloseSession()
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query<KbQueryServerCloseSessionReply>(
                new KbQueryServerCloseSession(_client.ServerConnectionId)).ContinueWith(t =>
                {
                    if (t.Result?.Success != true)
                    {
                        throw new KbAPIResponseException(t.Result == null ? "Invalid response" : t.Result?.ExceptionText);
                    }
                    return t.Result;
                });
        }

        /// <summary>
        /// Terminates a process on the server and rolls back any open transactions.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="KbAPIResponseException"></exception>
        public void TerminateProcess(ulong processId)
        {
            if (_client.Connection?.IsConnected != true) throw new Exception("The client is not connected.");

            _client.Connection.Query<KbQueryServerTerminateProcessReply>(
                new KbQueryServerTerminateProcess(_client.ServerConnectionId, processId)).ContinueWith(t =>
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
