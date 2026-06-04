using Letter.Enums;
using Letter.Models;

namespace Letter.Services
{
    public class SettingService
    {
        #region VARIABLE
        private static SettingService? _instance;
        private static readonly object _lock = new object();

        private static string _english = "english";
        private static string _deutsch = "deutsch";
        private static string _italiano = "italiano";
        private static string _francais = "français";
        private static string _espanol = "español";
        private static string _portugues = "português";

        private static string _lesson_english = "lesson";
        private static string _lesson_deutsch = "lektion";
        private static string _lesson_italiano = "lezione";
        private static string _lesson_francais = "leçon";
        private static string _lesson_espanol = "lección";
        private static string _lesson_portugues = "lição";

        private static string _image_speak_on = "speaker_notes_62dp_white.png";
        private static string _image_speak_off = "speaker_notes_off_62dp_white.png";
        private static string _image_move_on = "play_arrow_62dp_white.png";
        private static string _image_move_off = "play_disabled_62dp_white.png";

        private static readonly string suject_portugues = "sujeito";
        private static readonly string predicate_portugues = "predicado";

        private static readonly string noun_portugues = "substantivo";
        private static readonly string pronoun_portugues = "pronome";
        private static readonly string verb_portugues = "verbo";
        private static readonly string adjective_portugues = "adjetivo";
        private static readonly string article_portugues = "article";
        private static readonly string numeral_portugues = "numeral";
        private static readonly string adverb_portugues = "adverbio";
        private static readonly string conjunction_portugues = "conjuncao";
        private static readonly string sentence_portugues = "sentenca";
        private static readonly string adnominal_adjunct_portugues = "adjunto adnominal";
        private static readonly string adverbial_verb_portugues = "adverbial verb";
        private static readonly string adverbial_adjective_portugues = "adverbial adjective";

        private static readonly string adverb_adverb_portugues = "adverbio adverbio";
        private static readonly string adjective_noun_portugues = "adjetivo substantivo";
        private static readonly string adjective_adverb_portugues = "adjetivo adverbio";
        private static readonly string numeral_noun_portugues = "numeral substantivo";
        private static readonly string conjunction_noun_portugues = "conjuncao substantivo";

        private static readonly string personal_portugues = "pessoal";
        private static readonly string preposition_portugues = "preposição";
        private static readonly string possessive_portugues = "possessivo";
        private static readonly string demonstrative_portugues = "demonstrativo";
        private static readonly string possessive_adjective_portugues = "possessivo adjetivo";

        public static readonly string especial_portugues = "especial";

        public static readonly string single_portugues = "singular";
        public static readonly string plural_portugues = "plural";

        public static readonly string declarative_portugues = "declarativa";
        public static readonly string interrogative_portugues = "interrogativa";
        public static readonly string imperative_portugues = "imperativo";
        public static readonly string subordinate_portugues = "subordinada";
        public static readonly string coordenative_portugues = "coordenada";

        public static readonly string subordinate_english = "subordinate";
        public static readonly string coordenative_english = "coordinative";

        public static readonly string declarative_english = "declarative";
        public static readonly string interrogative_english = "interrogative";
        public static readonly string imperative_english = "imperative";

        public static readonly string sample_portugues = "simples";
        public static readonly string compound_portugues = "composto";
        public static readonly string hidden_portugues = "inexistente";

        public static readonly string infinitive_portugues = "infinitivo";

        private static readonly int order_1 = 1;
        private static readonly int order_2 = 2;
        private static readonly int order_3 = 3;
        private static readonly int order_4 = 4;
        private static readonly int order_5 = 5;
        private static readonly int order_6 = 6;
        private static readonly int order_7 = 7;
        private static readonly int order_8 = 8;
        private static readonly int order_9 = 9;
        private static readonly int order_10 = 10;

