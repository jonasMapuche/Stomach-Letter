using Android.Runtime;
using Android.Speech.Tts;
using Letter.Helpers;
using Letter.Interfaces;
using Letter.Models;
using TextToSpeech = Android.Speech.Tts.TextToSpeech;

namespace Letter.Platforms.Android.Services
{
    public class TextSpeakService : Java.Lang.Object, ITextSpeakService, TextToSpeech.IOnInitListener
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
        private TextToSpeech? _textToSpeech;
        private string? _text;
        #endregion

        #region CONSTRUCTOR
        public TextSpeakService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Text Speak\" service failed!");
                else this.error_message = string.Empty;

                this._textToSpeech = new TextToSpeech(Platform.AppContext, this);
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
        public void OnInit([GeneratedEnum] OperationResult status)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on init \"Text Speak\" service failed!");

                if (status == OperationResult.Success)
                {
                    if (!string.IsNullOrEmpty(this._text))
                        this._textToSpeech.Speak(this._text, QueueMode.Flush, null, null);
                }
                else
                    throw new InvalidOperationException("Error operation!");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTION
        public string FileText(string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation file text \"Text Speak\" service failed!");

                this._text = text;
                OperationResult result = OperationResult.Error;
                string file_name = FilePath.MountFileName("mp3");
                string file_path = FilePath.MountFilePath(file_name);
                if (this._textToSpeech != null && this._textToSpeech.IsSpeaking == false)
                {
                    Dictionary<string, string> parameter = new Dictionary<string, string>();
                    parameter.Add(TextToSpeech.Engine.KeyParamUtteranceId, "fileSynthesis");
                    result = this._textToSpeech.SynthesizeToFile(text, parameter, file_path);
                }
                if (result == OperationResult.Success) return file_path;
                else return string.Empty;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> CreateFileUTF8(string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation save file \"Text Speak\" service failed!");

                string file_name = FilePath.MountFileName("mp3");
                string file_path = FilePath.MountFilePath(file_name);

                FileStream fs = new(file_path, FileMode.OpenOrCreate);
                if (text != string.Empty)
                {
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    await sw.WriteAsync(text);
                    sw.Close();
                }
                fs.Close();

                return file_path;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> CreateFileMAUI()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation create file in maui \"Perception\" service failed!");

                string file_name = FilePath.MountFileName("mp3");
                string file_path = FilePath.MountFilePath(file_name);

                using (FileStream stream = File.OpenWrite(file_path))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    await writer.WriteLineAsync("Conteúdo do arquivo stream no MAUI");
                    await writer.WriteLineAsync($"Criado em: {DateTime.Now}");
                }
                return file_path;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<FileStream> ReadStream(Audio audio)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation read stream \"Text Speak\" service failed!");

                string file1 = await CreateFileUTF8("Net maui send test file!");
                string file2 = await CreateFileMAUI();

                string file_path = audio.url;
                FileStream fs = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, true);
                return fs;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void SpeakText(string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speak text \"Text Speak\" service failed!");

                if (this._textToSpeech != null && this._textToSpeech.IsSpeaking == false)
                    this._textToSpeech.Speak(text, QueueMode.Flush, null, null);
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
