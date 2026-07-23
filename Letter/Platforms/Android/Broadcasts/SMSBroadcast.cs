using Android.Content;
using Android.Provider;
using Letter.Models;
using SmsMessage = Android.Telephony.SmsMessage;

namespace Letter.Platforms.Android.Broadcasts
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class SMSBroadcast : BroadcastReceiver
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
        public SMSBroadcast()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"SMS\" broadcast failed!");
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
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on receiver \"SMS\" broadcast failed!");

                if (intent.Action != Telephony.Sms.Intents.SmsReceivedAction)
                    return;
                SmsMessage[]? notes = Telephony.Sms.Intents.GetMessagesFromIntent(intent);
                foreach (SmsMessage note in notes)
                {
                    string sender = note.OriginatingAddress;
                    string body = note.MessageBody;
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = $"SENDER: {sender} | BODY: {body}";
                    mechanism.implied = $"{sender}; {body}";
                    this.Receiver.Add(mechanism);
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
