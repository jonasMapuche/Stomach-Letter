using Letter.Bots;
using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services.Interfaces;

namespace Letter.Services
{
    public class BotService : IBotService
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
        private ICameraBot _cameraBot;
        private IRecordBot _recordBot;
        private IShareBot _shareBot;
        private IDecisionTreeBot _decisionTreeBot;
        private ISMSBot _sMSBot;
        private ISpeakBot _speakBot;
        private IWiFiBot _wiFiBot;
        #endregion

        #region CONSTRUCTOR
        public BotService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Bot\" service failed!");
                else this.error_message = string.Empty;

                this._cameraBot = new CameraBot();
                this._recordBot = new RecordBot();
                this._shareBot = new ShareBot();
                this._sMSBot = new SMSBot();
                this._speakBot = new SpeakBot();
                this._wiFiBot = new WiFiBot();
                this._decisionTreeBot = new DecisionTreeBot();
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
        public async Task<List<string>> LoadCamera(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load camera \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._cameraBot.SelectPreview(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> LoadAudio(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load audio \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._recordBot.SelectAudio(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> LoadShare(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load share \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._shareBot.SelectShare(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> LoadSMS(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load sms \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._sMSBot.SelectKind(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> LoadSpeaker(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load speaker \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._speakBot.SelectSpeaker(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> LoadWiFi(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load wifi \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._wiFiBot.SelectSetup(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SMSChoose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation SMS choose \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._sMSBot.Select(language, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SpeakerChoose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speaker choose \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._speakBot.Select(language, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> CameraChoose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation camera choose \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._cameraBot.Select(language, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> RecordChoose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation record choose \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._recordBot.Select(language, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> ShareChoose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation share choose \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._shareBot.Select(language, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> WiFiChoose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation wifi choose \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._wiFiBot.Select(language, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> CaptureCamera(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture camera \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._cameraBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> RecordAudio(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation record audio \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._recordBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> ShareFile(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation share file \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._shareBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SMS(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load message \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._sMSBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SpeakText(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speak text \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._speakBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> WiFi(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation wifi \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._wiFiBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> DecisionTree(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation decision tree \"Bot\" service failed!");

                string response = await this._decisionTreeBot.Sentence(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> DecisionTree(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation decision tree \"Bot\" service failed!");

                List<string> response = new List<string>();
                response = await this._decisionTreeBot.Load(language, parameter, messages);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> DecisionTree(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation decision tree \"Bot\" service failed!");

                string response = await this._decisionTreeBot.Choose(language, messages);
                return response;
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
