using Android.Content;
using Android.Media;
using Android.OS;
using Android.Speech.Tts;
using Letter.Enums;
using Letter.Models;
using Letter.Services;
using Stream = Android.Media.Stream;
using TextToSpeech = Android.Speech.Tts.TextToSpeech;

namespace Letter.Platforms.Android.Services
{
    public class SpeechService : Java.Lang.Object, TextToSpeech.IOnInitListener
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
        #endregion

        #region VARIABLE
        private Context _context;
        private AudioManager _audioManager;
        private TextToSpeech _tts;
        private Language _language_english;
        private Language _language_deutsch;
        private Language _language_italiano;
        private Language _language_francais;
        private Language _language_espanol;
        private SettingService _settingService;

        private string _text;
        private string _language;
        private float _volume;
        private float _pitch;
        #endregion

        #region CONSTRUCTOR
        public SpeechService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Speech\" service failed!");
                else this.error_message = string.Empty;

                if (SettingService.Instance == null) return;
                this._settingService = SettingService.Instance;

                this._language_english = this._settingService.English;
                this._language_deutsch = this._settingService.Deutsch;
                this._language_italiano = this._settingService.Italino;
                this._language_francais = this._settingService.Francais;
                this._language_espanol = this._settingService.Espanol;
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
        public void OnInit(OperationResult status)
        {
            if (status == OperationResult.Success && !string.IsNullOrEmpty(this._text))
            {
                SpeakNow(this._text, this._language, this._pitch, this._volume);
            }
        }
        #endregion

        #region FUNCTION
        public void SetUp()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation set up \"Speech\" service failed!");

                this._context = Platform.AppContext;
                this._audioManager = (AudioManager)this._context.GetSystemService(Context.AudioService);
                this._tts = new TextToSpeech(this._context, this);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void Speak(string text, string language, Profit profit, float pitch, float volume)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speak \"Speech\" service failed!");

                this._text = text;
                this._language = language;
                this._pitch = pitch;
                this._volume = volume;
                AudioOutput(profit);
                if (this._tts != null)
                    SpeakNow(text, language, pitch, volume);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void AudioOutput(Profit profit)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation audio output \"Speech\" service failed!");

                this._audioManager.Mode = Mode.InCommunication;
                switch (profit)
                {
                    case Profit.Bluetooth:
                        this._audioManager.BluetoothScoOn = true;
                        this._audioManager.StartBluetoothSco();
                        this._audioManager.SpeakerphoneOn = false;
                        break;

                    case Profit.Speaker:
                        this._audioManager.StopBluetoothSco();
                        this._audioManager.BluetoothScoOn = false;
                        this._audioManager.SpeakerphoneOn = true;
                        break;

                    case Profit.Phone:
                    default:
                        this._audioManager.StopBluetoothSco();
                        this._audioManager.BluetoothScoOn = false;
                        this._audioManager.SpeakerphoneOn = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void SpeakNow(string text, string language, float pitch, float volume)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speak \"Speech\" service failed!");

                Bundle bundle = new Bundle();
                bundle.PutString(TextToSpeech.Engine.KeyParamVolume, volume.ToString());
                bundle.PutString(TextToSpeech.Engine.KeyParamStream, ((int)Stream.Music).ToString());

                ICollection<Java.Util.Locale>? locales = this._tts.AvailableLanguages;
                Java.Util.Locale? locale = null;
                if (language == this._language_english.Uppercase) locale = locales?.FirstOrDefault(l => l.Language == this._language_english.Code && l.Country == this._language_english.Region);
                if (language == this._language_deutsch.Uppercase) locale = locales?.FirstOrDefault(l => l.Language == this._language_deutsch.Code && l.Country == this._language_deutsch.Region);
                if (language == this._language_italiano.Uppercase) locale = locales?.FirstOrDefault(l => l.Language == this._language_italiano.Code && l.Country == this._language_italiano.Region);
                if (language == this._language_francais.Uppercase) locale = locales?.FirstOrDefault(l => l.Language == this._language_francais.Code && l.Country == this._language_francais.Region);
                if (language == this._language_espanol.Uppercase) locale = locales?.FirstOrDefault(l => l.Language == this._language_espanol.Code && l.Country == this._language_espanol.Region);

                this._tts.SetPitch(pitch);
                this._tts.SetLanguage(locale);
                this._tts.Speak(text, QueueMode.Flush, bundle, "TtsUtteranceId");
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
