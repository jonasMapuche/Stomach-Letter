using Android.Content;
using Android.Telephony;
using Letter.Models;

namespace Letter.Platforms.Android.Broadcasts
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class PhoneBroadcast : BroadcastReceiver
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
        public PhoneBroadcast()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"phone\" broadcast failed!");
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
                if (this._error_off) throw new InvalidOperationException("Operation on receive \"Phone\" broadcast failed!");

                if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
                {
                    string? state = intent.GetStringExtra(TelephonyManager.ExtraState);
                    if (state == TelephonyManager.ExtraStateRinging)
                    {
                        string? phoneNumber = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                        Mechanism mechanism = new Mechanism();
                        mechanism.name = phoneNumber;
                        mechanism.implied = phoneNumber;
                        Receiver.Add(mechanism);
                        try
                        {
                            Call(context);
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message);
                        }
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
        private void Call(Context context)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call \"Phone\" broadcast failed!");

                TelephonyManager telephonyManager = (TelephonyManager)context.GetSystemService(Context.TelephonyService);

                Java.Lang.Class serviceClass = Java.Lang.Class.FromType(typeof(TelephonyManager));
                Java.Lang.Reflect.Method method = serviceClass.GetDeclaredMethod("getITelephony");
                method.Accessible = true;
                Java.Lang.Object? iTelephony = method.Invoke(telephonyManager);

                Java.Lang.Reflect.Method telephonyInterface = iTelephony.Class.GetDeclaredMethod("answerRingingCall");
                telephonyInterface.Accessible = true;
                telephonyInterface.Invoke(iTelephony);
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
