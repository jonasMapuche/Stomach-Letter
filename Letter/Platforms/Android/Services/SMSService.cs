using Android.Content;
using Android.Provider;
using Android.Telephony;
using Letter.Interfaces;
using Letter.Models;
using Letter.Platforms.Android.Broadcasts;

namespace Letter.Platforms.Android.Services
{
    public class SMSService : ISMSService
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
        public List<Message> Receiver { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SMSService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"SMS\" service failed!");
                else this.error_message = string.Empty;

                this.Receiver = new List<Message>();
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
        #endregion

        #region FUNCTION
        public void Send(string destination, string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send \"SMS\" service failed!");

                SmsManager sms = SmsManager.Default;
                IList<string>? parts = sms.DivideMessage(text);
                foreach (string part in parts)
                {
                    sms.SendTextMessage(destination, null, part, null, null);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void Scan()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan \"SMS\" service failed!");

                SMSBroadcast receiver = new SMSBroadcast();
                this.Receiver = receiver.Receiver;
                IntentFilter intentFilter = new IntentFilter(Telephony.Sms.Intents.SmsReceivedAction);
                Platform.AppContext.RegisterReceiver(receiver, intentFilter, ReceiverFlags.Exported);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Message> NetworkActive()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation network active \"SMS\" service failed!");

                List<Message> networks = new List<Message>();
                SubscriptionManager? subscription = (SubscriptionManager)Platform.AppContext.GetSystemService(Context.TelephonySubscriptionService);
                if (subscription != null)
                {
                    IList<SubscriptionInfo>? infos = subscription.ActiveSubscriptionInfoList;
                    if (infos != null)
                    {
                        foreach (SubscriptionInfo info in infos)
                        {
                            int id = info.SubscriptionId;
                            string name = info.CarrierName;
                            Message memo = new Message();
                            memo.Text = $"CARRIER {name} | SUBSCRIPTION: {id}";
                            memo.Implied = id.ToString();
                            networks.Add(memo);
                        }
                    }
                }
                return networks;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public Message NetworkCurrent()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation network current \"SMS\" service failed!");

                TelephonyManager? telephony = (TelephonyManager)Platform.CurrentActivity.GetSystemService(Context.TelephonyService);
                int id = telephony.SubscriptionId;
                string name = telephony.SimCarrierIdName;
                Message memo = new Message();
                memo.Text = $"CARRIER {name} | SUBSCRIPTION: {id}";
                memo.Implied = id.ToString();
                return memo;
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
