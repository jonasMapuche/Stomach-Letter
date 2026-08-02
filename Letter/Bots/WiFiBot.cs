using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class WiFiBot : IWiFiBot
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
        private Dictionary<string, string> _setup;
        private Dictionary<string, string> _choose;
        private Dictionary<string, string> _options;
        private Dictionary<string, string> _wifi;
        private Dictionary<string, string> _ping;
        private Dictionary<string, string> _scan;
        private Dictionary<string, string> _write;
        private Dictionary<string, string> _and;
        private Dictionary<string, string> _address;
        private Dictionary<string, string> _send;
        private Dictionary<string, string> _or;
        private Dictionary<string, string> _select;

        private SettingService _settingService;
        #endregion

        #region CONSTRUCTOR
        public WiFiBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"WiFi\" bot failed!");
                else this.error_message = string.Empty;

                if (SettingService.Instance == null) return;
                this._settingService = SettingService.Instance;

                this._terminate = this._settingService.Terminate;
                this._bot = this._settingService.Bot;
                this._setup = this._settingService.Setup;
                this._choose = this._settingService.Choose;
                this._options = this._settingService.Options;
                this._wifi = this._settingService.WiFi;
                this._scan = this._settingService.Scan;
                this._ping = this._settingService.Ping;
                this._write = this._settingService.Write;
                this._and = this._settingService.And;
                this._address = this._settingService.Address;
                this._or = this._settingService.Or;
                this._send = this._settingService.Send;
                this._select = this._settingService.Select;
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
                if (this._error_off) throw new InvalidOperationException("Operation select setup \"WiFi\" bot failed!");

                HashSet<string> wifi = this._wifi
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
                term = $"{wifi.ToArray()[0]}";
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

        private async Task<List<string>> SelectScan(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select scan \"WiFi\" bot failed!");

                HashSet<string> scan = this._scan
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
                HashSet<string> ping = this._ping
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string term = string.Empty;
                List<string> ask = new List<string>();
                term = $"{choose.ToArray()[0]} {options.ToArray()[0]}: ";
                ask.Add(term);
                term = $"{scan.ToArray()[0]}";
                ask.Add(term);
                term = $"{ping.ToArray()[0]}";
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

        private async Task<List<string>> SelectPing(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select ping \"WiFi\" bot failed!");

                HashSet<string> write = this._write
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
                HashSet<string> address = this._address
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string term = string.Empty;
                List<string> ask = new List<string>();
                term = $"{write.ToArray()[0]} {address.ToArray()[0]} {and.ToArray()[0]} {send.ToArray()[0]} {or.ToArray()[0]} {choose.ToArray()[0]} {options.ToArray()[0]}: ";
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

        private async Task<string> Setup(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup \"WiFi\" bot failed!");

                HashSet<string> wifi = this._wifi
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(wifi.ToArray(), parameter) != -1) ask += $"{setup.ToArray()[0]} {wifi.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Scan(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan \"WiFi\" bot failed!");

                HashSet<string> wifi = this._wifi
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(scan.ToArray(), parameter) != -1) ask += $"{scan.ToArray()[0]} {wifi.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Ping(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation ping \"WiFi\" bot failed!");

                HashSet<string> ping = this._ping
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> select = this._select
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(ping.ToArray(), parameter) != -1) ask += $"{select.ToArray()[0]} {ping.ToArray()[0]}.";
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
                if (this._error_off) throw new InvalidOperationException("Operation send \"WiFi\" bot failed!");

                HashSet<string> ping = this._ping
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(send.ToArray(), parameter) != -1) ask += $"{scan.ToArray()[0]} {ping.ToArray()[0]}.";
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
                if (this._error_off) throw new InvalidOperationException("Operation select \"WiFi\" bot failed!");

                HashSet<string> scans = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> pings = this._ping
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> wifis = this._wifi
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool scan = false;
                bool ping = false;
                bool wifi = false;

                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);
                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(scans.ToArray(), memo.Text) != -1) scan = true;
                    if (Array.IndexOf(pings.ToArray(), memo.Text) != -1) ping = true;
                    if (Array.IndexOf(wifis.ToArray(), memo.Text) != -1) wifi = true;
                }
                List<string> response = new List<string>();
                if (wifi && !scan && !ping) response = await SelectScan(language);
                if (wifi && scan && !ping) response = await SelectScan(language);
                if (wifi && ping) response = await SelectPing(language);
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
                if (this._error_off) throw new InvalidOperationException("Operation load \"WiFi\" bot failed!");

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> ping = this._ping
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> wifi = this._wifi
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(wifi.ToArray(), parameter) != -1)
                {
                    ask = await Setup(language, parameter);
                    result.Add(ask);
                }
                if (Array.IndexOf(scan.ToArray(), parameter) != -1)
                {
                    ask = await Scan(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(ping.ToArray(), parameter) != -1)
                {
                    ask = await Ping(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(send.ToArray(), parameter) != -1)
                {
                    ask = await Send(language, parameter);
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

        private async Task<string> Terminate(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation terminate \"WiFi\" bot failed!");

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