        private static readonly string load_english = "load";
        private static readonly string load_deutsch = "laden";
        private static readonly string execute_english = "execute";
        private static readonly string see_english = "see";
        private static readonly string view_english = "view";
        private static readonly string click_english = "click";
        private static readonly string play_english = "play";
        private static readonly string record_english = "record";
        private static readonly string download_english = "download";
        private static readonly string upload_english = "upload";
        private static readonly string rotate_english = "rotate";
        private static readonly string preview_english = "preview";
        private static readonly string stop_english = "stop";
        private static readonly string stop_deutsch = "stoppen";
        private static readonly string capture_english = "capture";
        private static readonly string speak_english = "speak";
        private static readonly string save_english = "save";
        private static readonly string dont_capture_english = "do not capture";
        private static readonly string turn_english = "turn";
        private static readonly string start_english = "start";
        private static readonly string dont_start_english = "do not start";
        private static readonly string send_english = "send";
        private static readonly string dont_send_english = "do not send";
        private static readonly string scan_english = "scan";
        private static readonly string is_english = "is";
        private static readonly string choose_english = "choose";
        private static readonly string connect_english = "connect";
        private static readonly string share_english = "share";
        private static readonly string write_english = "write";
        private static readonly string end_english = "end";
        private static readonly string terminate_english = "terminate";
        private static readonly string turn_on_english = "turn on";
        private static readonly string work_english = "work";
        private static readonly string dont_work_english = "do not work";
        private static readonly string disconnect_english = "disconnect";
        private static readonly string connected_english = "connected";
        private static readonly string clear_english = "clear";

        private static readonly string gps_english = "gps";
        private static readonly string bluetooth_english = "bluetooth";
        private static readonly string battery_english = "battery";
        private static readonly string wav_english = "wav";
        private static readonly string mp3_english = "mp3";
        private static readonly string camera_english = "camera";
        private static readonly string camera_deutsch = "kamera";
        private static readonly string file_english = "file";
        private static readonly string vibration_english = "vibration";
        private static readonly string phone_english = "phone";
        private static readonly string text_english = "text";
        private static readonly string flash_english = "flash";
        private static readonly string audio_english = "audio";
        private static readonly string connection_english = "connection";
        private static readonly string name_english = "name";
        private static readonly string options_english = "options";
        private static readonly string bot_english = "bot";
        private static readonly string raspberry_english = "raspberry";
        private static readonly string bluetooth_3_english = "bluetooth 3";
        private static readonly string bluetooth_4_english = "bluetooth 4";
        private static readonly string latitude_english = "latitude";
        private static readonly string longitude_english = "longitude";
        private static readonly string level_english = "level";
        private static readonly string charge_english = "charge";
        private static readonly string unknow_english = "unknow";
        private static readonly string letter_english = "letter";
        private static readonly string letter_deutsch = "brief";
        private static readonly string sample_english = "sample";
        private static readonly string compound_english = "compound";
        private static readonly string hidden_english = "hidden";

        private static readonly string on_english = "on";
        private static readonly string off_english = "off";
        private static readonly string auto_english = "auto";
        private static readonly string front_english = "front";
        private static readonly string rear_english = "rear";

        private static readonly string what_english = "what";

        private static readonly string and_english = "and";
        private static readonly string or_english = "or";

        private static readonly string with_english = "with";
        private static readonly string by_english = "by";
        private static readonly string in_english = "in";
        private static readonly string to_english = "to";

        private static readonly string through_english = "through";

        private static readonly string init_english = "What can I do for you?";
        private static readonly string dont_language_english = "Language not work yet.";
        private static readonly string dont_language_deutsch = "Die sprache arbeiten nicht noch.";
        #endregion

