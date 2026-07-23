using Android.Content;
using Android.Media;
using Android.OS;
using Android.Telecom;
using Android.Telephony;
using Java.IO;
using Letter.Interfaces;
using Letter.Models;
using Letter.Platforms.Android.Broadcasts;
using Letter.Platforms.Android.Connections;
using Stream = Android.Media.Stream;
using Uri = Android.Net.Uri;

namespace Letter.Platforms.Android.Services
{
    public class PhoneService : IPhoneService
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
        public PhoneService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Phone\" service failed!");
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
        #endregion

        #region FUNCTION
        public void Call(string number)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call \"Phone\" service failed!");

                Uri? uri = Uri.Parse($"tel:{number}");
                Intent intent = new Intent(Intent.ActionCall, uri);
                intent.AddFlags(ActivityFlags.NewTask);
                Platform.AppContext.StartActivity(intent);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void Call(string numero, string caminhoAudio)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call \"Phone\" service failed!");

                Context context = Platform.AppContext;
                TelecomManager? telecomManager = (TelecomManager)context.GetSystemService(Context.TelecomService);
                Uri? uri = Uri.FromParts(PhoneAccount.SchemeTel, numero, null);

                Bundle extras = new Bundle();
                PhoneAccountHandle callHandle = new PhoneAccountHandle(new ComponentName(context, Java.Lang.Class.FromType(typeof(PhoneConnection))), "MEU_ID_CONTA");

                extras.PutParcelable(TelecomManager.ExtraPhoneAccountHandle, callHandle);
                telecomManager.PlaceCall(uri, extras);

                InjectAudio(caminhoAudio);
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
                if (this._error_off) throw new InvalidOperationException("Operation scan \"Phone\" service failed!");

                PhoneBroadcast receiver = new PhoneBroadcast();
                this.Receiver = receiver.Receiver;
                IntentFilter filter = new IntentFilter(TelephonyManager.ActionPhoneStateChanged);
                Platform.AppContext.RegisterReceiver(receiver, filter);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void InjectAudio(string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation inject audio \"Phone\" service failed!");

                int sampleRate = 44100;
                ChannelIn channelIn = ChannelIn.Mono;
                Encoding encoding = Encoding.Pcm16bit;

                int bufferSize = AudioRecord.GetMinBufferSize(sampleRate, channelIn, encoding);
                var audioTrack = new AudioTrack(
                    Stream.VoiceCall,
                    sampleRate,
                    ChannelOut.Mono,
                    encoding,
                    bufferSize,
                    AudioTrackMode.Stream);

                audioTrack.Play();

                FileInputStream fis = new FileInputStream(file_path);
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                try
                {
                    while ((bytesRead = fis.Read(buffer)) != -1)
                    {
                        audioTrack.Write(buffer, 0, bytesRead);
                    }
                }
                catch (Java.IO.IOException e)
                {
                    e.PrintStackTrace();
                }
                finally
                {
                    audioTrack.Stop();
                    audioTrack.Release();
                    fis.Close();
                }
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
