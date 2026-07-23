using Android.App;
using Android.Telecom;
using Letter.Models;

namespace Letter.Platforms.Android.Connections
{
    [Service(Permission = "android.permission.BIND_TELECOM_CONNECTION_SERVICE")]
    public class PhoneConnection : ConnectionService
    {
        #region ERROR
        private bool _error_on = true;
        private bool _error_off = false;
        private string? _error_message;

        public string? error_message
        {
            get => this._error_message;
            set
            {
                this._error_message = value;
            }
        }

        public event EventHandler<string>? OnError;
        #endregion

        #region VARIABLE
        public List<Mechanism> Receiver { get; set; }
        #endregion

        #region CONSTRUCTOR
        public PhoneConnection()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Phone\" connection failed!");
                else this.error_message = string.Empty;

                this.Receiver = new List<Mechanism>();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        public override Connection OnCreateOutgoingConnection(PhoneAccountHandle connectionManagerPhone, ConnectionRequest request)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on create outgoing connection \"Phone\" connection failed!");

                DialConnection connection = new DialConnection();
                connection.SetDialing();
                connection.ChangeRoute(CallAudioRoute.WiredHeadset);
                this.Receiver = connection.Receiver;
                //CallEndpoint availableEndpoints = connection.CurrentCallEndpoint;
                return connection;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public override Connection OnCreateIncomingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on create outgoing connection \"Phone\" connection failed!");

                DialConnection connection = new DialConnection();
                connection.SetRinging();
                // Lógica para notificar chamada recebida
                return connection;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTION
        #endregion
    }
}
