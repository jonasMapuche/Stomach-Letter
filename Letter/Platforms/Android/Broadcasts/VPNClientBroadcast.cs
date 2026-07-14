using Android.App;
using Android.Content;
using Android.Net;

namespace Letter.Platforms.Android.Broadcasts
{
    [Service(Label = "Letter", Permission = "android.permission.BIND_VPN_SERVICE", Exported = true)]
    [IntentFilter(new[] { ActionVpnService })]
    public class VPNClientBroadcast : VpnService
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
        public const string ActionVpnService = "android.net.VpnService";
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        #endregion

        #region FUNCTION
        public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation set up \"VPN Client\" broadcast failed!");

                Builder builder = new Builder(this);
                return StartCommandResult.Sticky;
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
