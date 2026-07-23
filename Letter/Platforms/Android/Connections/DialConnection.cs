using Android.Telecom;
using Letter.Models;

namespace Letter.Platforms.Android.Connections
{
    public class DialConnection : Connection
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
        public DialConnection()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Dial\" connection failed!");
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
        public override void OnAvailableCallEndpointsChanged(IList<CallEndpoint> availableEndpoints)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on available call endpoints changed \"Dial\" connection failed!");

                base.OnAvailableCallEndpointsChanged(availableEndpoints);

                foreach (CallEndpoint endpoint in availableEndpoints)
                {
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = endpoint.EndpointName;
                    int kind = (int)endpoint.EndpointType;
                    mechanism.implied = kind.ToString();
                    this.Receiver.Add(mechanism);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public override void OnShowIncomingCallUi()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on show incoming call Ui \"Dial\" connection failed!");

                base.OnShowIncomingCallUi();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTION
        public void ChangeRoute(CallAudioRoute route)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation change route \"Dial\" connection failed!");

                SetAudioRoute(route);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion
    }
}
