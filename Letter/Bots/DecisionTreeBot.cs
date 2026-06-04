using Letter.Bots.Interface;
using Letter.Models;
using Letter.Services;

namespace Letter.Bots
{
    public class DecisionTreeBot : IDecisionTreeBot
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
        private Dictionary<string, string> _declarative;
        private Dictionary<string, string> _interrogative;
        private Dictionary<string, string> _options;
        private Dictionary<string, string> _choose;
        private Dictionary<string, string> _terminate;
        private Dictionary<string, string> _sample;
        private Dictionary<string, string> _compound;
        private Dictionary<string, string> _hidden;
        private Dictionary<string, string> _subordinative;
        private Dictionary<string, string> _coordenative;

        private Dictionary<string, string> _sentence;
        private Dictionary<string, string> _subject;
        private Dictionary<string, string> _period;

        private SettingService? _settingService;
        #endregion

        #region CONSTRUCTOR
        public DecisionTreeBot()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Decistion Tree\" bot failed!");
                else this.error_message = string.Empty;

                this._settingService = SettingService.Instance;

                this._declarative = this._settingService.Informative;
                this._interrogative = this._settingService.Inquisitive;
                this._options = this._settingService.Options;
                this._choose = this._settingService.Choose;
                this._terminate = this._settingService.Terminate;
                this._sample = this._settingService.Sample;
                this._compound = this._settingService.Compound;
                this._hidden = this._settingService.Hidden;
                this._coordenative = this._settingService.Coordenative;
                this._subordinative = this._settingService.Subordinative;

                this._sentence = this._settingService.Veredict;
                this._subject = this._settingService.Conditional;
                this._period = this._settingService.Compost;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTIONS
        public async Task<string> Sentence(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation sentence \"Decision Tree\" bot failed!");

                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> declarative = this._declarative
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> interrogative = this._interrogative
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = $"{choose.ToArray()[0]} {options.ToArray()[0]}: \"{declarative.ToArray()[0]}\" or \"{interrogative.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> Subject(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation subject \"Decision Tree\" bot failed!");

                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> sample = this._sample
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> compound = this._compound
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> hidden = this._hidden
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = $"{choose.ToArray()[0]} {options.ToArray()[0]}: \"{sample.ToArray()[0]}\" or \"{compound.ToArray()[0]}\"  or \"{hidden.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> Period(string language)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation subject \"Decision Tree\" bot failed!");

                HashSet<string> choose = this._choose
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> options = this._options
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> sample = this._sample
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> subornative = this._subordinative
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> coordenative = this._coordenative
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> terminate = this._terminate
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                string ask = $"{choose.ToArray()[0]} {options.ToArray()[0]}: \"{sample.ToArray()[0]}\" or \"{coordenative.ToArray()[0]}\"  or \"{subornative.ToArray()[0]}\" or \"{terminate.ToArray()[0]}\".";
                return ask;
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
                if (this._error_off) throw new InvalidOperationException("Operation load \"Decision Tree\" bot failed!");

                HashSet<string> sentences = this._sentence
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                List<string> result = new List<string>();
                string ask = string.Empty;
                if (Array.IndexOf(sentences.ToArray(), parameter) != -1)
                {
                    //subject optons hidden, compound and sample
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

        public async Task<string> Choose(string language, List<Message> messages)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation choose \"Capture\" bot failed!");

                HashSet<string> sentences = this._sentence
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> subjects = this._subject
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                HashSet<string> periods = this._period
                    .Where(index => index.Value.Contains(language))
                    .ToDictionary(index => index.Key, index => index.Value).Keys.ToHashSet();

                bool sentence = false;
                bool subject = false;
                bool period = false;

                List<Message> memos = new List<Message>();
                memos = messages.FindAll(index => index.Sender == null);

                foreach (Message memo in memos)
                {
                    if (Array.IndexOf(sentences.ToArray(), memo.Text) != -1) sentence = true;
                    if (Array.IndexOf(subjects.ToArray(), memo.Text) != -1) subject = true;
                    if (Array.IndexOf(periods.ToArray(), memo.Text) != -1) period = true;
                }

                string response = string.Empty;

                if ((sentence) && (!subject) && (!period)) response = await Sentence(language);
                if ((sentence) && (subject) && (!period)) response = await Subject(language);
                if ((sentence) && (subject) && (period)) response = await Period(language);

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
