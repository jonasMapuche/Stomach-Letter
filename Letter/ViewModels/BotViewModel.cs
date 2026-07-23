using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Letter.Enums;
using Letter.Models; 
using Letter.Services;
using Letter.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Font = Microsoft.Maui.Font;

namespace Letter.ViewModels
{
    [QueryProperty(nameof(username), "Username")]
    public partial class BotViewModel : ObservableObject, IQueryAttributable
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
        private string _declarative;
        private string _verb;
        private string _noun;
        private string _adjective;
        private string _predicate;
        private string _subject;
        private string _numeral;
        private string _especial;
        private string _preposition;
        private string _adverb;
        private string _adverb_adverb;

        private string _direct_object;
        private string _indirect_object;
        private string _predicative;
        private string _explanatory;
        private string _subject_hidden;

        private Language _language_portugues;
        private Language _language_english;
        private Language _language_deutsch;
        private Language _language_italiano;
        private Language _language_francais;
        private Language _language_espanol;

        private Dictionary<string, string> _load_camera;
        private Dictionary<string, string> _execute;
        private Dictionary<string, string> _view;
        private Dictionary<string, string> _play;
        private Dictionary<string, string> _activity;
        private Dictionary<string, string> _record;
        private Dictionary<string, string> _stop;
        private Dictionary<string, string> _rotate;
        private Dictionary<string, string> _speak;
        private Dictionary<string, string> _download;
        private Dictionary<string, string> _upload;
        private Dictionary<string, string> _capture;
        private Dictionary<string, string> _save;
        private Dictionary<string, string> _turn;
        private Dictionary<string, string> _share;
        private Dictionary<string, string> _feature;
        private Dictionary<string, string> _terminate;
        private Dictionary<string, string> _turn_on;
        private Dictionary<string, string> _start;
        private Dictionary<string, string> _scan;
        private Dictionary<string, string> _work;
        private Dictionary<string, string> _dont_work;
        private Dictionary<string, string> _send;
        private Dictionary<string, string> _connect;
        private Dictionary<string, string> _disconnect;
        private Dictionary<string, string> _connected;
        private Dictionary<string, string> _juncao;
        private Dictionary<string, string> _clean_up;
        private Dictionary<string, string> _load;
        private Dictionary<string, string> _setup;
        private Dictionary<string, string> _select;
        private Dictionary<string, string> _listen;
        private Dictionary<string, string> _call;
        private Dictionary<string, string> _push;

        private Dictionary<string, string> _gps;
        private Dictionary<string, string> _bluetooth;
        private Dictionary<string, string> _bluetooth3;
        private Dictionary<string, string> _bluetooth4;
        private Dictionary<string, string> _camera;
        private Dictionary<string, string> _wav;
        private Dictionary<string, string> _mp3;
        private Dictionary<string, string> _battery;
        private Dictionary<string, string> _file;
        private Dictionary<string, string> _vibration;
        private Dictionary<string, string> _text;
        private Dictionary<string, string> _phone;
        private Dictionary<string, string> _flash;
        private Dictionary<string, string> _audio;
        private Dictionary<string, string> _bot;
        private Dictionary<string, string> _longitude;
        private Dictionary<string, string> _latitude;
        private Dictionary<string, string> _level;
        private Dictionary<string, string> _charge;
        private Dictionary<string, string> _raspberry;
        private Dictionary<string, string> _letter;
        private Dictionary<string, string> _interrogative;
        private Dictionary<string, string> _informative;
        private Dictionary<string, string> _imperative;
        private Dictionary<string, string> _sample;
        private Dictionary<string, string> _compound;
        private Dictionary<string, string> _hidden;
        private Dictionary<string, string> _subordinate;
        private Dictionary<string, string> _coordinative;
        private Dictionary<string, string> _wifi;
        private Dictionary<string, string> _message;
        private Dictionary<string, string> _token;
        private Dictionary<string, string> _message_copy;

        private Dictionary<string, string> _with;
        private Dictionary<string, string> _in;
        private Dictionary<string, string> _off;
        private Dictionary<string, string> _auto;
        private Dictionary<string, string> _on;
        private Dictionary<string, string> _to;

        private Dictionary<string, string> _and;

        private Dictionary<string, string> _front;
        private Dictionary<string, string> _rear;

        private Dictionary<string, string> _through;

        private Dictionary<string, string> _catch;
        private Dictionary<string, string> _catch_camera;
        private Dictionary<string, string> _catch_record;
        private Dictionary<string, string> _catch_share;

        private HashSet<int> _algarismo;

        private HashSet<int> _three;
        private HashSet<int> _four;

        private Dictionary<string, string> _unknow;
        private Dictionary<string, string> _init;
        private Dictionary<string, string> _dont_language;
        private Dictionary<string, string> _dont_undestand;
        private Dictionary<string, string> _kind_subject;

        private bool _mode_bot;
        private List<string> _flam;

        private IHttpService _httpService;
        private IPerceptionService? _perceptionService;
        private IBotService _botService;
        private SettingService? _settingService;
        private IMessageService _messageService;
        private IGrammarService _grammarService;
        #endregion

