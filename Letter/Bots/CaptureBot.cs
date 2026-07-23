using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class CaptureBot : ICaptureBot
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
        private Dictionary<string, string> _turn;
        private Dictionary<string, string> _turn_on;
        private Dictionary<string, string> _flash;
        private Dictionary<string, string> _rotate;
        private Dictionary<string, string> _camera;
        private Dictionary<string, string> _terminate;
        private Dictionary<string, string> _bot;
        private Dictionary<string, string> _choose;
        private Dictionary<string, string> _options;

        private Dictionary<string, string> _front;
        private Dictionary<string, string> _rear;

        private Dictionary<string, string> _on;
        private Dictionary<string, string> _off;
        private Dictionary<string, string> _auto;

        private Dictionary<string, string> _start;
        private Dictionary<string, string> _stop;

        private Dictionary<string, string> _save;

        private Dictionary<string, string> _shoot;

        private Dictionary<string, string> _catch_flash;
        private Dictionary<string, string> _catch_rotate;
        private Dictionary<string, string> _catch_capture;

        private SettingService _settingService;
        #endregion

        #region CONSTRUCTOR
        public CaptureBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Capture\" bot failed!");
                else this.error_message = string.Empty;

                this._settingService = SettingService.Instance;

                this._turn = this._settingService.Turn;
                this._turn_on = this._settingService.Turn_On;
                this._flash = this._settingService.Flash;
                this._rotate = this._settingService.Rotate;
                this._camera = this._settingService.Camera;
                this._terminate = this._settingService.Terminate;
                this._bot = this._settingService.Bot;
                this._choose = this._settingService.Choose;
                this._options = this._settingService.Options;

                this._front = this._settingService.Front;
                this._rear = this._settingService.Rear;

                this._on = this._settingService.On;
                this._off = this._settingService.Off;
                this._auto = this._settingService.Auto;

                this._start = this._settingService.Start;
                this._stop = this._settingService.Stop;

                this._save = this._settingService.Save;

                this._shoot = this._settingService.Shoot;

                this._catch_flash = this._settingService.Catch_Flash;
                this._catch_rotate = this._settingService.Catch_Rotate;
                this._catch_capture = this._settingService.Catch_Capture;
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
        public async Task<string> Rotate(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation rotate \"Capture\" bot failed!");

                HashSet<string> front = this._front
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rear = this._rear
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

                string ask = $"Choose options: \"{front.ToArray()[0]}\" or \"{rear.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SelectRotate(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select rotate \"Capture\" bot failed!");

                HashSet<string> front = this._front
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rear = this._rear
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
                term = $"{front.ToArray()[0]}";
                ask.Add(term);
                term = $"{rear.ToArray()[0]}";
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

        public async Task<string> Flash(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation flash \"Capture\" bot failed!");

                HashSet<string> on = this._on
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> off = this._off
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> auto = this._auto
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

                string ask = $"Choose options: \"{on.ToArray()[0]}\" or \"{off.ToArray()[0]}\" or \"{auto.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SelectFlash(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select flash \"Capture\" bot failed!");

                HashSet<string> on = this._on
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> off = this._off
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> auto = this._auto
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
                term = $"{on.ToArray()[0]}";
                ask.Add(term);
                term = $"{off.ToArray()[0]}";
                ask.Add(term);
                term = $"{auto.ToArray()[0]}";
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

        public async Task<string> Capture(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture \"Capture\" bot failed!");

                HashSet<string> capture = this._shoot
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

                string ask = $"Choose options: \"{capture.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SelectCapture(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select capture \"Capture\" bot failed!");

                HashSet<string> capture = this._shoot
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
                term = $"{capture.ToArray()[0]}";
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

        public async Task<string> Save(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation save \"Capture\" bot failed!");

                HashSet<string> save = this._save
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

                string ask = $"Choose options: \"{save.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> SelectSave(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation select save \"Capture\" bot failed!");

                HashSet<string> save = this._save
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
                term = $"{save.ToArray()[0]}";
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


        private async Task<string> Flash(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation flash \"Capture\" bot failed!");

                HashSet<string> turn_on = this._turn_on
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> on = this._on
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> off = this._off
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> auto = this._auto
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> turn = this._turn
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> flash = this._flash
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(on.ToArray(), parameter) != -1) ask += $"{turn_on.ToArray()[0]} {flash.ToArray()[0]}.";
                if (Array.IndexOf(off.ToArray(), parameter) != -1) ask += $"{turn.ToArray()[0]} {flash.ToArray()[0]} {off.ToArray()[0]}.";
                if (Array.IndexOf(auto.ToArray(), parameter) != -1) ask += $"{turn.ToArray()[0]} {flash.ToArray()[0]} {auto.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Rotate(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation rotate \"Capture\" bot failed!");

                HashSet<string> front = this._front
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rear = this._rear
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rotate = _rotate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = $"{rotate.ToArray()[0]} {camera.ToArray()[0]} ";
                if (Array.IndexOf(front.ToArray(), parameter) != -1) ask += $"{front.ToArray()[0]}.";
                if (Array.IndexOf(rear.ToArray(), parameter) != -1) ask += $"{rear.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Capture(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture \"Capture\" bot failed!");

                HashSet<string> capture = this._shoot
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(capture.ToArray(), parameter) != -1) ask = $"{capture.ToArray()[0]} {camera.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Save(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation save \"Capture\" bot failed!");

                HashSet<string> save = this._save
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(save.ToArray(), parameter) != -1) ask = $"{save.ToArray()[0]} {camera.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Start(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start \"Capture\" bot failed!");

                HashSet<string> start = this._start
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(start.ToArray(), parameter) != -1) ask = $"{start.ToArray()[0]} {camera.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Stop(string language, string parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop \"Capture\" bot failed!");

                HashSet<string> stop = this._stop
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = string.Empty;
                if (Array.IndexOf(stop.ToArray(), parameter) != -1) ask = $"{stop.ToArray()[0]} {camera.ToArray()[0]}.";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> Choose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation choose \"Capture\" bot failed!");

                HashSet<string> flashs = this._catch_flash
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rotates = this._catch_rotate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> captures = this._catch_capture
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool flash = false;
                bool rotate = false;
                bool capture = false;

                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);

                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(flashs.ToArray(), memo.Text) != -1) flash = true;
                    if (Array.IndexOf(rotates.ToArray(), memo.Text) != -1) rotate = true;
                    if (Array.IndexOf(captures.ToArray(), memo.Text) != -1) capture = true;
                }

                string response = string.Empty;

                if ((rotate) && (!flash)) response = await Flash(language);
                if (flash && rotate && !capture) response = await Capture(language);
                if (flash && rotate && capture) response = await Save(language);

                return response;
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
                if (this._error_off) throw new InvalidOperationException("Operation select \"Capture\" bot failed!");

                HashSet<string> flashs = this._catch_flash
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rotates = this._catch_rotate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> captures = this._catch_capture
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool flash = false;
                bool rotate = false;
                bool capture = false;

                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);

                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(flashs.ToArray(), memo.Text) != -1) flash = true;
                    if (Array.IndexOf(rotates.ToArray(), memo.Text) != -1) rotate = true;
                    if (Array.IndexOf(captures.ToArray(), memo.Text) != -1) capture = true;
                }

                List<string> response = new List<string>();

                if ((rotate) && (!flash)) response = await SelectFlash(language);
                if (flash && rotate && !capture) response = await SelectCapture(language);
                if (flash && rotate && capture) response = await SelectSave(language);

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
                if (this._error_off) throw new InvalidOperationException("Operation load \"Capture\" bot failed!");

                HashSet<string> flashs = this._catch_flash
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rotates = this._catch_rotate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> captures = this._catch_capture
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> starts = this._start
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> stops = this._stop
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> saves = this._save
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(rotates.ToArray(), parameter) != -1)
                {
                    ask = await Start(language, starts.ToArray()[0]);
                    result.Add(ask);
                    ask = await Rotate(language, parameter);
                    result.Add(ask);
                }
                if (Array.IndexOf(flashs.ToArray(), parameter) != -1)
                {
                    ask = await Flash(language, parameter);
                    result.Add(ask);
                }
                if (Array.IndexOf(captures.ToArray(), parameter) != -1)
                {
                    ask = await Capture(language, parameter);
                    result.Add(ask);
                }
                if (Array.IndexOf(saves.ToArray(), parameter) != -1)
                {
                    ask = await Save(language, parameter);
                    result.Add(ask);
                    ask = await Stop(language, stops.ToArray()[0]);
                    result.Add(ask);
                    ask = await Terminate(language);
                    result.Add(ask);
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
                if (this._error_off) throw new InvalidOperationException("Operation terminate \"Record\" bot failed!");

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
