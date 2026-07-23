using Android.Content;
using Android.Net.Wifi;
using Letter.Models;

namespace Letter.Platforms.Android.Broadcasts
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class WiFiBroadcast : BroadcastReceiver
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
        public WiFiBroadcast()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"WiFi\" broadcast failed!");
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
        public override void OnReceive(Context? context, Intent? intent)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on receiver \"WiFi\" broadcast failed!");

                WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
                IList<ScanResult>? results = wifiManager.ScanResults;
                if (results != null)
                {
                    foreach (ScanResult result in results)
                    {
                        string appliance = $"SSID: {result.Ssid} | BSSID: {result.Bssid} | RSSI: {result.Level} dBm";
                        Mechanism mechanism = new Mechanism();
                        mechanism.name = appliance;
                        mechanism.implied = result.Bssid;
                        Receiver.Add(mechanism);
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