        #region CONSTRUCTOR
        public BotViewModel(HttpService httpService, MessageService messageService, PerceptionService perceptionService, GrammarService grammarService)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Bot\" view model failed!");
                else this.error_message = string.Empty;

                this._perceptionService = perceptionService;
                this._httpService = httpService;
                this._settingService = SettingService.Instance;
                this._messageService = messageService;
                this._grammarService = grammarService;

                this.showPhoto = false;

                this._botService = new BotService();
                this._botService.OnError += OnError;

                this._declarative = this._settingService.Declarative;
                this._verb = this._settingService.Verb;
                this._noun = this._settingService.Noun;
                this._adjective = this._settingService.Adjective;
                this._predicate = this._settingService.Predicate;
                this._subject = this._settingService.Suject;
                this._numeral = this._settingService.Numeral;
                this._especial = this._settingService.Especial;
                this._preposition = this._settingService.Preposition;
                this._adverb = this._settingService.Adverb;
                this._adverb_adverb = this._settingService.Adverb_Adverb;

                this._direct_object = this._settingService.Direct_Object;
                this._indirect_object = this._settingService.Indirect_Object;
                this._predicative = this._settingService.Predicative;
                this._explanatory = this._settingService.Explanatory;
                this._subject_hidden = this._settingService.Subject_Hidden;

                this._language_portugues = this._settingService.Portugues;
                this._language_english = this._settingService.English;
                this._language_deutsch = this._settingService.Deutsch;
                this._language_italiano = this._settingService.Italino;
                this._language_francais = this._settingService.Francais;
                this._language_espanol = this._settingService.Espanol;

                this._load_camera = this._settingService.Load_Camera;
                this._execute = this._settingService.Execute;
                this._view = this._settingService.View;
                this._play = this._settingService.Play;
                this._activity = this._settingService.Activity;
                this._record = this._settingService.Record;
                this._stop = this._settingService.Stop;
                this._rotate = this._settingService.Rotate;
                this._speak = this._settingService.Speak;
                this._download = this._settingService.Download;
                this._upload = this._settingService.Upload;
                this._capture = this._settingService.Capture;
                this._save = this._settingService.Save;
                this._turn = this._settingService.Turn;
                this._share = this._settingService.Share;
                this._feature = this._settingService.Feature;
                this._terminate = this._settingService.Terminate;
                this._turn_on = this._settingService.Turn_On;
                this._start = this._settingService.Start;
                this._scan = this._settingService.Scan;
                this._work = this._settingService.Work;
                this._dont_work = this._settingService.Dont_Work;
                this._send = this._settingService.Send;
                this._connect = this._settingService.Connect;
                this._disconnect = this._settingService.Disconnect;
                this._connected = this._settingService.Connected;
                this._juncao = this._settingService.Juncao;
                this._clean_up = this._settingService.Clean_Up;
                this._load = this._settingService.Load;
                this._setup = this._settingService.Setup;
                this._select = this._settingService.Select;
                this._listen = this._settingService.Listen;
                this._call = this._settingService.Call;
                this._push = this._settingService.Push;

                this._gps = this._settingService.GPS;
                this._bluetooth = this._settingService.Bluetooth;
                this._bluetooth3 = this._settingService.Bluetooth3;
                this._bluetooth4 = this._settingService.Bluetooth4;
                this._camera = this._settingService.Camera;
                this._wav = this._settingService.WAV;
                this._mp3 = this._settingService.MP3;
                this._battery = this._settingService.Battery;
                this._file = this._settingService.File;
                this._vibration = this._settingService.Vibration;
                this._text = this._settingService.Text;
                this._phone = this._settingService.Phone;
                this._flash = this._settingService.Flash;
                this._audio = this._settingService.Audio;
                this._bot = this._settingService.Bot;
                this._longitude = this._settingService.Longitude;
                this._latitude = this._settingService.Latitude;
                this._level = this._settingService.Level;
                this._charge = this._settingService.Charge;
                this._raspberry = this._settingService.Raspberry;
                this._letter = this._settingService.Letter;
                this._wifi = this._settingService.WiFi;
                this._message = this._settingService.Message;
                this._token = this._settingService.Token;
                this._message_copy = this._settingService.Message_Copy;

                this._interrogative = this._settingService.Inquisitive;
                this._informative = this._settingService.Informative;
                this._imperative = this._settingService.Immediate;
                this._sample = this._settingService.Sample;
                this._compound = this._settingService.Compound;
                this._hidden = this._settingService.Hidden;
                this._subordinate = this._settingService.Subordinative;
                this._coordinative = this._settingService.Coordenative;

                this._with = this._settingService.With;
                this._in = this._settingService.In;
                this._off = this._settingService.Off;
                this._auto = this._settingService.Auto;
                this._on = this._settingService.On;
                this._to = this._settingService.To;

                this._and = this._settingService.And;

                this._front = this._settingService.Front;
                this._rear = this._settingService.Rear;
                this._through = this._settingService.Through;

                this._catch = this._settingService.Catch;
                this._catch_camera = this._settingService.Catch_Camera;
                this._catch_record = this._settingService.Catch_Record;
                this._catch_share = this._settingService.Catch_Share;

                this._algarismo = this._settingService.Algarismo;

                this._three = this._settingService.Three;
                this._four = this._settingService.Four;

                this._unknow = this._settingService.Unknow;

                this._init = this._settingService.Init;
                this._dont_language = this._settingService.Dont_Language;
                this._dont_undestand = this._settingService.Dont_Undestand;
                this._kind_subject = this._settingService.Kind_Subject;

                this._mode_bot = this._settingService.ModeBot;

                this.BackCommand = new AsyncRelayCommand(OnBackCommand);
                this.SendCommand = new AsyncRelayCommand<object>(OnSendCommand);
                this.BotCommand = new AsyncRelayCommand<object>(OnBotCommand);

                Permission();

                InitMessage();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region COMMAND
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation apply query attibutes \"Bot\" view model failed!");

                HashSet<string> inits = this._init
                    .Where(index => index.Value.Contains(this._language_english.Lowercase))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                string init = inits.ToArray()[0];

                Username = query["username"] as User;
                if (Username == null)
                    Username = this._messageService.GetUser(this._language_portugues.Lowercase);

                string language = this._messageService.GetLanguage(Username);
                List<Message> memos = this._messageService.Messages(language);
                if (memos.Count > 0)
                    Messages = new ObservableCollection<Message>(memos);
                else
                {
                    if (!(language == this._language_portugues.Lowercase))
                    {
                        List<Message> chats = this._messageService.Chats;
                        Message? chat = chats.Find(index => index.Sender == Username);
                        Messages = ChargeMessage(chat.Sender, chat.Text, language);
                    }
                    else Messages = ChargeMessage(Username, init, Username.Name);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }

        private async Task OnSendCommand(object? parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on send command 2 \"Bot\" view model failed!");

                string report = string.Empty;
                CancellationToken item = CancellationToken.None;

                Agent agent = (Agent)parameter;
                if (agent == null) return;
                report = agent.Message;
                item = agent.Token;

                this.Token = agent.Token;

                if (this.Username == null) return;
                User user = Username;
                string language = this._messageService.GetLanguage(user);
                if (!(language == this._language_english.Lowercase
                    || language == this._language_deutsch.Lowercase)
                    || language == this._language_italiano.Lowercase)
                {
                    string dont_language = string.Empty;
                    dont_language = LanguageMessage(language); 
                    Messages = ChargeMessage(Username, dont_language, language);
                    TextInput = string.Empty;
                    return;
                }

                if ((report == null) || (report == string.Empty)) return;
                Messages = ChargeMessage(null, report, language);
                TextInput = string.Empty;

                if (this._mode_bot)
                {
                    this._messageService.Bots(null, report, language);
                    string response = string.Empty;
                    List<Mechanism> mechanisms = new List<Mechanism>();
                    await SyntaxBot(report, user, language);
                }
                else
                {
                    List<Mechanism> mechanisms = new List<Mechanism>();
                    mechanisms = await SyntaxDecision(report, user, language);
                    if (mechanisms.Count > 0)
                        Messages = ChargeMessage(user, mechanisms, language);
                    if (this._mode_bot)
                        this._messageService.Bots(user, mechanisms, language);
                }
                WeakReferenceMessenger.Default.Send(new NoticeService("scroll"));
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }

        private async Task PushCopy()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation push copy \"Bot\" view model failed!");

                HashSet<string> copies = this._message_copy
                    .Where(index => index.Value.Contains(this._language_english.Lowercase))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                string copy = copies.ToArray()[0];
                string action = "Ok";
                ToastDuration duration = ToastDuration.Short;

                Color text = Application.Current.Resources["WhiteColor"] as Color;
                Color background = Application.Current.Resources["BackgroundColor"] as Color;
                Color button = Application.Current.Resources["LetterColor"] as Color;

                SnackbarOptions options = new SnackbarOptions
                {
                    BackgroundColor = background,
                    TextColor = text,
                    ActionButtonTextColor = button,
                    CornerRadius = new CornerRadius(10),
                    Font = Font.SystemFontOfSize(14),
                };
                ISnackbar snackbar = Snackbar.Make(copy, null, action, TimeSpan.FromSeconds(3), options);
                CancellationToken cancellation = CancellationToken.None;
                await snackbar.Show(cancellation);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }

        private async Task OnBotCommand(object? parameter)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on bot command \"Bot\" view model failed!");

                string report = string.Empty;
                Tacit tatic = Tacit.Unknown;
                Message memo = (Message)parameter;
                if (memo == null) return;
                report = memo.Implied;
                tatic = (Tacit)memo.Kind;

                if (tatic == Tacit.Unknown) return;
                if ((report == null) || (report == string.Empty)) return;
                if (tatic == Tacit.Copy)
                {
                    await Clipboard.Default.SetTextAsync(report);
                    await PushCopy();
                    return;
                }

                if (Username == null) return;
                User user = Username;
                string language = this._messageService.GetLanguage(user);
                Messages = ChargeMessage(null, report, language);

                if (this._mode_bot)
                {
                    this._messageService.Bots(null, report, language);
                    string response = string.Empty;
                    List<Mechanism> mechanisms = new List<Mechanism>();
                    await SyntaxBot(report, user, language);
                }
                else
                {
                    string result = string.Empty;
                    result = TacitMessage(tatic, report, language);
                    List<Mechanism> mechanisms = new List<Mechanism>();
                    mechanisms = await SyntaxDecision(result, user, language);
                    if (mechanisms.Count > 0)
                        Messages = ChargeMessage(user, mechanisms, language);
                    if (this._mode_bot)
                        this._messageService.Bots(user, mechanisms, language);
                }
                WeakReferenceMessenger.Default.Send(new NoticeService("scroll"));
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }

        private async Task OnBackCommand()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation back command \"Bot\" view model failed!");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }
        #endregion

        #region EVENT
        #endregion

        #region FUNCTION
        public ICommand BackCommand { get; set; }
        public ICommand SendCommand { get; set; }
        public ICommand BotCommand { get; set; }
        public IAsyncRelayCommand? LoadCommand { get; }

        [ObservableProperty]
        public User? username;

        [ObservableProperty]
        public ObservableCollection<Message>? messages;

        [ObservableProperty]
        public byte[]? bytes;

        [ObservableProperty]
        public CameraInfo? selectedCamera;

        [ObservableProperty]
        public CameraFlashMode flashMode;

        [ObservableProperty]
        public bool showPhoto;

        [ObservableProperty]
        public bool showCamera;

        [ObservableProperty]
        public string? textInput;

        public CancellationToken Token { get; set; }

        private void InitMessage()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation init message \"Bot\" view model failed!");

                HashSet<string> inits = this._init
                    .Where(index => index.Value.Contains(this._language_english.Lowercase))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                string init = inits.ToArray()[0];

                Username = this._messageService.GetUser(this._language_portugues.Lowercase);
                string language = this._messageService.GetLanguage(Username);
                List<Message> memos = this._messageService.Messages(language);
                if ((memos != null) && (memos.Count > 0))
                    Messages = new ObservableCollection<Message>(memos);
                else
                    Messages = ChargeMessage(Username, init, language);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private ObservableCollection<Message> ChargeMessage(User? user, string text, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation charge message \"Bot\" view model failed!");

                ObservableCollection<Message> result = new ObservableCollection<Message>();
                List<Message> memos = new List<Message>();
                memos = this._messageService.Messages(user, text, language);
                result = new ObservableCollection<Message>(memos);
                WeakReferenceMessenger.Default.Send(new NoticeService("scroll"));

                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private ObservableCollection<Message> ChargeMessage(User? user, List<Mechanism> mechanisms, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation charge message \"Bot\" view model failed!");

                ObservableCollection<Message> result = new ObservableCollection<Message>();
                List<Message> memos = new List<Message>();
                memos = this._messageService.Messages(user, mechanisms, language);
                result = new ObservableCollection<Message>(memos);
                WeakReferenceMessenger.Default.Send(new NoticeService("scroll"));

                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string TacitMessage(Tacit tacit, string report, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation tacit message \"Bot\" view model failed!");

                HashSet<string> connect = this._connect
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> bluetooth3 = this._bluetooth3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string result = string.Empty;
                if (tacit == Tacit.Bluetooth)
                {
                    result = $"{bluetooth3.ToArray()[0]} {connect.ToArray()[0]}.";
                    this._flam = new List<string>();
                    this._flam.Add(report);
                }
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string LanguageMessage(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation language message \"Bot\" view model failed!");

                HashSet<string> dont_languages = this._dont_language
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string result = string.Empty;
                result = dont_languages.ToArray()[0];
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> SyntaxDecision(string parameter, User user, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation syntax decision \"Bot\" view model failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                List<Recite> recites = new List<Recite>();
                recites = await GoSyntax(parameter, user, language);
                if (recites.Count == 0) return mechanisms;
                bool unknow = true;
                if (recites.Count == 0) unknow = false;
                foreach (Recite recite in recites)
                {
                    if ((recite.Talk == null) && (recite.Kind != this._subject_hidden)) unknow = false;
                    if (recite.Kind == this._subject_hidden) continue;
                    foreach (Talk talk in recite.Talk)
                    {
                        if (talk.Etiology.Count == 0) unknow = false;
                        if (talk.Pattern.Count == 0) unknow = false;
                        foreach (string etiolagy in talk.Etiology)
                        {
                            if (etiolagy == string.Empty) unknow = false; 
                        }
                        foreach (string pattern in talk.Pattern)
                        {
                            if (pattern == string.Empty) unknow = false;
                        }
                    }
                }
                if (unknow)
                    mechanisms = await BotDecision(language, recites);
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task SyntaxBot(string parameter, User user, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation syntax bot \"Bot\" view model failed!");

                List<Message> notes = new List<Message>();
                notes = await LoadBot(parameter, user, language);
                if (notes.Count == 0) return;

                List<Mechanism> mechanisms = new List<Mechanism>();
                mechanisms = await ChooseBot(parameter, language, notes);
                if ((mechanisms.Count > 0) && (notes.Count > 0))
                {
                    this._messageService.Bots(user, mechanisms, language);
                    Messages = ChargeMessage(user, mechanisms, language);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Message>> LoadBot(string parameter, User user, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load bot \"Bot\" view model failed!");

                HashSet<string> cameras = this._catch_camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> records = this._catch_record
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> shares = this._catch_share
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> terminates = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<Message> reports = new List<Message>();
                reports = this._messageService.Bots(language);

                List<string> tasks = new List<string>();
                List<Message> notes = new List<Message>();
                if (Array.IndexOf(terminates.ToArray(), parameter) != -1)
                {
                    tasks = await this._botService.Terminate(language, reports);
                    notes = await LoopBot(tasks, user, language);
                }
                if (Array.IndexOf(cameras.ToArray(), parameter) != -1)
                {
                    tasks = await this._botService.CaptureCamera(language, parameter, reports);
                    notes = await LoopBot(tasks, user, language);
                }
                if (Array.IndexOf(records.ToArray(), parameter) != -1)
                {
                    tasks = await this._botService.RecordAudio(language, parameter, reports);
                    notes = await LoopBot(tasks, user, language);
                }
                if (Array.IndexOf(shares.ToArray(), parameter) != -1)
                {
                    tasks = await this._botService.ShareFile(language, parameter, reports);
                    notes = await LoopBot(tasks, user, language);
                }
                return notes;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Message>> LoopBot(List<string> tasks, User user, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation loop bot \"Bot\" view model failed!");

                List<Message> reports = new List<Message>();
                foreach (string item in tasks)
                {
                    if (this._mode_bot)
                        reports = this._messageService.Bots(user, item, language);
                    Messages = ChargeMessage(user, item, language);

                    List<Mechanism> mechanisms = new List<Mechanism>();
                    if (item != string.Empty)
                        mechanisms = await SyntaxDecision(item, user, language);
                    if (mechanisms.Count > 0)
                    {
                        if (this._mode_bot)
                            reports = this._messageService.Bots(user, mechanisms, language);
                        Messages = ChargeMessage(user, mechanisms, language);
                    }
                }
                return reports;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> ChooseBot(string parameter, string language, List<Message> reports)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation choose loop \"Bot\" view model failed!");

                HashSet<string> cameras = this._catch_camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> records = this._catch_record
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> shares = this._catch_share
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<Mechanism> mechanisms = new List<Mechanism>();
                if (reports.Count > 0)
                {
                    List<string> result = new List<string>();
                    if (Array.IndexOf(cameras.ToArray(), parameter) != -1)
                        result = await this._botService.CameraChoose(language, reports);
                    if (Array.IndexOf(records.ToArray(), parameter) != -1)
                        result = await this._botService.RecordChoose(language, reports);
                    if (Array.IndexOf(shares.ToArray(), parameter) != -1)
                        result = await this._botService.ShareChoose(language, reports);
                    foreach (string value in result)
                    {
                        Mechanism mechanism = new Mechanism();
                        mechanism.name = value;
                        mechanism.implied = value;
                        mechanism.tacit = (int)Tacit.Implied;
                        mechanisms.Add(mechanism);
                    }
                }
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Mechanism> MountMechanism(string appliance, Tacit tacit)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount mechanism \"Bot\" view model failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                Mechanism mechanism = new Mechanism();
                mechanism.name = appliance;
                mechanism.implied = appliance;
                mechanism.tacit = (int)tacit;
                mechanisms.Add(mechanism);
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Mechanism> MountMechanism(List<Mechanism> appliances, Tacit tacit)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount mechanism \"Bot\" view model failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                foreach (Mechanism item in appliances)
                {
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = item.name;
                    mechanism.implied = item.implied;
                    mechanism.tacit = (int)tacit;
                    mechanisms.Add(mechanism);
                }
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Mechanism> MountMechanism(string appliance, List<Mechanism> appliances)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount mechanism \"Bot\" view model failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                Mechanism apparatus = new Mechanism();
                apparatus.name = appliance;
                apparatus.implied = appliance;
                mechanisms.Add(apparatus);
                foreach (Mechanism item in appliances)
                {
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = item.name;
                    mechanism.implied = item.implied;
                    mechanisms.Add(mechanism);
                }
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Recite>> GoSyntax(string parameter, User user, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation go syntax \"Bot\" view model failed!");

                List<Recite> recites = new List<Recite>();

                GoMessage goMessage = new GoMessage();
                User bot = new User();
                bot = new User
                {
                    Name = user.Name,
                    Image = user.Image
                };
                goMessage.sender = bot;
                goMessage.language = language;
                goMessage.message = parameter;
                recites = await this._httpService.HttpSyntax(goMessage);
                return recites;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> BotDecision(string language, List<Recite> recites)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation bot decision \"Bot\" view model failed!");

                string syntax = _language_portugues.Lowercase;

                HashSet<string> hiddens = this._hidden
                    .Where(index => index.Value.Contains(syntax))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> undestands = this._dont_undestand
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> kind_subject = this._kind_subject
                    .Where(index => index.Value.Contains(syntax))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<Mechanism> mechanisms = new List<Mechanism>();

                List<Recite> predication = new List<Recite>();
                predication = recites.FindAll(index => index.Kind == this._verb);
                if (predication.Count == 0 || predication.Count > 1)
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                List<Talk> predication_talks = new List<Talk>();
                predication_talks = predication[0].Talk;
                List<Talk> predication_verbs = new List<Talk>();
                predication_verbs = predication_talks.FindAll(index => index.Etiology.Contains(this._verb));
                if (predication_verbs.Count == 0)
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                Recite subject = new Recite();
                subject = recites[0];
                if ((Array.IndexOf(kind_subject.ToArray(), subject.Kind) == -1) ||
                    ((subject.Kind == hiddens.ToArray()[0]) && (language == _language_deutsch.Lowercase)))
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                List<Talk> subject_talks = new List<Talk>();
                List<Talk> subject_nouns = new List<Talk>();
                if (subject.Kind != hiddens.ToArray()[0])
                {
                    subject_talks = subject.Talk;
                    subject_nouns = subject_talks.FindAll(index => index.Etiology.Contains(this._noun));
                    if (subject_nouns.Count == 0)
                    {
                        string result = undestands.ToArray()[0];
                        mechanisms = MountMechanism(result, Tacit.Copy);
                        return mechanisms;
                    }
                }

                List<Recite> term_objects = new List<Recite>();
                term_objects = recites.FindAll(index => index.Kind == this._direct_object || index.Kind == this._indirect_object);
                if (((subject_nouns.Count > 0) && (language != _language_deutsch.Lowercase)) &&
                    (term_objects.Count > 0))
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }
                if (((term_objects.Count == 0) || (term_objects.Count > 1)) && 
                    (subject_nouns.Count == 0))
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }
                if ((term_objects.Count == 1) && (subject_nouns.Count > 0))
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }
                if ((subject_nouns.Count == 1) && (term_objects.Count > 0))
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                List<Recite> predicatives = new List<Recite>();
                predicatives = recites.FindAll(index => index.Kind == this._predicative);
                if (predicatives.Count > 1)
                {
                    string result = undestands.ToArray()[0];
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                List<Talk> predicative_talks = new List<Talk>();
                List<Talk> predicative_adjective = new List<Talk>();
                if (predicatives.Count == 1)
                {
                    predicative_talks = predicatives[0].Talk;
                    predicative_adjective = predication_talks.FindAll(index => index.Etiology.Contains(this._adjective));
                    if ((predicative_adjective.Count == 0) || (predicative_adjective.Count > 1))
                    {
                        string result = undestands.ToArray()[0];
                        mechanisms = MountMechanism(result, Tacit.Copy);
                        return mechanisms;
                    }
                }

                List<Recite> explanatories = new List<Recite>();
                explanatories = recites.FindAll(index => index.Kind == this._explanatory);
                if (subject_nouns.Count > 0)
                {
                    mechanisms = await CommandButton(language, predication_talks, subject_talks, predicative_talks, explanatories);
                    return mechanisms;
                }

                List<Talk> predicate_talks = new List<Talk>();
                predicate_talks = term_objects[0].Talk;
                List<Talk> predicate_nouns = new List<Talk>();
                predicate_nouns = predicate_talks.FindAll(index => index.Etiology.Contains(this._noun));
                if (predicate_nouns.Count > 0)
                {
                    mechanisms = await CommandButton(language, predication_talks, predicate_talks, predicative_talks, explanatories);
                    return mechanisms;
                }

                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool FindPredication(List<Talk> predications, HashSet<string> hashsets)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation find predication \"Bot\" view model failed!");

                List<Talk> verbs = new List<Talk>();
                verbs = predications.FindAll(index => index.Etiology.Contains(this._verb));

                bool result = false;
                if (verbs.Count == 0) return result;
                string verb = verbs[0].Term;
                if (Array.IndexOf(hashsets.ToArray(), verb) != -1) return true;
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool FindOwner(List<Talk> owners, HashSet<string> hashsets)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation find owner \"Bot\" view model failed!");

                List<Talk> nouns = new List<Talk>();
                List<Talk> numerals = new List<Talk>();
                nouns = owners.FindAll(index => index.Etiology.Contains(this._noun));
                numerals = owners.FindAll(index => index.Etiology.Contains(this._numeral));

                bool result = false;
                string noun = string.Empty;

                if (nouns.Count == 0) return result;
                noun = nouns[0].Term;
                if (numerals.Count > 1) return result;
                if (numerals.Count > 0) noun += " " + numerals[0].Term;

                if (Array.IndexOf(hashsets.ToArray(), noun) != -1) return true;
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool FindPredicative(List<Talk> predicatives, HashSet<string> hashsets)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation find predicative \"Bot\" view model failed!");

                List<Talk> adjectives = new List<Talk>();
                adjectives = predicatives.FindAll(index => index.Etiology.Contains(this._adjective));
                List<Talk> adverb = new List<Talk>();
                adverb = predicatives.FindAll(index => index.Etiology.Contains(this._adverb));
                List<Talk> adverb_adverb = new List<Talk>();
                adverb_adverb = predicatives.FindAll(index => index.Etiology.Contains(this._adverb_adverb));

                bool result = false;
                string adjective = string.Empty;

                if (adjectives.Count == 0) return result;
                adjective = adjectives[0].Term;

                if (adverb.Count > 1) return result;
                if (adverb.Count > 0) adjective += " " + adverb[0].Term;
                if (adverb_adverb.Count > 1) return result;
                if ((adverb.Count == 0) && (adverb_adverb.Count > 0)) return result;
                if ((adverb.Count > 0) && (adverb_adverb.Count > 0)) adjective += " " + adverb_adverb[0].Term;

                if (Array.IndexOf(hashsets.ToArray(), adjective) != -1) return true;
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string ReciteText(List<Recite> recites)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation recite text \"Bot\" view model failed!");

                List<Talk> talks = new List<Talk>();
                foreach (Recite recite in recites)
                {
                    foreach (Talk talk in recite.Talk)
                    {
                        talks.Add(talk);
                    }
                }
                string result = string.Empty;
                List<Talk> vocables = new List<Talk>();
                vocables = talks.OrderBy(index => index.Order).ToList();
                foreach (Talk talk in vocables)
                {
                    if (result == string.Empty) result = talk.Term;
                    else result += " " + talk.Term;
                }
                return result;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> CommandButton(string language, List<Talk> verbs, List<Talk> nouns, List<Talk> adjectives, List<Recite> explanatories)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation command button \"Bot\" view model failed!");

                HashSet<string> verbs_call = new HashSet<string>();
                verbs_call = this._call.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_capture = new HashSet<string>();
                verbs_capture = this._capture.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_clean_up = new HashSet<string>();
                verbs_clean_up = this._clean_up.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_connect = new HashSet<string>();
                verbs_connect = this._connect.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_download = new HashSet<string>();
                verbs_download = this._download.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_listen = new HashSet<string>();
                verbs_listen = this._listen.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_load = new HashSet<string>();
                verbs_load = this._load.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_rotate = new HashSet<string>();
                verbs_rotate = this._rotate.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_record = new HashSet<string>();
                verbs_record = this._record.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_save = new HashSet<string>();
                verbs_save = this._save.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_scan = new HashSet<string>();
                verbs_scan = this._scan.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_select = new HashSet<string>();
                verbs_select = this._select.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_setup = new HashSet<string>();
                verbs_setup = this._setup.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_share = new HashSet<string>();
                verbs_share = this._share.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_speak = new HashSet<string>();
                verbs_speak = this._speak.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_start = new HashSet<string>();
                verbs_start = this._start.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_stop = new HashSet<string>();
                verbs_stop = this._stop.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_play = new HashSet<string>();
                verbs_play = this._play.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_terminate = new HashSet<string>();
                verbs_terminate = this._terminate.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_turn = new HashSet<string>();
                verbs_turn = this._turn.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_turn_on = new HashSet<string>();
                verbs_turn_on = this._turn_on.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_upload = new HashSet<string>();
                verbs_upload = this._upload.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_vibtate = new HashSet<string>();
                verbs_vibtate = this._vibration.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_view = new HashSet<string>();
                verbs_view = this._view.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_push = new HashSet<string>();
                verbs_push = this._push.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> nouns_audio = new HashSet<string>();
                nouns_audio = this._audio.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_battery = new HashSet<string>();
                nouns_battery = this._battery.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_bluetooth3 = new HashSet<string>();
                nouns_bluetooth3 = this._bluetooth3.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_bot = new HashSet<string>();
                nouns_bot = this._bot.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_camera = new HashSet<string>();
                nouns_camera = this._camera.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_file = new HashSet<string>();
                nouns_file = this._file.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_flash = new HashSet<string>();
                nouns_flash = this._flash.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_gps = new HashSet<string>();
                nouns_gps = this._gps.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_letter = new HashSet<string>();
                nouns_letter = this._letter.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_mp3 = new HashSet<string>();
                nouns_mp3 = this._mp3.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_phone = new HashSet<string>();
                nouns_phone = this._phone.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_raspberry = new HashSet<string>();
                nouns_raspberry = this._raspberry.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_record = new HashSet<string>();
                nouns_record = this._record.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> verbs_send = new HashSet<string>();
                verbs_send = _send.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_text = new HashSet<string>();
                nouns_text = this._text.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_wav = new HashSet<string>();
                nouns_wav = this._wav.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_wifi = new HashSet<string>();
                nouns_wifi = this._wifi.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_message = new HashSet<string>();
                nouns_message = this._message.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> nouns_token = new HashSet<string>();
                nouns_token = this._token.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> adjective_auto = new HashSet<string>();
                adjective_auto = this._auto.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> adjective_front = new HashSet<string>();
                adjective_front = this._front.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> adjective_off = new HashSet<string>();
                adjective_off = this._off.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> adjective_on = new HashSet<string>();
                adjective_on = this._on.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> adjective_rear = new HashSet<string>();
                adjective_rear = this._rear.Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<Mechanism> mechanisms = new List<Mechanism>();

                if ((FindPredication(verbs, verbs_call)) && (FindOwner(nouns, nouns_phone)))
                {
                    string text = string.Empty;
                    text = ReciteText(explanatories);
                    string result = string.Empty;
                    result = await CallPhone(language, text);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_capture)) && (FindOwner(nouns, nouns_camera)))
                {
                    string result = string.Empty;
                    result = await CaptureImage(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_clean_up)) && (FindOwner(nouns, nouns_audio)))
                {
                    string result = string.Empty;
                    result = await CleanRecord(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_connect)) && (FindOwner(nouns, nouns_bluetooth3)))
                {
                    string result = string.Empty;
                    result = await ConnectBluetooth3(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_download)) && (FindOwner(nouns, nouns_raspberry)))
                {
                    string result = string.Empty;
                    result = await DownloadRaspberry(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_download)) && (FindOwner(nouns, nouns_file)))
                {
                    string result = string.Empty;
                    result = await DownloadFile(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_listen)) && (FindOwner(nouns, nouns_message)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await ListenSMS(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_listen)) && (FindOwner(nouns, nouns_phone)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await ListenPhone(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_load)) && (FindOwner(nouns, nouns_audio)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await LoadAudio(language);
                    mechanisms = MountMechanism(result, Tacit.Implied);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_load)) && (FindOwner(nouns, nouns_camera)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await LoadCamera(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_load)) && (FindOwner(nouns, nouns_letter)))
                {
                    string result = string.Empty;
                    result = await LoadLetter(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_play)) && (FindOwner(nouns, nouns_mp3)))
                {
                    string result = string.Empty;
                    result = await PlayRecord(language, nouns_mp3.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_play)) && (FindOwner(nouns, nouns_wav)))
                {
                    string result = string.Empty;
                    result = await PlayRecord(language, nouns_wav.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_push)) && (FindOwner(nouns, nouns_token)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await PushToken(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_record)) && (FindOwner(nouns, nouns_camera)))
                {
                    string result = string.Empty;
                    result = await RecordCamera(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_record)) && (FindOwner(nouns, nouns_mp3)))
                {
                    string result = string.Empty;
                    result = await StartRecord(language, nouns_mp3.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_record)) && (FindOwner(nouns, nouns_wav)))
                {
                    string result = string.Empty;
                    result = await StartRecord(language, nouns_wav.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_rotate)) && (FindOwner(nouns, nouns_camera)) &&
                    (FindPredicative(adjectives, adjective_front)))
                {
                    string result = string.Empty;
                    result = await RotateCamera(language, adjective_front.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_rotate)) && (FindOwner(nouns, nouns_camera)) &&
                    (FindPredicative(adjectives, adjective_rear)))
                {
                    string result = string.Empty;
                    result = await RotateCamera(language, adjective_rear.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_save)) && (FindOwner(nouns, nouns_camera)))
                {
                    string result = string.Empty;
                    result = await SaveImage(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_select)) && (FindOwner(nouns, nouns_phone)))
                {
                    string text = string.Empty;
                    text = ReciteText(explanatories);
                    string result = string.Empty;
                    result = await SetupSMS(language, text);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_scan)) && (FindOwner(nouns, nouns_bluetooth3)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await ScanBluetooth3(language);
                    mechanisms = MountMechanism(result, Tacit.Bluetooth);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_scan)) && (FindOwner(nouns, nouns_wifi)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await ScanWiFi(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_send)) && (FindOwner(nouns, nouns_message)))
                {
                    string text = string.Empty;
                    text = ReciteText(explanatories);
                    string result = string.Empty;
                    result = await SendSMS(language, text);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_setup)) && (FindOwner(nouns, nouns_bluetooth3)))
                {
                    string result = string.Empty;
                    result = await SetupBluetooth3(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_setup)) && (FindOwner(nouns, nouns_wifi)))
                {
                    string result = string.Empty;
                    result = await SetupWiFi(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_share)) && (FindOwner(nouns, nouns_file)))
                {
                    List<Mechanism> result = new List<Mechanism>();
                    result = await LoadShare(language);
                    mechanisms = MountMechanism(result, Tacit.Implied);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_speak)) && (FindOwner(nouns, nouns_text)))
                {
                    string text = string.Empty;
                    text = ReciteText(explanatories);
                    string result = string.Empty;
                    result = await SpeakText(language, text);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_speak)) && (FindOwner(nouns, nouns_file)))
                {
                    string text = string.Empty;
                    text = ReciteText(explanatories);
                    string result = string.Empty;
                    result = await FileText(language, text);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_start)) && (FindOwner(nouns, nouns_camera)))
                {
                    string result = string.Empty;
                    result = await StartCamera(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_stop)) && (FindOwner(nouns, nouns_camera)))
                {
                    string result = string.Empty;
                    result = await StopCamera(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_stop)) && (FindOwner(nouns, nouns_mp3)))
                {
                    string result = string.Empty;
                    result = await StopRecord(language, nouns_mp3.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_stop)) && (FindOwner(nouns, nouns_record)))
                {
                    string result = string.Empty;
                    result = await StopRecordCamera(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_stop)) && (FindOwner(nouns, nouns_wav)))
                {
                    string result = string.Empty;
                    result = await StopRecord(language, nouns_wav.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_terminate)) && (FindOwner(nouns, nouns_bot)))
                {
                    string result = string.Empty;
                    result = await EndBot(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_turn)) && (FindOwner(nouns, nouns_flash)) &&
                    (FindPredicative(adjectives, adjective_auto)))
                {
                    string result = string.Empty;
                    result = await FlashCamera(language, adjective_auto.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_turn)) && (FindOwner(nouns, nouns_flash)) &&
                    (FindPredicative(adjectives, adjective_off)))
                {
                    string result = string.Empty;
                    result = await FlashCamera(language, adjective_off.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_turn_on)) && (FindOwner(nouns, nouns_flash)))
                {
                    string result = string.Empty;
                    result = await FlashCamera(language, adjective_on.ToArray()[0]);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_upload)) && (FindOwner(nouns, nouns_raspberry)))
                {
                    string result = string.Empty;
                    result = await UploadRaspberry(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_vibtate)) && (FindOwner(nouns, nouns_phone)))
                {
                    string result = string.Empty;
                    result = await Vibration(7, language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_view)) && (FindOwner(nouns, nouns_gps)))
                {
                    string result = string.Empty;
                    result = await GPS(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                if ((FindPredication(verbs, verbs_view)) && (FindOwner(nouns, nouns_battery)))
                {
                    string result = string.Empty;
                    result = await Battery(language);
                    mechanisms = MountMechanism(result, Tacit.Copy);
                    return mechanisms;
                }

                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        
        //----------------------------

        private async Task<List<Mechanism>> LoadAudio(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load audio \"Bot\" view model failed!");

                if (!this._mode_bot) this._mode_bot = true;
                List<string> response = new List<string>();
                response = await this._botService.LoadAudio(language);
                List<Mechanism> mechanisms = new List<Mechanism>();
                foreach (string value in response)
                {
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = value;
                    mechanism.implied = value;
                    mechanisms.Add(mechanism);
                }
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> StartRecord(string language, string kind)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start record \"Bot\" view model failed!");

                HashSet<string> mp3 = this._mp3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> wav = this._wav
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> record = this._record
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> dont_work = this._dont_work
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                if (kind == mp3.ToArray()[0])
                {
                    this._perceptionService.StartRecordMP3();
                    response = $"{mp3.ToArray()[0]} {record.ToArray()[0]}.";
                }
                else
                {
                    this._perceptionService.StartRecordWav();
                    response = $"{wav.ToArray()[0]} {record.ToArray()[0]}.";
                }
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> CleanRecord(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation clean record \"Bot\" view model failed!");

                HashSet<string> audio = this._audio
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> cleanup = this._clean_up
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                await this._perceptionService.ClearRecording();
                response = $"{audio.ToArray()[0]} {cleanup.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<PermissionStatus> Permission()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation request check permission \"Bot\" view model failed!");

                PermissionStatus statusStorare = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                if (statusStorare != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.StorageWrite>();
                PermissionStatus statusRead = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
                if (statusRead != PermissionStatus.Granted)
                    statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
                PermissionStatus statusMicrophone = await Permissions.CheckStatusAsync<Permissions.Microphone>();
                if (statusMicrophone != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.Microphone>();
                PermissionStatus statusCamera = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (statusCamera != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.Camera>();
                PermissionStatus statusPhone = await Permissions.CheckStatusAsync<Permissions.Phone>();
                if (statusPhone != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.Phone>();
                PermissionStatus statusSMS = await Permissions.CheckStatusAsync<Permissions.Sms>();
                if (statusSMS != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.Sms>();
                PermissionStatus statusBluetooth = await Permissions.CheckStatusAsync<Permissions.Bluetooth>();
                if (statusBluetooth != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.Bluetooth>();
                PermissionStatus statusLocation = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                if (statusLocation != PermissionStatus.Granted)
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                PermissionStatus storagePermission = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                PermissionStatus readPermission = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
                PermissionStatus microPhonePermission = await Permissions.CheckStatusAsync<Permissions.Microphone>();
                PermissionStatus cameraPermission = await Permissions.RequestAsync<Permissions.Camera>();
                PermissionStatus phonePermission = await Permissions.RequestAsync<Permissions.Phone>();
                PermissionStatus smsPermission = await Permissions.RequestAsync<Permissions.Sms>();
                PermissionStatus bluetoothPermission = await Permissions.RequestAsync<Permissions.Bluetooth>();
                PermissionStatus locationPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (storagePermission == PermissionStatus.Granted
                    && microPhonePermission == PermissionStatus.Granted
                    && cameraPermission == PermissionStatus.Granted 
                    && readPermission == PermissionStatus.Granted
                    && bluetoothPermission == PermissionStatus.Granted
                    && smsPermission == PermissionStatus.Granted
                    && phonePermission == PermissionStatus.Granted
                    && locationPermission == PermissionStatus.Granted)
                {
                    return PermissionStatus.Granted;
                }
                return PermissionStatus.Denied;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> StopRecord(string language, string kind)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop record \"Bot\" view model failed!");

                HashSet<string> mp3 = this._mp3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> wav = this._wav
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> stop = this._stop
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                if (kind == mp3.ToArray()[0])
                {
                    string file_path = this._perceptionService.StopRecordMP3();
                    await this._perceptionService.SendRecording(file_path);
                    response = $"{mp3.ToArray()[0]} {stop.ToArray()[0]}.";
                }
                else
                {
                    string file_path = this._perceptionService.StopRecordWav();
                    await this._perceptionService.SendRecording(file_path);
                    response = $"{wav.ToArray()[0]} {stop.ToArray()[0]}.";
                }
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> PlayRecord(string language, string kind)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation play record \"Bot\" view model failed!");

                HashSet<string> mp3 = this._mp3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> wav = this._wav
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> play = this._play
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                this._perceptionService.StopAudio();
                string file_path = this._perceptionService.ReceiveRecording();
                this._perceptionService.PlayAudio(file_path);

                string response = string.Empty;
                if (kind == mp3.ToArray()[0]) response = $"{mp3.ToArray()[0]} {play.ToArray()[0]}.";
                else
                    response = $"{wav.ToArray()[0]} {play.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> EndBot(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation end bot \"Bot\" view model failed!");

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> bot = this._bot
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                if (this._mode_bot) this._mode_bot = false;
                this._messageService.Remove(language);
                response = $"{bot.ToArray()[0]} {terminate.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> LoadCamera(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load camera \"Bot\" view model failed!");

                if (!this._mode_bot) this._mode_bot = true;
                List<string> response = new List<string>();
                response = await this._botService.LoadCamera(language);
                List<Mechanism> mechanisms = new List<Mechanism>();
                foreach(string value in response)
                {
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = value;
                    mechanism.implied = value;
                    mechanisms.Add(mechanism);
                }
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> RotateCamera(string language, string kind)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation rotate camera \"Bot\" view model failed!");

                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rotate = this._rotate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> front = this._front
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rear = this._rear
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                if (kind == front.ToArray()[0])
                    response = $"{camera.ToArray()[0]} {front.ToArray()[0]} {rotate.ToArray()[0]}.";
                else
                    response = $"{camera.ToArray()[0]} {rear.ToArray()[0]} {rotate.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> FlashCamera(string language, string kind)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation flash camera \"Bot\" view model failed!");

                HashSet<string> flash = this._flash
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> off = this._off
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> on = this._on
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> auto = this._auto
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> turn = this._turn
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> turn_on = this._turn_on
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                if (kind == on.ToArray()[0])
                    response = $"{flash.ToArray()[0]} {turn_on.ToArray()[0]}.";
                else
                {
                    if (kind == off.ToArray()[0])
                        response = $"{flash.ToArray()[0]} {off.ToArray()[0]} {turn.ToArray()[0]}.";
                    else
                        response = $"{flash.ToArray()[0]} {auto.ToArray()[0]} {turn.ToArray()[0]}.";
                }
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> StartCamera(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start camera \"Bot\" view model failed!");

                HashSet<string> start = this._start
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{camera.ToArray()[0]} {start.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> StopCamera(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop camera \"Bot\" view model failed!");

                HashSet<string> stop = this._stop
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{camera.ToArray()[0]} {stop.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> CaptureImage(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture image \"Bot\" view model failed!");

                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> capture = this._capture
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{camera.ToArray()[0]} {capture.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> SaveImage(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation save image \"Bot\" view model failed!");

                HashSet<string> save = this._save
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                string file_path = await this._perceptionService.SaveImage(this.Bytes);
                await this._perceptionService.SendRecording(file_path);
                response = $"{camera.ToArray()[0]} {save.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> RecordCamera(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation record camera \"Bot\" view model failed!");

                HashSet<string> record = this._record
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> camera = this._camera
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{camera.ToArray()[0]} {record.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> StopRecordCamera(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop record camera \"Bot\" view model failed!");

                HashSet<string> stop = this._stop
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> record = this._record
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{record.ToArray()[0]} {stop.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> LoadShare(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load share \"Bot\" view model failed!");

                if (!this._mode_bot) this._mode_bot = true;
                List<string> response = new List<string>();
                response = await this._botService.LoadShare(language);
                List<Mechanism> mechanisms = new List<Mechanism>();
                foreach (string value in response)
                {
                    Mechanism mechanism = new Mechanism();
                    mechanism.name = value;
                    mechanism.implied = value;
                    mechanisms.Add(mechanism);
                }
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> UploadRaspberry(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation upload raspberry \"Bot\" view model failed!");

                HashSet<string> upload = this._upload
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rapsberry = this._raspberry
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                await this._perceptionService.UploadRaspberry();
                response = $"{rapsberry.ToArray()[0]} {upload.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> DownloadRaspberry(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation download raspberry \"Bot\" view model failed!");

                HashSet<string> download = this._download
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> rapsberry = this._raspberry
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> dont_work = this._dont_work
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                string file_name = await this._perceptionService.DownloadRaspberry();
                if (file_name != string.Empty) 
                    response = $"{rapsberry.ToArray()[0]} {download.ToArray()[0]}.";
                else
                    response = $"{dont_work.ToArray()[0]} {rapsberry.ToArray()[0]} {download.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> DownloadFile(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation download raspberry \"Bot\" view model failed!");

                HashSet<string> download = this._download
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> file = this._file
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> dont_work = this._dont_work
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                string file_name = await this._perceptionService.DownloadFile();
                if (file_name != string.Empty)
                    response = $"{file.ToArray()[0]} {download.ToArray()[0]}.";
                else
                    response = $"{dont_work.ToArray()[0]} {file.ToArray()[0]} {download.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> GPS(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation gps \"Bot\" view model failed!");

                HashSet<string> work = this._work
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> dont_work = this._dont_work
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> with = this._with
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> and = this._and
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> longitude = this._longitude
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> latitude = this._latitude
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                Location location = new Location();
                location = await this._perceptionService.GetCurrentLocation();
                if (location != null)
                    response = $"{work.ToArray()[0]} {with.ToArray()[0]} {latitude.ToArray()[0]} {location.Latitude} {and.ToArray()[0]} {longitude.ToArray()[0]} {location.Longitude}.";
                else
                    response = $"{dont_work.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Battery(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation battery \"Bot\" view model failed!");

                HashSet<string> charge = this._charge
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                double battery = 0;
                battery = _perceptionService.GetCharge();
                response = $"{battery.ToString()}% {charge.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> Vibration(int number, string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation vibration \"Bot\" view model failed!");

                HashSet<string> vibration = this._vibration
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> level = this._level
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                this._perceptionService.SetVibration(number);
                response = $"{vibration.ToArray()[0]} {level.ToArray()[0]} {number}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> SetupBluetooth3(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup bluetooth 3 \"Bot\" view model failed!");

                HashSet<string> bluetooth3 = this._bluetooth3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                await this._perceptionService.SetupBluetooth3();
                response = $"{bluetooth3.ToArray()[0]} {setup.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> ScanBluetooth3(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan bluetooth 3 \"Bot\" view model failed!");

                HashSet<string> bluetooth3 = this._bluetooth3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{bluetooth3.ToArray()[0]} {scan.ToArray()[0]}.";
                List<Mechanism> mechanisms = await this._perceptionService.ScanBluetooth3();
                List<Mechanism> apparatus = new List<Mechanism>();
                apparatus = MountMechanism(response, mechanisms);
                return apparatus;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> ConnectBluetooth3(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation connect bluetooth 4 \"Bot\" view model failed!");

                HashSet<string> bluetooth3 = this._bluetooth3
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> connected = this._connected
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> in_proposition = this._in
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string result = string.Empty;
                if (this._flam.Count > 1)
                    result = await this._perceptionService.ConnectBluetooth3(this._flam.First());
                string response = string.Empty;
                response = $"{connected.ToArray()[0]} {in_proposition.ToArray()[0]} {bluetooth3.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> SpeakText(string language, string locution)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speak text \"Bot\" view model failed!");

                HashSet<string> text = this._text
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> speak = this._speak
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                this._perceptionService.SpeakText(locution);
                response = $"{text.ToArray()[0]} {speak.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> FileText(string language, string locution)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation file text \"Bot\" view model failed!");

                HashSet<string> file = this._file
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> save = this._save
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                string file_path = this._perceptionService.FileText(locution);
                await this._perceptionService.SendRecording(file_path);
                response = $"{file.ToArray()[0]} {save.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> LoadLetter(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation load letter \"Bot\" view model failed!");

                HashSet<string> letter = this._letter
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> load = this._load
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                List<string> grammars = this._grammarService.LoadSyntax(language, 1); 
                string file_path = await this._perceptionService.SaveLetter(grammars);
                await this._perceptionService.SendRecording(file_path);
                response = $"{letter.ToArray()[0]} {load.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> SetupSMS(string language, string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup SMS \"Bot\" view model failed!");

                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                await this._perceptionService.SetupSMS(text);
                response = $"{phone.ToArray()[0]} {setup.ToArray()[0]}: {text}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> SendSMS(string language, string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send sms \"Bot\" view model failed!");

                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> send = this._send
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                this._perceptionService.SendSMS(text);
                response = $"{message.ToArray()[0]} {send.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> ListenSMS(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen sms \"Bot\" view model failed!");

                HashSet<string> message = this._message
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{message.ToArray()[0]} {listen.ToArray()[0]}.";
                List<Mechanism> mechanisms = new List<Mechanism>();
                List<Mechanism> apparatus = new List<Mechanism>();
                mechanisms = await this._perceptionService.ScanSMS();
                apparatus = MountMechanism(response, mechanisms);
                return apparatus;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> SetupWiFi(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup wifi \"Bot\" view model failed!");

                HashSet<string> wifi = this._wifi
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> setup = this._setup
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                await this._perceptionService.SetupWiFi();
                response = $"{wifi.ToArray()[0]} {setup.ToArray()[0]}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> ScanWiFi(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan wifi \"Bot\" view model failed!");

                HashSet<string> wifi = this._wifi
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> scan = this._scan
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{wifi.ToArray()[0]} {scan.ToArray()[0]}.";
                List<Mechanism> mechanisms = await this._perceptionService.ScanWiFi();
                List<Mechanism> apparatus = new List<Mechanism>();
                apparatus = MountMechanism(response, mechanisms);
                return apparatus;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<string> CallPhone(string language, string number)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call phone \"Bot\" view model failed!");

                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> call = this._call
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                this._perceptionService.CallPhone(number);
                response = $"{phone.ToArray()[0]} {call.ToArray()[0]}: {number}.";
                return response;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> ListenPhone(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen phone \"Bot\" view model failed!");

                HashSet<string> phone = this._phone
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> listen = this._listen
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{phone.ToArray()[0]} {listen.ToArray()[0]}.";
                List<Mechanism> mechanisms = new List<Mechanism>();
                List<Mechanism> apparatus = new List<Mechanism>();
                mechanisms = await this._perceptionService.ScanPhone();
                apparatus = MountMechanism(response, mechanisms);
                return apparatus;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<List<Mechanism>> PushToken(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation push token \"Bot\" view model failed!");

                HashSet<string> token = this._token
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();
                HashSet<string> push = this._push
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string response = string.Empty;
                response = $"{token.ToArray()[0]} {push.ToArray()[0]}.";
                List<Mechanism> mechanisms = new List<Mechanism>();
                Mechanism mechanism = new Mechanism();
                mechanism = await this._perceptionService.TokenPush();
                mechanisms.Add(mechanism);
                List<Mechanism> apparatus = new List<Mechanism>();
                apparatus = MountMechanism(response, mechanisms);
                return apparatus;
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
