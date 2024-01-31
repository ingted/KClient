using NTDLS.Katzebase.Client.Exceptions;
using NTDLS.Katzebase.Client.Management;
using NTDLS.ReliableMessaging;
using System.Diagnostics;

namespace NTDLS.Katzebase.Client
{
    public class KbClient : IDisposable
    {
        internal MessageClient? Connection { get; private set; }

        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }

        public string ClientName { get; private set; }
        public ulong ProcessId { get; set; }
        public Guid ServerConnectionId { get; private set; }
        public KbDocumentClient Document { get; private set; }
        public KbSchemaClient Schema { get; private set; }
        public KbServerClient Server { get; private set; }
        public KbTransactionClient Transaction { get; private set; }
        public KbQueryClient Query { get; private set; }
        public KbProcedureClient Procedure { get; private set; }

        public KbClient()
        {
            ClientName = Process.GetCurrentProcess().ProcessName;

            Document = new KbDocumentClient(this);
            Schema = new KbSchemaClient(this);
            Server = new KbServerClient(this);
            Transaction = new KbTransactionClient(this);
            Query = new KbQueryClient(this);
            Procedure = new KbProcedureClient(this);
        }

        public KbClient(string hostName, int serverPort, string clientName = "")
        {
            ClientName = clientName;

            Document = new KbDocumentClient(this);
            Schema = new KbSchemaClient(this);
            Server = new KbServerClient(this);
            Transaction = new KbTransactionClient(this);
            Query = new KbQueryClient(this);
            Procedure = new KbProcedureClient(this);

            Connect(hostName, serverPort, clientName);
        }

        public void Connect(string hostname, int port, string clientName = "")
        {
            Host = hostname;
            Port = port;
            ClientName = clientName;

            if (string.IsNullOrWhiteSpace(ClientName))
            {
                ClientName = Process.GetCurrentProcess().ProcessName;
            }

            if (Connection?.IsConnected == true)
            {
                throw new KbGenericException("The client is already connected.");
            }

            try
            {
                Connection = new MessageClient();
                Connection.Connect(hostname, port);
                Connection.OnException += Connection_OnException;

                var sessionInfo = Server.StartSession();
                ServerConnectionId = sessionInfo.ConnectionId;
                ProcessId = sessionInfo.ProcessId;
            }
            catch
            {
                Connection = null;
                ServerConnectionId = Guid.Empty;
                throw;
            }
        }

        private bool Connection_OnException(MessageClient client, Guid connectionId, Exception ex, StreamFraming.Payloads.IFramePayload? payload)
        {
            throw new NotImplementedException();
        }

        void Disconnect()
        {
            try
            {
                try
                {
                    if (Connection?.IsConnected == true)
                    {
                        Server.CloseSession();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Connection?.Disconnect();
                    Connection = null;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Connection = null;
                ServerConnectionId = Guid.Empty;
            }
        }

        #region IDisposable.

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Disconnect();
            }

            disposed = true;

        }

        #endregion
    }
}
