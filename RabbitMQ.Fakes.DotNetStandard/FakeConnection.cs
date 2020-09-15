using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;

namespace RabbitMQ.Fakes.DotNetStandard
{
    public class FakeConnection : IConnection
    {
        private readonly RabbitServer _server;

        #region Properties

        #region INetworkConnection Implementation

        public int LocalPort { get; }

        public int RemotePort { get; }

        #endregion INetworkConnection Implementation

        #region IConnection Implementation

        public IDictionary<string, object> ClientProperties { get; set; }

        public string ClientProvidedName { get; }

        IList<ShutdownReportEntry> IConnection.ShutdownReport
        {
            get { throw new NotImplementedException(); }
        }

        public IDictionary<string, object> ServerProperties { get; set; }

        public IProtocol Protocol { get; set; }

        public AmqpTcpEndpoint[] KnownHosts { get; set; }

        public bool IsOpen { get; set; }

        public TimeSpan Heartbeat { get; set; }

        public uint FrameMax { get; set; }

        public AmqpTcpEndpoint Endpoint { get; set; }

        public ushort ChannelMax { get; set; }

        public ShutdownEventArgs CloseReason { get; set; }

        #endregion IConnection Implementation

        public List<FakeModel> Models { get; private set; }

        #endregion Properties

        #region Event Handlers

        event EventHandler<CallbackExceptionEventArgs> IConnection.CallbackException
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> RecoverySucceeded;

        public event EventHandler<ConnectionRecoveryErrorEventArgs> ConnectionRecoveryError;

        public event EventHandler<ConnectionBlockedEventArgs> ConnectionBlocked;

        event EventHandler<ShutdownEventArgs> IConnection.ConnectionShutdown
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> ConnectionUnblocked;

        #endregion Event Handlers

        #region Constructors

        public FakeConnection(RabbitServer server)
        {
            _server = server;
            Models = new List<FakeModel>();
        }

        #endregion Constructors

        #region Public Methods

        #region IConnection Implementation

        public void Abort(ushort reasonCode, string reasonText, TimeSpan timeout)
        {
            IsOpen = false;
            CloseReason = new ShutdownEventArgs(ShutdownInitiator.Library, reasonCode, reasonText);

            this.Models.ForEach(m => m.Abort());
        }

        public void Abort(TimeSpan timeout)
        {
            Abort(1, null, timeout);
        }

        public void Abort(ushort reasonCode, string reasonText)
        {
            Abort(reasonCode, reasonText, TimeSpan.FromSeconds(0));
        }

        public void Abort()
        {
            Abort(1, null, TimeSpan.FromSeconds(0));
        }

        public void Close(ushort reasonCode, string reasonText, TimeSpan timeout)
        {
            IsOpen = false;
            CloseReason = new ShutdownEventArgs(ShutdownInitiator.Library, reasonCode, reasonText);

            Models.ForEach(m => m.Close());
        }

        public void Close(TimeSpan timeout)
        {
            Close(1, null, timeout);
        }

        public void Close(ushort reasonCode, string reasonText)
        {
            Close(reasonCode, reasonText, TimeSpan.FromSeconds(0));
        }

        public void Close()
        {
            Close(1, null, TimeSpan.FromSeconds(0));
        }

        public IModel CreateModel()
        {
            var model = new FakeModel(_server);
            Models.Add(model);

            return model;
        }

        public void HandleConnectionBlocked(string reason)
        {
        }

        public void HandleConnectionUnblocked()
        {
        }

        public void UpdateSecret(string newSecret, string reason)
        {
            throw new NotImplementedException();
        }

        #endregion IConnection Implementation

        #region IDisposable Implementation

        public void Dispose()
        {
        }

        #endregion IDisposable Implementation

        #endregion Public Methods
    }
}