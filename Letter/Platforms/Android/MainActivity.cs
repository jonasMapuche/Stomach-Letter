using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Letter.Platforms.Android.Broadcasts;

namespace Letter
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
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
        public const int RequestVpnPermission = 9999;
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on create \"Main\" Activity failed!");

                base.OnCreate(savedInstanceState);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on activity result \"Main\" Activity failed!");

                base.OnActivityResult(requestCode, resultCode, data);
                if (requestCode == RequestVpnPermission)
                {
                    if (resultCode == Result.Ok)
                    {
                        Intent intent = new Intent(this, typeof(VPNClientBroadcast));
                        Platform.AppContext.StartService(intent);
                    }
                }
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
