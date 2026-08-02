using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class BluetoothBot : IBluetoothBot
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
        private Dictionary<string, string> _bluetooth;
        private Dictionary<string, string> _scan;
        private Dictionary<string, string> _connect;

        private SettingService _settingService;
        #endregion

        #region CONSTRUCTOR
        public BluetoothBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Bluetooth\" bot failed!");
                else this.error_message = string.Empty;

                if (SettingService.Instance == null) return;
                this._settingService = SettingService.Instance;

                this._terminate = this._settingService.Terminate;
                this._bot = this._settingService.Bot;
                this._setup = this._settingService.Setup;
                this._choose = this._settingService.Choose;
                this._options = this._settingService.Options;
                this._bluetooth = this._settingService.Bluetooth3;
                this._scan = this._settingService.Scan;
                this._connect = this._settingService.Connect;
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
                if (this._error_off) throw new InvalidOperationException("Operation select setup \"Bluetooth\" bot failed!");

                HashSet<string> setup = this._setup
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
                term = $"{setup.ToArray()[0]}";
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

        public async Task<List<string>> SelectScan(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select scan \"Bluetooth\" bot failed!");

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

                string term = string.Empty;
                List<string> ask = new List<string>();
                term = $"{choose.ToArray()[0]} {options.ToArray()[0]}: ";
                ask.Add(term);
                term = $"{scan.ToArray()[0]}";
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
                if (this._error_off) throw new InvalidOperationException("Operation setup \"Bluetooth\" bot failed!");

                HashSet<string> bluetooth = this._bluetooth
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(setup.ToArray(), parameter) != -1) ask += $"{setup.ToArray()[0]} {bluetooth.ToArray()[0]}.";
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
                if (this._error_off) throw new InvalidOperationException("Operation scan \"Bluetooth\" bot failed!");

                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> bluetooth = this._bluetooth
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(scan.ToArray(), parameter) != -1) ask += $"{scan.ToArray()[0]} {bluetooth.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Connect(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation connect \"Bluetooth\" bot failed!");

                HashSet<string> connect = this._connect
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> bluetooth = this._bluetooth
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(connect.ToArray(), parameter) != -1) ask += $"{connect.ToArray()[0]} {bluetooth.ToArray()[0]}.";
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
                if (this._error_off) throw new InvalidOperationException("Operation select \"Bluetooth\" bot failed!");

                HashSet<string> setups = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scans = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool setup = false;
                bool scan = false;

                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);
                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(setups.ToArray(), memo.Text) != -1) setup = true;
                    if (Array.IndexOf(scans.ToArray(), memo.Text) != -1) scan = true;
                }
                List<string> response = new List<string>();
                if (setup || scan) response = await SelectScan(language);
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
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> connect = this._connect
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(setup.ToArray(), parameter) != -1)
                {
                    ask = await Setup(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(scan.ToArray(), parameter) != -1)
                {
                    ask = await Scan(language, parameter);
                    result.Add(ask);
                    return result;
                }
                if (Array.IndexOf(connect.ToArray(), parameter) != -1)
                {
                    ask = await Connect(language, parameter);
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