        #region CONSTRUCTOR
        public static SettingService? Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SettingService();
                    }
                    return _instance;
                }
            }
        }
        #endregion

        #region LANGUAGE
        public readonly Language English = new Language
        {
            Name = "english",
            Uppercase = "English",
            Lowercase = _english,
            Code = "en",
            Region = "US",
            Lesson = _lesson_english
        };

        public readonly Language Deutsch = new Language
        {
            Name = "deutsch",
            Uppercase = "Deutsch",
            Lowercase = _deutsch,
            Code = "de",
            Region = "DE",
            Lesson = _lesson_deutsch
        };

        public readonly Language Italino = new Language
        {
            Name = "italiano",
            Uppercase = "Italiano",
            Lowercase = _italiano,
            Code = "it",
            Region = "IT",
            Lesson = _lesson_italiano
        };

        public readonly Language Francais = new Language
        {
            Name = "francais",
            Uppercase = "Français",
            Lowercase = _francais,
            Code = "fr",
            Region = "FR",
            Lesson = _lesson_francais
        };

        public readonly Language Espanol = new Language
        {
            Name = "espanol",
            Uppercase = "Español",
            Lowercase = _espanol,
            Code = "es",
            Region = "ES",
            Lesson = _lesson_espanol
        };

        public readonly Language Portugues = new Language
        {
            Name = "portugues",
            Uppercase = "Português",
            Lowercase = _portugues,
            Code = "pt",
            Region = "PT",
            Lesson = _lesson_portugues
        };
        #endregion

        #region SETTING
        public readonly string Image_Speak_On = _image_speak_on;
        public readonly string Image_Speak_Off = _image_speak_off;
        public readonly string Image_Move_On = _image_move_on;
        public readonly string Image_Move_Off = _image_move_off;

        public bool PauseEnglish { get; set; } = true;
        public bool PauseDeutsch { get; set; } = true;
        public bool PauseItaliano { get; set; } = true;
        public bool PauseFrancais { get; set; } = true;
        public bool PauseEspanol { get; set; } = true;

        public bool SpeakEnglish { get; set; } = false;
        public bool SpeakDeutsch { get; set; } = false;
        public bool SpeakItaliano { get; set; } = false;
        public bool SpeakFrancais { get; set; } = false;
        public bool SpeakEspanol { get; set; } = false;

        public bool UpdateDatabase { get; set; } = false;
        public bool SQLiteDatabase { get; set; } = false;
        public bool DropDatabase { get; set; } = false;
        public int PitchSpeak { get; set; } = 50;
        public int VolumeSpeak { get; set; } = 75;
        public float PitchFloat { get; set; } = 1.0f;
        public float VolumeFloat { get; set; } = .75f;

        public bool InitDatabase { get; set; } = true;
        #endregion

        #region HOME
        public HashSet<string> Lesson = new HashSet<String>
        {
            _lesson_english,
            _lesson_deutsch,
            _lesson_francais,
            _lesson_italiano,
            _lesson_espanol
        };
        #endregion

        #region GRAMMAR
        public readonly string Suject = suject_portugues;
        public readonly string Predicate = predicate_portugues;

        public readonly string Pronoun = pronoun_portugues;
        public readonly string Noun = noun_portugues;
        public readonly string Verb = verb_portugues;
        public readonly string Adjective = adjective_portugues;
        public readonly string Article = article_portugues;
        public readonly string Numeral = numeral_portugues;
        public readonly string Adverb = adverb_portugues;
        public readonly string Conjunction = conjunction_portugues;
        public readonly string Preposition = preposition_portugues;
        public readonly string Sentence = sentence_portugues;

        public readonly string Adverb_Adverb = adverb_adverb_portugues;
        public readonly string Adjective_Noun = adjective_noun_portugues;
        public readonly string Adjective_Adverb = adjective_adverb_portugues;
        public readonly string Conjunction_Noun = conjunction_noun_portugues;
        public readonly string Numeral_Noun = numeral_noun_portugues;

        public readonly string Adnominal_Adjunct = adnominal_adjunct_portugues;
        public readonly string Adverbial_Verb = adverbial_verb_portugues;
        public readonly string Adverbial_Adjective = adverbial_adjective_portugues;

        public readonly string Personal = personal_portugues;
        public readonly string Possessive = possessive_portugues;
        public readonly string Demonstrative = demonstrative_portugues;
        public readonly string Possessive_Adjective = possessive_adjective_portugues;

        public readonly string Especial = especial_portugues;

        public readonly string Single = single_portugues;
        public readonly string Plural = plural_portugues;

        public readonly string Declarative = declarative_portugues;

        public readonly string Infinitive = infinitive_portugues;

        public HashSet<string> Morphology = new HashSet<string>()
        {
            noun_portugues,
            pronoun_portugues,
            verb_portugues,
            article_portugues,
            adjective_portugues,
            conjunction_portugues,
            numeral_portugues,
            adverb_portugues,
            adverb_adverb_portugues,
            personal_portugues,
            possessive_portugues,
            demonstrative_portugues,
            adnominal_adjunct_portugues,
            adverbial_verb_portugues,
            adverbial_adjective_portugues
        };

        public HashSet<string> Syntax = new HashSet<string>
        {
            suject_portugues,
            predicate_portugues
        };

        public HashSet<int> Order = new HashSet<int>
        {
            order_1,
            order_2,
            order_3,
            order_4,
            order_5,
            order_6,
            order_7,
            order_8,
            order_9,
            order_10
        };
        #endregion

        #region BOT
        public bool ModeBot { get; set; } = false;

        public Dictionary<string, string> Execute = new Dictionary<string, string>()
        {
            { load_english, _english},
            { load_deutsch, _deutsch},
            { execute_english, _english},
            { see_english, _english },
            { click_english, _english },
            { play_english, _english },
            { record_english, _english },
            { download_english, _english },
            { upload_english, _english },
            { rotate_english, _english },
            { preview_english, _english },
            { stop_english, _english },
            { stop_deutsch, _deutsch },
            { capture_english, _english },
            { speak_english, _english },
            { view_english, _english },
            { terminate_english, _english },
            { start_english, _english },
            { save_english,_english },
            { turn_english, _english },
            { turn_on_english, _english },
            { share_english, _english },
            { scan_english, _english },
            { connect_english, _english },
            { send_english, _english },
            { clear_english, _english }
        };

        public Dictionary<string, string> Load_Camera = new Dictionary<string, string>()
        {
            { load_english, _english },
            { execute_english, _english },
            { click_english, _english }
        };

        public Dictionary<string, string> View = new Dictionary<string, string>()
        {
            { view_english, _english },
            { see_english, _english }
        };

        public Dictionary<string, string> Play = new Dictionary<string, string>()
        {
            { play_english, _english }
        };

        public Dictionary<string, string> Record = new Dictionary<string, string>()
        {
            { record_english, _english }
        };

        public Dictionary<string, string> Stop = new Dictionary<string, string>()
        {
            { stop_english, _english },
            { stop_deutsch, _deutsch }
        };

        public Dictionary<string, string> Speak = new Dictionary<string, string>()
        {
            { speak_english, _english }
        };

        public Dictionary<string, string> Rotate = new Dictionary<string, string>()
        {
            { rotate_english, _english }
        };

        public Dictionary<string, string> Download = new Dictionary<string, string>()
        {
            { download_english, _english }
        };

        public Dictionary<string, string> Upload = new Dictionary<string, string>()
        {
            { upload_english, _english }
        };

        public Dictionary<string, string> Capture = new Dictionary<string, string>()
        {
            { capture_english, _english },
            { record_english, _english }
        };

        public Dictionary<string, string> Save = new Dictionary<string, string>()
        {
            { save_english,_english }
        };

        public Dictionary<string, string> Write = new Dictionary<string, string>()
        {
            { write_english, _english }
        };

        public Dictionary<string, string> Activity = new Dictionary<string, string>()
        {
            { gps_english, _english },
            { bluetooth_english, _english },
            { battery_english, _english },
            { camera_english, _english },
            { camera_deutsch, _deutsch },
            { wav_english, _english },
            { mp3_english, _english },
            { file_english, _english },
            { vibration_english, _english },
            { phone_english, _english },
            { audio_english, _english },
            { bot_english, _english },
            { flash_english, _english },
            { text_english, _english },
            { raspberry_english, _english },
            { letter_english, _english },
            { letter_deutsch, _deutsch }
        };

        public Dictionary<string, string> Feature = new Dictionary<string, string>()
        {
            { on_english, _english },
            { off_english, _english },
            { auto_english, _english },
            { front_english, _english },
            { rear_english, _english }
        };

        public Dictionary<string, string> Juncao = new Dictionary<string, string>()
        {
            { to_english, _english }
        };

        public Dictionary<string, string> GPS = new Dictionary<string, string>()
        {
            { gps_english, _english }
        };

        public Dictionary<string, string> Bluetooth = new Dictionary<string, string>()
        {
            { bluetooth_english, _english }
        };

        public Dictionary<string, string> Bluetooth3 = new Dictionary<string, string>()
        {
            { bluetooth_3_english, _english }
        };

        public Dictionary<string, string> Bluetooth4 = new Dictionary<string, string>()
        {
            { bluetooth_4_english, _english }
        };

        public Dictionary<string, string> Bluetooths = new Dictionary<string, string>()
        {
            { bluetooth_4_english, _english },
            { bluetooth_3_english, _english },
            { bluetooth_english, _english }
        };

        public Dictionary<string, string> Battery = new Dictionary<string, string>()
        {
            { battery_english, _english }
        };

        public Dictionary<string, string> Camera = new Dictionary<string, string>()
        {
            { camera_english, _english },
            { camera_deutsch, _deutsch }
        };

        public Dictionary<string, string> WAV = new Dictionary<string, string>()
        {
            { wav_english, _english }
        };

        public Dictionary<string, string> MP3 = new Dictionary<string, string>()
        {
            { mp3_english, _english }
        };

        public Dictionary<string, string> File = new Dictionary<string, string>()
        {
            { file_english, _english }
        };

        public Dictionary<string, string> Vibration = new Dictionary<string, string>()
        {
            { vibration_english, _english }
        };

        public Dictionary<string, string> Phone = new Dictionary<string, string>()
        {
            { phone_english, _english }
        };

        public Dictionary<string, string> Text = new Dictionary<string, string>()
        {
            { text_english, _english }
        };

        public Dictionary<string, string> Flash = new Dictionary<string, string>()
        {
            { flash_english, _english }
        };

        public Dictionary<string, string> On = new Dictionary<string, string>()
        {
            { on_english, _english }
        };

        public Dictionary<string, string> Off = new Dictionary<string, string>()
        {
            { off_english, _english }
        };

        public Dictionary<string, string> Auto = new Dictionary<string, string>()
        {
            { auto_english, _english }
        };

        public Dictionary<string, string> Raspberry = new Dictionary<string, string>()
        {
            { raspberry_english, _english }
        };

        public Dictionary<string, string> Catch = new Dictionary<string, string>()
        {
            { on_english, _english },
            { off_english, _english },
            { auto_english, _english },
            { front_english, _english },
            { rear_english, _english },
            { capture_english, _english },
            { dont_capture_english, _english },
            { mp3_english, _english },
            { wav_english, _english },
            { stop_english, _english },
            { terminate_english, _english },
            { upload_english, _english },
            { bluetooth_english, _english },
            { download_english, _english },
            { raspberry_english, _english },
            { bluetooth_3_english, _english },
            { bluetooth_4_english, _english },
            { save_english, _english },
            { scan_english, _english },
            { send_english, _english }
        };

        public Dictionary<string, string> Catch_Camera = new Dictionary<string, string>()
        {
            { on_english, _english },
            { off_english, _english },
            { auto_english, _english },
            { front_english, _english },
            { rear_english, _english },
            { capture_english, _english },
            { save_english, _english }
        };

        public Dictionary<string, string> Catch_Record = new Dictionary<string, string>()
        {
            { mp3_english, _english },
            { wav_english, _english },
            { stop_english, _english }
        };

        public Dictionary<string, string> Catch_Flash = new Dictionary<string, string>()
        {
            { on_english, _english },
            { off_english, _english },
            { auto_english, _english }
        };

        public Dictionary<string, string> Catch_Rotate = new Dictionary<string, string>()
        {
            { front_english, _english },
            { rear_english, _english }
        };

        public Dictionary<string, string> Catch_Capture = new Dictionary<string, string>()
        {
            { capture_english, _english }
        };

        public Dictionary<string, string> Shoot = new Dictionary<string, string>()
        {
            { capture_english, _english }
        };

        public Dictionary<string, string> Dont_Shoot = new Dictionary<string, string>()
        {
            { dont_capture_english, _english }
        };

        public Dictionary<string, string> Front = new Dictionary<string, string>()
        {
            { front_english, _english }
        };

        public Dictionary<string, string> Rear = new Dictionary<string, string>()
        {
            { rear_english, _english }
        };

        public Dictionary<string, string> Turn = new Dictionary<string, string>()
        {
            { turn_english, _english }
        };

        public Dictionary<string, string> Turn_On = new Dictionary<string, string>()
        {
            { turn_on_english, _english }
        };

        public Dictionary<string, string> Record_Audio = new Dictionary<string, string>()
        {
            { wav_english, _english },
            { mp3_english, _english },
            { start_english, _english },
            { dont_start_english, _english }
        };

        public Dictionary<string, string> Catch_Audio = new Dictionary<string, string>()
        {
            { wav_english, _english },
            { mp3_english, _english }
        };

        public Dictionary<string, string> Catch_Start = new Dictionary<string, string>()
        {
            { start_english, _english },
            { dont_start_english, _english }
        };

        public Dictionary<string, string> Audio = new Dictionary<string, string>()
        {
            { audio_english, _english }
        };

        public Dictionary<string, string> Start = new Dictionary<string, string>()
        {
            { start_english, _english }
        };

        public Dictionary<string, string> Dont_Start = new Dictionary<string, string>()
        {
            { dont_start_english, _english }
        };

        public Dictionary<string, string> Send = new Dictionary<string, string>()
        {
            { send_english, _english }
        };

        public Dictionary<string, string> Dont_Send = new Dictionary<string, string>()
        {
            { dont_send_english, _english }
        };

        public Dictionary<string, string> Load_Share = new Dictionary<string, string>()
        {
            { load_english, _english },
        };

        public Dictionary<string, string> Scan = new Dictionary<string, string>()
        {
            { scan_english, _english },
        };

        public Dictionary<string, string> Connect = new Dictionary<string, string>()
        {
            { connect_english, _english },
        };

        public Dictionary<string, string> Name = new Dictionary<string, string>()
        {
            { name_english, _english },
        };

        public Dictionary<string, string> Connection = new Dictionary<string, string>()
        {
            { connection_english, _english },
        };

        public Dictionary<string, string> Is_Be = new Dictionary<string, string>()
        {
            { is_english, _english },
        };

        public Dictionary<string, string> What = new Dictionary<string, string>()
        {
            { what_english, _english },
        };

        public Dictionary<string, string> Choose = new Dictionary<string, string>()
        {
            { choose_english, _english },
        };

        public Dictionary<string, string> Options = new Dictionary<string, string>()
        {
            { options_english, _english },
        };

        public Dictionary<string, string> Share = new Dictionary<string, string>()
        {
            { share_english, _english },
        };

        public Dictionary<string, string> Catch_Share = new Dictionary<string, string>()
        {
            { upload_english, _english },
            { bluetooth_english, _english },
            { bluetooth_3_english, _english },
            { bluetooth_4_english, _english },
            { download_english, _english },
            { raspberry_english, _english },
            { scan_english, _english },
            { connect_english, _english },
            { send_english, _english },
            { disconnect_english, _english }
        };

        public Dictionary<string, string> Catch_Scan = new Dictionary<string, string>()
        {
            { scan_english, _english },
            { bluetooth_english, _english }
        };

        public Dictionary<string, string> End = new Dictionary<string, string>()
        {
            { end_english, _english }
        };

        public Dictionary<string, string> Bot = new Dictionary<string, string>()
        {
            { bot_english, _english }
        };

        public Dictionary<string, string> Terminate = new Dictionary<string, string>()
        {
            { terminate_english, _english }
        };

        public HashSet<int> Algarismo = new HashSet<int>
        {
            (int)Cipher.Three,
            (int)Cipher.Four
        };

        public HashSet<int> Three = new HashSet<int>
        {
            (int)Cipher.Three
        };

        public HashSet<int> Four = new HashSet<int>
        {
            (int)Cipher.Four
        };

        public Dictionary<string, string> Dont_Work = new Dictionary<string, string>()
        {
            { dont_work_english, _english }
        };

        public Dictionary<string, string> Work = new Dictionary<string, string>()
        {
            { work_english, _english }
        };

        public Dictionary<string, string> With = new Dictionary<string, string>()
        {
            { with_english, _english }
        };

        public Dictionary<string, string> By = new Dictionary<string, string>()
        {
            { by_english, _english }
        };

        public Dictionary<string, string> In = new Dictionary<string, string>()
        {
            { in_english, _english }
        };

        public Dictionary<string, string> And = new Dictionary<string, string>()
        {
            { and_english, _english }
        };

        public Dictionary<string, string> Or = new Dictionary<string, string>()
        {
            { or_english, _english }
        };

        public Dictionary<string, string> Latitude = new Dictionary<string, string>()
        {
            { latitude_english, _english }
        };

        public Dictionary<string, string> Longitude = new Dictionary<string, string>()
        {
            { longitude_english, _english }
        };

        public Dictionary<string, string> Level = new Dictionary<string, string>()
        {
            { level_english, _english }
        };

        public Dictionary<string, string> Disconnect = new Dictionary<string, string>()
        {
            { disconnect_english, _english }
        };

        public Dictionary<string, string> Connected = new Dictionary<string, string>()
        {
            { connected_english, _english }
        };

        public Dictionary<string, string> Through = new Dictionary<string, string>()
        {
            { through_english, _english }
        };

        public Dictionary<string, string> To = new Dictionary<string, string>()
        {
            { to_english, _english }
        };

        public Dictionary<string, string> Init = new Dictionary<string, string>()
        {
            { init_english, _english }
        };

        public Dictionary<string, string> Dont_Language = new Dictionary<string, string>()
        {
            { dont_language_english, _english },
            { dont_language_deutsch, _deutsch }
        };

        public Dictionary<string, string> Charge = new Dictionary<string, string>()
        {
            { charge_english, _english }
        };

        public Dictionary<string, string> Unknow = new Dictionary<string, string>()
        {
            { unknow_english, _english }
        };

        public Dictionary<string, string> Clear = new Dictionary<string, string>()
        {
            { clear_english, _english }
        };

        public Dictionary<string, string> Load = new Dictionary<string, string>()
        {
            { load_english, _english },
            { load_deutsch, _deutsch }
        };

        public Dictionary<string, string> Letter = new Dictionary<string, string>()
        {
            { letter_english, _english },
            { letter_deutsch, _deutsch }
        };

        public List<Materia>? Book_English { get; set; } = new List<Materia>();
        public List<Materia>? Book_Deutsch { get; set; } = new List<Materia>();
        public List<Materia>? Book_Italiano { get; set; } = new List<Materia>();
        public List<Materia>? Book_Francais { get; set; } = new List<Materia>();
        public List<Materia>? Book_Espanol { get; set; } = new List<Materia>();

        public Dictionary<string, string> Informative = new Dictionary<string, string>()
        {
            { declarative_portugues, _english }
        };

        public Dictionary<string, string> Inquisitive = new Dictionary<string, string>()
        {
            { interrogative_portugues, _english }
        };

        public Dictionary<string, string> Immediate = new Dictionary<string, string>()
        {
            { imperative_portugues, _english }
        };

        public Dictionary<string, string> Sample = new Dictionary<string, string>()
        {
            { sample_english, _english }
        };

        public Dictionary<string, string> Compound = new Dictionary<string, string>()
        {
            { compound_english, _english }
        };

        public Dictionary<string, string> Hidden = new Dictionary<string, string>()
        {
            { hidden_english, _english }
        };

        public Dictionary<string, string> Subordinative = new Dictionary<string, string>()
        {
            { subordinate_portugues, _english },
        };

        public Dictionary<string, string> Coordenative = new Dictionary<string, string>()
        {
            { coordenative_portugues, _english },
        };

        public Dictionary<string, string> Veredict = new Dictionary<string, string>()
        {
            { declarative_english, _english },
            { interrogative_english, _english },
            { imperative_english, _english}
        };

        public Dictionary<string, string> Conditional = new Dictionary<string, string>()
        {
            { hidden_english, _english },
            { sample_english, _english },
            { compound_english, _english}
        };

        public Dictionary<string, string> Compost = new Dictionary<string, string>()
        {
            { sample_english, _english },
            { coordenative_english, _english },
            { subordinate_english, _english}
        };

        #endregion
    }
}
