using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class SpeakBot : ISpeakBot
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
        private Dictionary<string, string> _terminate;
        private Dictionary<string, string> _bot;
        private Dictionary<string, string> _speakers;
        private Dictionary<string, string> _choose;
        private Dictionary<string, string> _options;
        private Dictionary<string, string> _phone;
        private Dictionary<string, string> _speaker;
        private Dictionary<string, string> _message;
        private Dictionary<string, string> _write;
        private Dictionary<string, string> _and;
        private Dictionary<string, string> _send;
        private Dictionary<string, string> _speak;
        private Dictionary<string, string> _to;
        private Dictionary<string, string> _text;
        private Dictionary<string, string> _or;
        private Dictionary<string, string> _select;
        private Dictionary<string, string> _bluetooth;

        private SettingService _settingService;
        #endregion

        #region CONSTRUCTOR
        public SpeakBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Speak\" bot failed!");
                else this.error_message = string.Empty;

                if (SettingService.Instance == null) return;
                this._settingService = SettingService.Instance;

                this._terminate = this._settingService.Terminate;
                this._bot = this._settingService.Bot;
                this._speakers = this._settingService.Speakers;
                this._options = this._settingService.Options;
                this._choose = this._settingService.Choose;
                this._speaker = this._settingService.Speaker;
                this._phone = this._settingService.Phone;
                this._write = this._settingService.Write;
                this._message = this._settingService.Message;
                this._and = this._settingService.And;
                this._send = this._settingService.Send;
                this._speak = this._settingService.Speak;
                this._to = this._settingService.To;
                this._text = this._settingService.Text;
                this._or = this._settingService.Or;
                this._select = this._settingService.Select;
                this._bluetooth = this._settingService.Bluetooth;
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
        public async Task<List<string>> SelectSpeaker(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select speaker \"Speak\" bot failed!");

                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> speaker = this._speaker
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> bluetooth = this._bluetooth
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string term = string.Empty;
                List<string> ask = new List<string>();

                term = $"{choose.ToArray()[0]} {options.ToArray()[0]}: ";
                ask.Add(term);
                term = $"{phone.ToArray()[0]}";
                ask.Add(term);
                term = $"{speaker.ToArray()[0]}";
                ask.Add(term);
                term = $"{bluetooth.ToArray()[0]}";
                ask.Add(term);
                term = $"{terminate.ToArray()[0]}";
                ask.Add(term);
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<string>> SelectText(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select text \"Speak\" bot failed!");

                HashSet<string> write = this._write
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> and = this._and
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> or = this._or
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string term = string.Empty;
                List<string> ask = new List<string>();

                term = $"{write.ToArray()[0]} {message.ToArray()[0]} {and.ToArray()[0]} {send.ToArray()[0]} {or.ToArray()[0]} {choose.ToArray()[0]} {options.ToArray()[0]}: ";
                ask.Add(term);
                term = $"{terminate.ToArray()[0]}";
                ask.Add(term);
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Output(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation text \"Record\" bot failed!");

                HashSet<string> select = this._select
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> bluetooth = this._bluetooth
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> speaker = this._speaker
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(phone.ToArray(), parameter) != -1) ask = $"{select.ToArray()[0]} {phone.ToArray()[0]}.";
                if (Array.IndexOf(speaker.ToArray(), parameter) != -1) ask = $"{select.ToArray()[0]} {speaker.ToArray()[0]}.";
                if (Array.IndexOf(bluetooth.ToArray(), parameter) != -1) ask = $"{select.ToArray()[0]} {bluetooth.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Send(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation text \"Speak\" bot failed!");

                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> speak = this._speak
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> to = this._to
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> text = this._text
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(send.ToArray(), parameter) != -1) ask = $"{speak.ToArray()[0]} {to.ToArray()[0]} {text.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> Select(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select \"Speak\" bot failed!");

                HashSet<string> speakers = this._speakers
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> sends = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool speaker = false;
                bool send = false;

                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);

                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(speakers.ToArray(), memo.Text) != -1) speaker = true;
                    if (Array.IndexOf(sends.ToArray(), memo.Text) != -1) send = true;
                }

                List<string> response = new List<string>();
                if (speaker || send) response = await SelectText(language);
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> Load(string language, string parameter, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load \"Speak\" bot failed!");

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> speakers = this._speakers
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(speakers.ToArray(), parameter) != -1)
                {
                    ask = await Output(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(send.ToArray(), parameter) != -1)
                {
                    ask = await Send(language, parameter);
                    result.Add(ask);
                    ask = await Terminate(language);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(terminate.ToArray(), parameter) != -1)
                {
                    ask = await Terminate(language);
                    result.Add(ask);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> Terminate(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation terminate \"Speak\" bot failed!");

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> bot = this._bot
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = $"{terminate.ToArray()[0]} {bot.ToArray()[0]}.";
                return ask;
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
