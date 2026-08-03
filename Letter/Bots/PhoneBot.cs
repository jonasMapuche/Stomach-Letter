using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class PhoneBot : IPhoneBot
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
        private Dictionary<string, string> _terminate;
        private Dictionary<string, string> _bot;
        private Dictionary<string, string> _message;
        private Dictionary<string, string> _call;
        private Dictionary<string, string> _listen;
        private Dictionary<string, string> _options;
        private Dictionary<string, string> _choose;
        private Dictionary<string, string> _write;
        private Dictionary<string, string> _and;
        private Dictionary<string, string> _send;
        private Dictionary<string, string> _phone;
        private Dictionary<string, string> _or;
        private Dictionary<string, string> _select;
        private Dictionary<string, string> _load;
        private Dictionary<string, string> _setup;

        private SettingService _settingService;
        #endregion

        #region CONSTRUCTOR
        public PhoneBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Phone\" bot failed!");
                else this.error_message = string.Empty;

                if (SettingService.Instance == null) return;
                this._settingService = SettingService.Instance;

                this._terminate = this._settingService.Terminate;
                this._bot = this._settingService.Bot;
                this._message = this._settingService.Message;
                this._call = this._settingService.Call;
                this._listen = this._settingService.Listen;
                this._options = this._settingService.Options;
                this._choose = this._settingService.Choose;
                this._write = this._settingService.Write;
                this._and = this._settingService.And;
                this._or = this._settingService.Or;
                this._send = this._settingService.Send;
                this._phone = this._settingService.Phone;
                this._select = this._settingService.Select;
                this._load = this._settingService.Load;
                this._setup = this._settingService.Setup;
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
        public async Task<List<string>> SelectSetup(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select setup \"Phone\" bot failed!");

                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> call = this._call
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
                term = $"{call.ToArray()[0]}";
                ask.Add(term);
                term = $"{listen.ToArray()[0]}";
                ask.Add(term);
                term = $"{message.ToArray()[0]}";
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

        private async Task<List<string>> SelectCall(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select call \"Phone\" bot failed!");

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

        public async Task<List<string>> SelectTerminate(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select terminate \"Phone\" bot failed!");

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

        private async Task<string> Call(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call \"Phone\" bot failed!");

                HashSet<string> call = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> select = this._select
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(call.ToArray(), parameter) != -1) ask = $"{select.ToArray()[0]} {phone.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Message(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation message \"Phone\" bot failed!");

                HashSet<string> call = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> select = this._select
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(message.ToArray(), parameter) != -1) ask = $"{select.ToArray()[0]} {message.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> CallPhone(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call phone \"Phone\" bot failed!");

                HashSet<string> call = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(send.ToArray(), parameter) != -1) ask = $"{call.ToArray()[0]} {phone.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> CallMessage(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call message \"Phone\" bot failed!");

                HashSet<string> load = this._load
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> call = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(load.ToArray(), parameter) != -1) ask = $"{call.ToArray()[0]} {message.ToArray()[0]}.";
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
                if (this._error_off) throw new InvalidOperationException("Operation listen \"Phone\" bot failed!");

                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(listen.ToArray(), parameter) != -1) ask = $"{listen.ToArray()[0]} {phone.ToArray()[0]}.";
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

                HashSet<string> calls = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> reports = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listens = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool call = false;
                bool message = false;
                bool listen = false;
                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);
                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(calls.ToArray(), memo.Text) != -1) call = true;
                    if (Array.IndexOf(reports.ToArray(), memo.Text) != -1) message = true;
                    if (Array.IndexOf(listens.ToArray(), memo.Text) != -1) listen = true;
                }
                List<string> response = new List<string>();
                if (call) response = await SelectCall(language);
                if (message) response = await SelectCall(language);
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
                HashSet<string> call = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> load = this._load
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(call.ToArray(), parameter) != -1)
                {
                    ask = await Call(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(send.ToArray(), parameter) != -1)
                {
                    ask = await CallPhone(language, parameter);
                    result.Add(ask);
                    ask = await Terminate(language);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(message.ToArray(), parameter) != -1)
                {
                    ask = await Message(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(load.ToArray(), parameter) != -1)
                {
                    ask = await CallMessage(language, parameter);
                    result.Add(ask);
                    ask = await Terminate(language);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(listen.ToArray(), parameter) != -1)
                {
                    ask = await Listen(language, parameter);
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
                if (this._error_off) throw new InvalidOperationException("Operation terminate \"Phone\" bot failed!");

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