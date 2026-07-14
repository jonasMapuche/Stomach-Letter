using Android.Content;
using Android.Net;
using Letter.Interfaces;
using Letter.Platforms.Android.Broadcasts;

namespace Letter.Platforms.Android.Services
{
    public class VPNClientService : IVPNClientService
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
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        #endregion

        #region FUNCTION
        public void SetUp()
        {
            Intent intent = VpnService.Prepare(Platform.CurrentActivity);

            if (intent != null)
            {
                Platform.CurrentActivity.StartActivityForResult(intent, MainActivity.RequestVpnPermission);
            }
            else
            {
                Intent vpnIntent = new Intent(Platform.AppContext, typeof(VPNClientBroadcast));
                Platform.AppContext.StartService(vpnIntent);
            }
        }
        #endregion
    }
}
