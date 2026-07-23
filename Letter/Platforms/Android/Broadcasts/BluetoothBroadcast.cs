using Android.Bluetooth;
using Android.Content;
using Letter.Models;

namespace Letter.Platforms.Android.Broadcasts
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class BluetoothBroadcast : BroadcastReceiver
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
        public BluetoothBroadcast()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Bluetooth\" broadcast failed!");
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
                if (this._error_off) throw new InvalidOperationException("Operation on receiver \"Bluetooth\" broadcast failed!");

                string action = intent.Action;
                if (BluetoothDevice.ActionFound.Equals(action))
                {
                    BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                    string appliance = $"{device.Name} - {device.Address}";
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = appliance;
                    mechanism.implied = device.Address;
                    Receiver.Add(mechanism);
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
