using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class SMSBot : ISMSBot
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
        private Dictionary<string, string> _choose;
        private Dictionary<string, string> _options;
        private Dictionary<string, string> _setup;
        private Dictionary<string, string> _write;
        private Dictionary<string, string> _message;
        private Dictionary<string, string> _and;
        private Dictionary<string, string> _select;
        private Dictionary<string, string> _phone;
        private Dictionary<string, string> _send;
        private Dictionary<string, string> _listen;
        private Dictionary<string, string> _post;
        private Dictionary<string, string> _communication;
        private Dictionary<string, string> _or;
        private Dictionary<string, string> _generate;

        private SettingService _settingService;
        #endregion

        #region CONSTRUCTOR
        public SMSBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"SMS\" bot failed!");
                else this.error_message = string.Empty;

                if (SettingService.Instance == null) return;
                this._settingService = SettingService.Instance;

                this._terminate = this._settingService.Terminate;
                this._bot = this._settingService.Bot;
                this._choose = this._settingService.Choose;
                this._options = this._settingService.Options;
                this._setup = this._settingService.Setup;
                this._write = this._settingService.Write;
                this._message = this._settingService.Message;
                this._and = this._settingService.And;
                this._select = this._settingService.Select;
                this._phone = this._settingService.Phone;
                this._send = this._settingService.Send;
                this._listen = this._settingService.Listen;
                this._post = this._settingService.Post;
                this._communication = this._settingService.Communicaton;
                this._or = this._settingService.Or;
                this._generate = this._settingService.Generate;
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
        public async Task<List<string>> SelectKind(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select setup \"SMS\" bot failed!");

                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string term = string.Empty;
                List<string> ask = new List<string>();
                term = $"{choose.ToArray()[0]} {options.ToArray()[0]}: ";
                ask.Add(term);
                term = $"{send.ToArray()[0]}";
                ask.Add(term);
                term = $"{listen.ToArray()[0]}";
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

        private async Task<List<string>> SelectSetup(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select setup \"SMS\" bot failed!");

                HashSet<string> write = this._write
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> phone = this._phone
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
                term = $"{write.ToArray()[0]} {phone.ToArray()[0]} {and.ToArray()[0]} {send.ToArray()[0]} {or.ToArray()[0]} {choose.ToArray()[0]} {options.ToArray()[0]}: ";
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

        private async Task<List<string>> SelectSend(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select send \"SMS\" bot failed!");

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

        public async Task<List<string>> SelectTerminate(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select terminate \"SMS\" bot failed!");

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string term = string.Empty;
                List<string> ask = new List<string>();
                term = $"{choose.ToArray()[0]} {options.ToArray()[0]}: ";
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

        private async Task<string> Send(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send \"SMS\" bot failed!");

                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> select = this._select
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(send.ToArray(), parameter) != -1) ask = $"{select.ToArray()[0]} {message.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Generate(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send \"SMS\" bot failed!");

                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> generate = this._generate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(generate.ToArray(), parameter) != -1) ask = $"{send.ToArray()[0]} {message.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Setup(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup \"SMS\" bot failed!");

                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(setup.ToArray(), parameter) != -1) ask = $"{setup.ToArray()[0]} {message.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Listen(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen \"SMS\" bot failed!");

                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(listen.ToArray(), parameter) != -1) ask = $"{listen.ToArray()[0]} {message.ToArray()[0]}.";
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
                if (this._error_off) throw new InvalidOperationException("Operation select \"SMS\" bot failed!");

                HashSet<string> setups = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> sends = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listens = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool send = false;
                bool setup = false;
                bool listen = false;
                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);
                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(sends.ToArray(), memo.Text) != -1) send = true;
                    if (Array.IndexOf(setups.ToArray(), memo.Text) != -1) setup = true;
                    if (Array.IndexOf(listens.ToArray(), memo.Text) != -1) listen = true;
                }
                List<string> response = new List<string>();
                if (send && !setup) response = await SelectSetup(language);
                if (setup) response = await SelectSend(language);
                if (listen) response = await SelectTerminate(language);
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
                if (this._error_off) throw new InvalidOperationException("Operation load \"SMS\" bot failed!");

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> post = this._post
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> generate = this._generate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(listen.ToArray(), parameter) != -1)
                {
                    ask = await Listen(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(send.ToArray(), parameter) != -1)
                {
                    ask = await Send(language, parameter);
                    result.Add(ask);
                }
                if (Array.IndexOf(generate.ToArray(), parameter) != -1)
                {
                    ask = await Generate(language, parameter);
                    result.Add(ask);
                    ask = await Terminate(language);
                    result.Add(ask);
                }
                if (Array.IndexOf(setup.ToArray(), parameter) != -1)
                {
                    ask = await Setup(language, parameter);
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
                if (this._error_off) throw new InvalidOperationException("Operation terminate \"SMS\" bot failed!");

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
