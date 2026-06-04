using Letter.Enums;
using Letter.Models;
using Letter.Services.Interfaces;
using Level = Letter.Enums.Level;

namespace Letter.Services
{
    public class SyntaxService : ISyntaxService
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
        private string _subject;
        private string _predicate;
        private string _pronoun;
        private string _noun;
        private string _verb;
        private string _personal;
        private string _adjective;
        private string _article;
        private string _numeral;
        private string _preposition;
        private string _possessive;
        private string _demonstrative;
        private string _adverb;
        private string _adverb_adverb;
        private string _adjective_noun;
        private string _adjective_adverb;
        private string _conjunction;
        private string _numeral_noun;
        private string _adnominal_adjunct;
        private string _adverbial_verb;
        private string _adverbial_adjective;

        private HashSet<string> _morphology;
        private HashSet<string> _syntax;
        private HashSet<int> _order;

        private int _order_1 = 1;
        private int _order_2 = 2;
        private int _order_3 = 3;
        private int _order_4 = 4;

        private byte[] _tutorial_sequence_1;
        private int _practice_sequence_1;

        private SettingService? _settingService;
        private IWordEmbeddingService? _wordEmbeddingService;
        #endregion

        #region CONSTRUCTOR
        public SyntaxService(WordEmbeddingService wordEmbeddingService)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Syntax\" service failed!");

                this._wordEmbeddingService = wordEmbeddingService;
                this._settingService = SettingService.Instance;

                this._subject = this._settingService.Suject;
                this._predicate = this._settingService.Predicate;
                this._pronoun = this._settingService.Pronoun;
                this._noun = this._settingService.Noun;
                this._verb = this._settingService.Verb;
                this._personal = this._settingService.Personal;
                this._adjective = this._settingService.Adjective;
                this._article = this._settingService.Article;
                this._numeral = this._settingService.Numeral;
                this._preposition = this._settingService.Preposition;
                this._possessive = this._settingService.Possessive;
                this._demonstrative = this._settingService.Demonstrative;
                this._adverb = this._settingService.Adverb;
                this._adverb_adverb = this._settingService.Adverb_Adverb;
                this._adjective_noun = this._settingService.Adjective_Noun;
                this._adjective_adverb = this._settingService.Adjective_Adverb;
                this._conjunction = this._settingService.Conjunction;
                this._numeral_noun = this._settingService.Numeral_Noun;
                this._morphology = this._settingService.Morphology;
                this._syntax = this._settingService.Syntax;
                this._order = this._settingService.Order;
                this._adnominal_adjunct = this._settingService.Adnominal_Adjunct;
                this._adverbial_verb = this._settingService.Adverbial_Verb;
                this._adverbial_adjective = this._settingService.Adverbial_Adjective;
                this._tutorial_sequence_1 = this._wordEmbeddingService.Encode(this._order_1, this._order);
                this._practice_sequence_1 = this._wordEmbeddingService.EncodeInt(this._order_1, this._order);
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
        private List<Tutorial> Union(List<Tutorial> firsts, List<Tutorial> lasts)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation union \"Syntax\" service failed!");

                List<Tutorial> tutorials = new List<Tutorial>();
                firsts.ForEach(item => tutorials.Add(item));
                lasts.ForEach(item => tutorials.Add(item));
                return tutorials;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        //-String-Byte[]-Int
        private List<Lesson> Union(List<Lesson> firsts, List<Lesson> lasts)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation union \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                firsts.ForEach(item =>
                {
                    lessons.Add(item);
                });
                lasts.ForEach(item =>
                {
                    lessons.Add(item);
                });
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> FilterLesson(List<Lesson> matters, List<string> kinds)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation filter lesson \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                for (int quantity = 0; quantity < matters.Count(); quantity++)
                {
                    foreach (string item in kinds)
                    {
                        if (matters[quantity].team == item)
                            lessons.Add(matters[quantity]);
                    };
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> FilterLesson(List<Tutorial> tutorials, List<byte[]> kinds)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation filter lesson \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                for (int quantity = 0; quantity < tutorials.Count(); quantity++)
                {
                    foreach (byte[] item in kinds)
                    {
                        if (tutorials[quantity].team.AsSpan().SequenceEqual(item))
                            seminars.Add(tutorials[quantity]);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> FilterLesson(List<Practice> practices, List<int> kinds)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation filter lesson \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                for (int quantity = 0; quantity < practices.Count(); quantity++)
                {
                    foreach (int item in kinds)
                    {
                        if (practices[quantity].team == item)
                            seminars.Add(practices[quantity]);
                    };
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbSampleSubject(List<Instruction> words, Dictionary<(byte[], byte[]), int>? word_2_vec, Level level, int order_noun, int order_verb)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb sample subject \"Syntax\" service failed!");

                byte[]? adnominal = null;
                byte[]? adverbial = null;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Rear);
                adnominal = VerifyNoun(words, order_noun, level, Rotate.Front, Seat.Subject);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbSampleSubject(List<Word> words, Dictionary<(string, string), int>? word_2_vec, Level level, int order_noun, int order_verb)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb sample subject \"Syntax\" service failed!");

                string adnominal = string.Empty;
                string adverbial = string.Empty;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Rear);
                adnominal = VerifyNoun(words, order_noun, level, Rotate.Front, Seat.Subject);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbSampleSubject(List<Guidance> words, Dictionary<(int, int), int>? word_2_vec, Level level, int order_noun, int order_verb)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb sample subject \"Syntax\" service failed!");

                int adnominal = -1;
                int adverbial = -1;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Rear);
                adnominal = VerifyNoun(words, order_noun, level, Rotate.Front, Seat.Subject);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyVerb(List<Word> words, int order, Level level, Rotate rotate)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb \"Syntax\" service failed!");

                string syntax_predicate = this._predicate;
                string morphology_adverbial_verb = this._adverbial_verb;
                string morphology_verb = this._verb;
                string morphology_adverb = this._adverb;
                string morphology_adverb_adverb = this._adverb_adverb;
                int morphology_order = order;

                string verb = string.Empty;
                string verb_adverb = string.Empty;
                string verb_adverb_adverb = string.Empty;

                string adverbial = string.Empty;

                if (level == Level.Default)
                {
                    foreach (Word item in words)
                    {
                        if (item.kind == morphology_verb
                            && item.order == morphology_order) verb = item.term;
                        if ((item.sentence == syntax_predicate)
                            && (item.team == morphology_adverbial_verb)
                            && (item.kind == morphology_adverb)
                            && (item.order == morphology_order)) verb_adverb = item.term;
                        if ((item.sentence == syntax_predicate)
                            && (item.team == morphology_adverbial_verb)
                            && (item.kind == morphology_adverb_adverb)
                            && (item.order == morphology_order)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Word item in words)
                    {
                        if (item.kind.Equals(morphology_verb)
                            && item.order.Equals(morphology_order)) verb = item.term;
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.team.Equals(morphology_adverbial_verb))
                            && (item.kind.Equals(morphology_adverb))
                            && (item.order.Equals(morphology_order))) verb_adverb = item.term;
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.team.Equals(morphology_adverbial_verb))
                            && (item.kind.Equals(morphology_adverb_adverb))
                            && (item.order.Equals(morphology_order))) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Word item in words)
                    {
                        if (item.kind.AsSpan().SequenceEqual(morphology_verb)
                            && item.order == morphology_order) verb = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb))
                            && (item.order == morphology_order)) verb_adverb = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))
                            && (item.order == morphology_order)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Word item in words)
                    {
                        if (item.kind.SequenceEqual(morphology_verb)
                            && item.order == morphology_order) verb = item.term;
                        if ((item.sentence.SequenceEqual(syntax_predicate))
                            && (item.team.SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.SequenceEqual(morphology_adverb))
                            && (item.order == morphology_order)) verb_adverb = item.term;
                        if ((item.sentence.SequenceEqual(syntax_predicate))
                            && (item.team.SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.SequenceEqual(morphology_adverb_adverb))
                            && (item.order == morphology_order)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Word item in words)
                    {
                        if ((item.kind.CompareTo(morphology_verb) != -1) 
                            && (item.order.CompareTo(morphology_order) != -1))verb = item.term;
                        if ((item.sentence.CompareTo(syntax_predicate) != -1)
                            && (item.team.CompareTo(morphology_adverbial_verb) != -1)
                            && (item.kind.CompareTo(morphology_adverb) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) verb_adverb = item.term;
                        if ((item.sentence.CompareTo(syntax_predicate) != -1)
                            && (item.team.CompareTo(morphology_adverbial_verb) != -1)
                            && (item.kind.CompareTo(morphology_adverb_adverb) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Word item in words)
                    {
                        if ((item.kind.IndexOf(morphology_verb) != -1) 
                            && (item.order.Equals(morphology_order))) verb = item.term;
                        if ((item.sentence.IndexOf(syntax_predicate) != -1)
                            && (item.team.IndexOf(morphology_adverbial_verb) != -1)
                            && (item.kind.IndexOf(morphology_adverb) != -1)
                            && (item.order.Equals(morphology_order))) verb_adverb = item.term;
                        if ((item.sentence.IndexOf(syntax_predicate) != -1)
                            && (item.team.IndexOf(morphology_adverbial_verb) != -1)
                            && (item.kind.IndexOf(morphology_adverb_adverb) != -1)
                            && (item.order.Equals(morphology_order))) verb_adverb_adverb = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (verb != string.Empty)
                        adverbial = verb;
                    if ((verb_adverb != string.Empty) && (verb != string.Empty))
                        adverbial = verb_adverb;
                    if ((verb_adverb_adverb != string.Empty) && (verb_adverb != string.Empty) && (verb != string.Empty))
                        adverbial = verb_adverb_adverb;
                }
                if (rotate == Rotate.Rear)
                {
                    if (verb != string.Empty)
                        adverbial = verb;
                    if ((verb_adverb != string.Empty) && (verb != string.Empty))
                        adverbial = verb;
                    if ((verb_adverb_adverb != string.Empty) && (verb_adverb != string.Empty) && (verb != string.Empty))
                        adverbial = verb;
                }
                return adverbial;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyVerb(List<Instruction> words, int order, Level level, Rotate rotate)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);
                byte[] morphology_order = this._wordEmbeddingService.Encode(order, this._order);

                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? adverbial = null;

                if (level == Level.Default)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.kind == morphology_verb)
                            && (item.order == morphology_order)) verb = item.term;
                        if ((item.sentence == syntax_predicate)
                            && (item.team == morphology_adverbial_verb)
                            && (item.kind == morphology_adverb)
                            && (item.order == morphology_order)) verb_adverb = item.term;
                        if ((item.sentence == syntax_predicate)
                            && (item.team == morphology_adverbial_verb)
                            && (item.kind == morphology_adverb_adverb)
                            && (item.order == morphology_order)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.kind.Equals(morphology_verb))
                            && (item.order.Equals(morphology_order))) verb = item.term;
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.team.Equals(morphology_adverbial_verb))
                            && (item.kind.Equals(morphology_adverb))
                            && (item.order.Equals(morphology_order))) verb_adverb = item.term;
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.team.Equals(morphology_adverbial_verb))
                            && (item.kind.Equals(morphology_adverb_adverb))
                            && (item.order.Equals(morphology_order))) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.kind.AsSpan().SequenceEqual(morphology_verb))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) verb = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) verb_adverb = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.kind.SequenceEqual(morphology_verb))
                            && (item.order.SequenceEqual(morphology_order))) verb = item.term;
                        if ((item.sentence.SequenceEqual(syntax_predicate))
                            && (item.team.SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.SequenceEqual(morphology_adverb))
                            && (item.order.SequenceEqual(morphology_order))) verb_adverb = item.term;
                        if ((item.sentence.SequenceEqual(syntax_predicate))
                            && (item.team.SequenceEqual(morphology_adverbial_verb))
                            && (item.kind.SequenceEqual(morphology_adverb_adverb))
                            && (item.order.SequenceEqual(morphology_order))) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.kind.SequenceCompareTo(morphology_verb) != -1) 
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) verb = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax_predicate) != -1)
                            && (item.team.SequenceCompareTo(morphology_adverbial_verb) != -1)
                            && (item.kind.SequenceCompareTo(morphology_adverb) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) verb_adverb = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax_predicate) != -1)
                            && (item.team.SequenceCompareTo(morphology_adverbial_verb) != -1)
                            && (item.kind.SequenceCompareTo(morphology_adverb_adverb) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.kind.IndexOf(morphology_verb) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) verb = item.term;
                        if ((item.sentence.IndexOf(syntax_predicate) != -1)
                            && (item.team.IndexOf(morphology_adverbial_verb) != -1)
                            && (item.kind.IndexOf(morphology_adverb) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) verb_adverb = item.term;
                        if ((item.sentence.IndexOf(syntax_predicate) != -1)
                            && (item.team.IndexOf(morphology_adverbial_verb) != -1)
                            && (item.kind.IndexOf(morphology_adverb_adverb) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) verb_adverb_adverb = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (verb != null)
                        adverbial = verb;
                    if ((verb_adverb != null) && (verb != null))
                        adverbial = verb_adverb;
                    if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                        adverbial = verb_adverb_adverb;
                }
                if (rotate == Rotate.Rear)
                {
                    if (verb != null)
                        adverbial = verb;
                    if ((verb_adverb != null) && (verb != null))
                        adverbial = verb;
                    if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                        adverbial = verb;
                }
                return adverbial;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyVerb(List<Guidance> words, int order, Level level, Rotate rotate)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb \"Syntax\" service failed!");

                int syntax_predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int morphology_adverbial_verb = this._wordEmbeddingService.EncodeInt(this._adverbial_verb, this._morphology);
                int morphology_verb = this._wordEmbeddingService.EncodeInt(this._verb, this._morphology);
                int morphology_adverb = this._wordEmbeddingService.EncodeInt(this._adverb, this._morphology);
                int morphology_adverb_adverb = this._wordEmbeddingService.EncodeInt(this._adverb_adverb, this._morphology);

                int verb = -1;
                int verb_adverb = -1;
                int verb_adverb_adverb = -1;

                int adverbial = -1;

                if (level == Level.Default)
                {
                    foreach (Guidance item in words)
                    {
                        if (item.kind == morphology_verb) verb = item.term;
                        if ((item.sentence == syntax_predicate)
                            && (item.team == morphology_adverbial_verb)
                            && (item.kind == morphology_adverb)) verb_adverb = item.term;
                        if ((item.sentence == syntax_predicate)
                            && (item.team == morphology_adverbial_verb)
                            && (item.kind == morphology_adverb_adverb)) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Guidance item in words)
                    {
                        if (item.kind.Equals(morphology_verb)) verb = item.term;
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.team.Equals(morphology_adverbial_verb))
                            && (item.kind.Equals(morphology_adverb))) verb_adverb = item.term;
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.team.Equals(morphology_adverbial_verb))
                            && (item.kind.Equals(morphology_adverb_adverb))) verb_adverb_adverb = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Guidance item in words)
                    {
                        if (item.kind.CompareTo(morphology_verb) != -1) verb = item.term;
                        if ((item.sentence.CompareTo(syntax_predicate) != -1)
                            && (item.team.CompareTo(morphology_adverbial_verb) != -1)
                            && (item.kind.CompareTo(morphology_adverb) != -1)) verb_adverb = item.term;
                        if ((item.sentence.CompareTo(syntax_predicate) != -1)
                            && (item.team.CompareTo(morphology_adverbial_verb) != -1)
                            && (item.kind.CompareTo(morphology_adverb_adverb) != -1)) verb_adverb_adverb = item.term;
                    }
                }
                if (rotate == Rotate.Front)
                {
                    if (verb != -1)
                        adverbial = verb;
                    if ((verb_adverb != -1) && (verb != -1))
                        adverbial = verb_adverb;
                    if ((verb_adverb_adverb != -1) && (verb_adverb != -1) && (verb != -1))
                        adverbial = verb_adverb_adverb;
                }
                if (rotate == Rotate.Rear)
                {
                    if (verb != -1)
                        adverbial = verb;
                    if ((verb_adverb != -1) && (verb != -1))
                        adverbial = verb;
                    if ((verb_adverb_adverb != -1) && (verb_adverb != -1) && (verb != -1))
                        adverbial = verb;
                }
                return adverbial;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyNoun(List<Word> words, int order, Level level, Rotate rotate, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun \"Syntax\" service failed!");

                string adnominal = string.Empty;
                int order_conjunction = this._order_1;

                adnominal = VerifyNoun(words, order, level, rotate, seat, order_conjunction);
                return adnominal;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyNoun(List<Word> words, int order, Level level, Rotate rotate, Seat seat, int order_conjunction)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun \"Syntax\" service failed!");

                string syntax = string.Empty;
                if (seat == Seat.Subject)
                    syntax = this._subject;
                if (seat == Seat.Predicate)
                    syntax = this._predicate;

                string morphology_adnominal_adjunct = this._adnominal_adjunct;
                string morphology_noun = this._noun;
                string morphology_adjective = this._adjective;
                string morphology_article = this._article;
                string morphology_numeral = this._numeral;
                string morphology_pronoun = this._pronoun;
                int morphology_order = order;
                int morphology_sequence = order_conjunction;

                string noun = string.Empty;
                string adjective = string.Empty;
                string article = string.Empty;
                string numeral = string.Empty;
                string pronoun = string.Empty;

                string adnominal = string.Empty;

                if (level == Level.Default)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_adjective)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) adjective = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_article)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) article = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_numeral)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) numeral = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_pronoun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) pronoun = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_noun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                        if ((item.sentence == syntax)
                            && (!(item.team == morphology_adnominal_adjunct))
                            && (item.kind == morphology_pronoun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_adjective))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) adjective = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_article))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) article = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_numeral))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) numeral = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_pronoun))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) pronoun = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_noun))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) noun = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (!item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_pronoun))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) noun = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) adjective = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_article))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) article = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_numeral))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) numeral = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) pronoun = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_adjective))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) adjective = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_article))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) article = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_numeral))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) numeral = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_pronoun))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) pronoun = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_noun))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (!item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_pronoun))
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_adjective) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.sequence.CompareTo(morphology_sequence) != -1)) adjective = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_article) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.sequence.CompareTo(morphology_sequence) != -1)) article = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_numeral) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.sequence.CompareTo(morphology_sequence) != -1)) numeral = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_pronoun) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.sequence.CompareTo(morphology_sequence) != -1)) pronoun = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_noun) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.sequence.CompareTo(morphology_sequence) != -1)) noun = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (!(item.team.CompareTo(morphology_adnominal_adjunct) != -1))
                            && (item.kind.CompareTo(morphology_pronoun) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.sequence.CompareTo(morphology_sequence) != -1)) noun = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_adjective) != -1)
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) adjective = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_article) != -1)
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) article = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_numeral) != -1)
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) numeral = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_pronoun) != -1)
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) pronoun = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_noun) != -1)
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) noun = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (!(item.team.IndexOf(morphology_adnominal_adjunct) != -1))
                            && (item.kind.IndexOf(morphology_pronoun) != -1)
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) noun = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (noun != string.Empty)
                        adnominal = noun;
                    if ((noun != string.Empty) && (adjective != string.Empty))
                        adnominal = noun;
                    if ((noun != string.Empty) && (article != string.Empty))
                        adnominal = noun;
                    if ((noun != string.Empty) && (numeral != string.Empty))
                        adnominal = noun;
                    if ((noun != string.Empty) && (pronoun != string.Empty))
                        adnominal = noun;
                }
                if (rotate == Rotate.Rear)
                {
                    if (noun != string.Empty)
                        adnominal = noun;
                    if ((noun != string.Empty) && (adjective != string.Empty))
                        adnominal = adjective;
                    if ((noun != string.Empty) && (article != string.Empty))
                        adnominal = article;
                    if ((noun != string.Empty) && (numeral != string.Empty))
                        adnominal = numeral;
                    if ((noun != string.Empty) && (pronoun != string.Empty))
                        adnominal = pronoun;
                }

                return adnominal;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyNoun(List<Instruction> words, int order, Level level, Rotate rotate, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun \"Syntax\" service failed!");

                byte[]? adnominal = null;
                int order_conjunction = this._order_1;

                adnominal = VerifyNoun(words, order, level, rotate, seat, order_conjunction);
                return adnominal;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyNoun(List<Instruction> words, int order, Level level, Rotate rotate, Seat seat, int order_conjunction)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun \"Syntax\" service failed!");

                byte[] syntax = null;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_order = this._wordEmbeddingService.Encode(order, this._order);
                byte[] morphology_sequence = this._wordEmbeddingService.Encode(order_conjunction, this._order);

                byte[]? noun = null;
                byte[]? adjective = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? adnominal = null;

                if (level == Level.Default)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_adjective)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) adjective = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_article)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) article = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_numeral)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) numeral = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_pronoun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) pronoun = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_noun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                        if ((item.sentence == syntax)
                            && (!(item.team == morphology_adnominal_adjunct))
                            && (item.kind == morphology_pronoun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_adjective))
                            && (item.order.Equals(morphology_order))
                            && (item.order.Equals(morphology_sequence))) adjective = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_article))
                            && (item.order.Equals(morphology_order))
                            && (item.order.Equals(morphology_sequence))) article = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_numeral))
                            && (item.order.Equals(morphology_order))
                            && (item.order.Equals(morphology_sequence))) numeral = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_pronoun))
                            && (item.order.Equals(morphology_order))
                            && (item.order.Equals(morphology_sequence))) pronoun = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_noun))
                            && (item.order.Equals(morphology_order))
                            && (item.order.Equals(morphology_sequence))) noun = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (!item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_pronoun))
                            && (item.order.Equals(morphology_order))
                            && (item.order.Equals(morphology_sequence))) noun = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))
                            && (item.sequence.AsSpan().SequenceEqual(morphology_sequence))) adjective = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_article))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))
                            && (item.sequence.AsSpan().SequenceEqual(morphology_sequence))) article = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_numeral))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))
                            && (item.sequence.AsSpan().SequenceEqual(morphology_sequence))) numeral = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))
                            && (item.sequence.AsSpan().SequenceEqual(morphology_sequence))) pronoun = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))
                            && (item.sequence.AsSpan().SequenceEqual(morphology_sequence))) noun = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))
                            && (item.sequence.AsSpan().SequenceEqual(morphology_sequence))) noun = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_adjective))
                            && (item.order.SequenceEqual(morphology_order))
                            && (item.sequence.SequenceEqual(morphology_sequence))) adjective = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_article))
                            && (item.order.SequenceEqual(morphology_order))
                            && (item.sequence.SequenceEqual(morphology_sequence))) article = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_numeral))
                            && (item.order.SequenceEqual(morphology_order))
                            && (item.sequence.SequenceEqual(morphology_sequence))) numeral = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_pronoun))
                            && (item.order.SequenceEqual(morphology_order))
                            && (item.sequence.SequenceEqual(morphology_sequence))) pronoun = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_noun))
                            && (item.order.SequenceEqual(morphology_order))
                            && (item.sequence.SequenceEqual(morphology_sequence))) noun = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (!item.team.SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.SequenceEqual(morphology_pronoun))
                            && (item.order.SequenceEqual(morphology_order))
                            && (item.sequence.SequenceEqual(morphology_sequence))) noun = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.SequenceCompareTo(morphology_adjective) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)
                            && (item.sequence.SequenceCompareTo(morphology_sequence) != -1)) adjective = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.SequenceCompareTo(morphology_article) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)
                            && (item.sequence.SequenceCompareTo(morphology_sequence) != -1)) article = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.SequenceCompareTo(morphology_numeral) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)
                            && (item.sequence.SequenceCompareTo(morphology_sequence) != -1)) numeral = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.SequenceCompareTo(morphology_pronoun) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)
                            && (item.sequence.SequenceCompareTo(morphology_sequence) != -1)) pronoun = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.SequenceCompareTo(morphology_noun) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)
                            && (item.sequence.SequenceCompareTo(morphology_sequence) != -1)) noun = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (!(item.team.SequenceCompareTo(morphology_adnominal_adjunct) != -1))
                            && (item.kind.SequenceCompareTo(morphology_pronoun) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)
                            && (item.sequence.SequenceCompareTo(morphology_sequence) != -1)) noun = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_adjective) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)
                            && (item.sequence.IndexOf(morphology_sequence) != -1)) adjective = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_article) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)
                            && (item.sequence.IndexOf(morphology_sequence) != -1)) article = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_numeral) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)
                            && (item.sequence.IndexOf(morphology_sequence) != -1)) numeral = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_pronoun) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)
                            && (item.sequence.IndexOf(morphology_sequence) != -1)) pronoun = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adnominal_adjunct) != -1)
                            && (item.kind.IndexOf(morphology_noun) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)
                            && (item.sequence.IndexOf(morphology_sequence) != -1)) noun = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (!(item.team.IndexOf(morphology_adnominal_adjunct) != -1))
                            && (item.kind.IndexOf(morphology_pronoun) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)
                            && (item.sequence.IndexOf(morphology_sequence) != -1)) noun = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (noun != null)
                        adnominal = noun;
                    if ((noun != null) && (adjective != null))
                        adnominal = noun;
                    if ((noun != null) && (article != null))
                        adnominal = noun;
                    if ((noun != null) && (numeral != null))
                        adnominal = noun;
                    if ((noun != null) && (pronoun != null))
                        adnominal = noun;
                }
                if (rotate == Rotate.Rear)
                {
                    if (noun != null)
                        adnominal = noun;
                    if ((noun != null) && (adjective != null))
                        adnominal = adjective;
                    if ((noun != null) && (article != null))
                        adnominal = article;
                    if ((noun != null) && (numeral != null))
                        adnominal = numeral;
                    if ((noun != null) && (pronoun != null))
                        adnominal = pronoun;
                }

                return adnominal;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyNoun(List<Guidance> words, int order, Level level, Rotate rotate, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun \"Syntax\" service failed!");

                int adnominal = -1;
                int order_conjunction = this._order_1;

                adnominal = VerifyNoun(words, order, level, rotate, seat, order_conjunction);
                return adnominal;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyNoun(List<Guidance> words, int order, Level level, Rotate rotate, Seat seat, int order_conjunction)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun \"Syntax\" service failed!");

                int syntax = -1;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.EncodeInt(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);

                int morphology_adnominal_adjunct = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                int morphology_noun = this._wordEmbeddingService.EncodeInt(this._noun, this._morphology);
                int morphology_adjective = this._wordEmbeddingService.EncodeInt(this._adjective, this._morphology);
                int morphology_article = this._wordEmbeddingService.EncodeInt(this._article, this._morphology);
                int morphology_numeral = this._wordEmbeddingService.EncodeInt(this._numeral, this._morphology);
                int morphology_pronoun = this._wordEmbeddingService.EncodeInt(this._pronoun, this._morphology);
                int morphology_order = this._wordEmbeddingService.EncodeInt(order, this._order);
                int morphology_sequence = this._wordEmbeddingService.EncodeInt(order_conjunction, this._order);

                int noun = -1;
                int adjective = -1;
                int article = -1;
                int numeral = -1;
                int pronoun = -1;

                int adnominal = -1;

                if (level == Level.Default)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_adjective)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) adjective = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_article)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) article = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_numeral)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) numeral = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_pronoun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) pronoun = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adnominal_adjunct)
                            && (item.kind == morphology_noun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                        if ((item.sentence == syntax)
                            && (!(item.team == morphology_adnominal_adjunct))
                            && (item.kind == morphology_pronoun)
                            && (item.order == morphology_order)
                            && (item.sequence == morphology_sequence)) noun = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_adjective))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) adjective = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_article))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) article = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_numeral))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) numeral = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_pronoun))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) pronoun = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_noun))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) noun = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (!item.team.Equals(morphology_adnominal_adjunct))
                            && (item.kind.Equals(morphology_pronoun))
                            && (item.order.Equals(morphology_order))
                            && (item.sequence.Equals(morphology_sequence))) noun = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_adjective) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.order.CompareTo(morphology_sequence) != -1)) adjective = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_article) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.order.CompareTo(morphology_sequence) != -1)) article = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_numeral) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.order.CompareTo(morphology_sequence) != -1)) numeral = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_pronoun) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.order.CompareTo(morphology_sequence) != -1)) pronoun = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adnominal_adjunct) != -1)
                            && (item.kind.CompareTo(morphology_noun) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.order.CompareTo(morphology_sequence) != -1)) noun = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (!(item.team.CompareTo(morphology_adnominal_adjunct) != -1))
                            && (item.kind.CompareTo(morphology_pronoun) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)
                            && (item.order.CompareTo(morphology_sequence) != -1)) noun = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (noun != -1)
                        adnominal = noun;
                    if ((noun != -1) && (adjective != -1))
                        adnominal = noun;
                    if ((noun != -1) && (article != -1))
                        adnominal = noun;
                    if ((noun != -1) && (numeral != -1))
                        adnominal = noun;
                    if ((noun != -1) && (pronoun != -1))
                        adnominal = noun;
                }
                if (rotate == Rotate.Rear)
                {
                    if (noun != -1)
                        adnominal = noun;
                    if ((noun != -1) && (adjective != -1))
                        adnominal = adjective;
                    if ((noun != -1) && (article != -1))
                        adnominal = article;
                    if ((noun != -1) && (numeral != -1))
                        adnominal = numeral;
                    if ((noun != -1) && (pronoun != -1))
                        adnominal = pronoun;
                }

                return adnominal;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyConjunction(List<Word> words, int order, Level level, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify conjunction \"Syntax\" service failed!");

                string syntax = string.Empty;
                if (seat == Seat.Subject)
                    syntax = this._subject;
                if (seat == Seat.Predicate)
                    syntax = this._predicate;

                string morphology_conjunction = this._conjunction;
                int morphology_order = order;

                string conjunction = string.Empty;

                if (level == Level.Default)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_conjunction)
                            && (item.kind == morphology_conjunction)
                            && (item.order == morphology_order)) conjunction = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_conjunction))
                            && (item.kind.Equals(morphology_conjunction))
                            && (item.order.Equals(morphology_order))) conjunction = item.term;
                    }

                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                            && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))
                            && (item.order == morphology_order)) conjunction = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_conjunction))
                            && (item.kind.SequenceEqual(morphology_conjunction))
                            && (item.order == morphology_order)) conjunction = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_conjunction) != -1)
                            && (item.kind.CompareTo(morphology_conjunction) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) conjunction = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_conjunction) != -1)
                            && (item.kind.IndexOf(morphology_conjunction) != -1)
                            && (item.order == morphology_order)) conjunction = item.term;
                    }
                }

                return conjunction;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyConjunction(List<Instruction> words, int order, Level level, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify conjunction \"Syntax\" service failed!");

                byte[] syntax = null;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_order = this._wordEmbeddingService.Encode(order, this._order);

                byte[]? conjunction = null;

                if (level == Level.Default)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_conjunction)
                            && (item.kind == morphology_conjunction)
                            && (item.kind == morphology_order)) conjunction = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_conjunction))
                            && (item.kind.Equals(morphology_conjunction))
                            && (item.order.Equals(morphology_order))) conjunction = item.term;
                    }

                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                            && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) conjunction = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_conjunction))
                            && (item.kind.SequenceEqual(morphology_conjunction))
                            && (item.order.SequenceEqual(morphology_order))) conjunction = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_conjunction) != -1)
                            && (item.kind.SequenceCompareTo(morphology_conjunction) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) conjunction = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_conjunction) != -1)
                            && (item.kind.IndexOf(morphology_conjunction) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) conjunction = item.term;
                    }
                }

                return conjunction;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyConjunction(List<Guidance> words, int order, Level level, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify conjunction \"Syntax\" service failed!");

                int syntax = -1;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.EncodeInt(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);

                int morphology_conjunction = this._wordEmbeddingService.EncodeInt(this._conjunction, this._morphology);
                int morphology_order = this._wordEmbeddingService.EncodeInt(order, this._order);

                int conjunction = -1;

                if (level == Level.Default)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_conjunction)
                            && (item.kind == morphology_conjunction)
                            && (item.order == morphology_order)) conjunction = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_conjunction))
                            && (item.kind.Equals(morphology_conjunction))
                            && (item.order.Equals(morphology_order))) conjunction = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_conjunction) != -1)
                            && (item.kind.CompareTo(morphology_conjunction) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) conjunction = item.term;
                    }
                }
                return conjunction;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbCompoundSubject(List<Word> words, List<Word> firsts, List<Word> lasts, Dictionary<(string, string), int> word_2_vec, Level level, int order_noun, int order_verb)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                string conjunction = string.Empty;
                string adnominal = string.Empty;
                string adnominal2 = string.Empty;
                string adnominal2_last = string.Empty;
                string adverbial = string.Empty;

                int order_last = this._order_3; 

                conjunction = VerifyConjunction(words, order_noun, level, Seat.Subject);
                adverbial = VerifyVerb(words, order_verb, level, Rotate.Rear);
                adnominal = VerifyNoun(firsts, order_noun, level, Rotate.Front, Seat.Subject);
                adnominal2 = VerifyNoun(lasts, order_noun, level, Rotate.Rear, Seat.Subject, order_last);
                adnominal2_last = VerifyNoun(lasts, order_noun, level, Rotate.Front, Seat.Subject, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal2_last, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbCompoundSubject(List<Instruction> words, List<Instruction> firsts, List<Instruction> lasts, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, int order_noun, int order_verb)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                byte[]? conjunction = null;
                byte[]? adnominal = null;
                byte[]? adnominal2 = null;
                byte[]? adnominal2_last = null;
                byte[]? adverbial = null;

                int order_last = this._order_3;

                conjunction = VerifyConjunction(words, order_noun, level, Seat.Subject);
                adverbial = VerifyVerb(words, order_verb, level, Rotate.Rear);
                adnominal = VerifyNoun(firsts, order_noun, level, Rotate.Front, Seat.Subject);
                adnominal2 = VerifyNoun(lasts, order_noun, level, Rotate.Rear, Seat.Subject, order_last);
                adnominal2_last = VerifyNoun(lasts, order_noun, level, Rotate.Front, Seat.Subject, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal2_last, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbCompoundSubject(List<Guidance> words, List<Guidance> firsts, List<Guidance> lasts, Dictionary<(int, int), int> word_2_vec, Level level, int order_noun, int order_verb)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                int conjunction = -1;
                int adnominal = -1;
                int adnominal2 = -1;
                int adnominal2_last = -1;
                int adverbial = -1;

                conjunction = VerifyConjunction(words, order_noun, level, Seat.Subject);
                adverbial = VerifyVerb(words, order_verb, level, Rotate.Rear);
                adnominal = VerifyNoun(firsts, order_noun, level, Rotate.Front, Seat.Subject);
                adnominal2 = VerifyNoun(lasts, order_noun, level, Rotate.Rear, Seat.Subject);
                adnominal2_last = VerifyNoun(lasts, order_noun, level, Rotate.Front, Seat.Subject);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal2_last, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyPreposition(List<Instruction> words, int order, Level level)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify preposition \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                byte[] morphology_order = this._wordEmbeddingService.Encode(order, this._order);

                byte[]? preposition = null;

                if (level == Level.Default)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence == syntax_predicate)
                            && (item.kind == morphology_preposition)
                            && (item.order == morphology_order)) preposition = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.kind.Equals(morphology_preposition))
                            && (item.order.Equals(morphology_order))) preposition = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.kind.AsSpan().SequenceEqual(morphology_preposition))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) preposition = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax_predicate))
                            && (item.kind.SequenceEqual(morphology_preposition))
                            && (item.order.SequenceEqual(morphology_order))) preposition = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceCompareTo(syntax_predicate) != -1)
                            && (item.kind.SequenceCompareTo(morphology_preposition) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) preposition = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.IndexOf(syntax_predicate) != -1)
                            && (item.kind.IndexOf(morphology_preposition) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) preposition = item.term;
                    }
                }

                return preposition;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyPreposition(List<Word> words, int order, Level level)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify preposition \"Syntax\" service failed!");

                string syntax_predicate = this._predicate;
                string morphology_preposition = this._preposition;
                int morphology_order = order;

                string preposition = string.Empty;

                if (level == Level.Default)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence == syntax_predicate)
                            && (item.kind == morphology_preposition)
                            && (item.order == morphology_order)) preposition = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.kind.Equals(morphology_preposition))
                            && (item.order.Equals(morphology_order))) preposition = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.kind.AsSpan().SequenceEqual(morphology_preposition))
                            && (item.order == morphology_order)) preposition = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax_predicate))
                            && (item.kind.SequenceEqual(morphology_preposition))
                            && (item.order == morphology_order)) preposition = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.CompareTo(syntax_predicate) != -1)
                            && (item.kind.CompareTo(morphology_preposition) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) preposition = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.IndexOf(syntax_predicate) != -1)
                            && (item.kind.IndexOf(morphology_preposition) != -1)
                            && (item.order == morphology_order)) preposition = item.term;
                    }
                }

                return preposition;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyPreposition(List<Guidance> words, int order, Level level)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify preposition \"Syntax\" service failed!");

                int syntax_predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int morphology_preposition = this._wordEmbeddingService.EncodeInt(this._preposition, this._morphology);
                int morphology_order = this._wordEmbeddingService.EncodeInt(order, this._order);

                int preposition = -1;

                if (level == Level.Default)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence == syntax_predicate)
                            && (item.kind == morphology_preposition)
                            && (item.order == morphology_order)) preposition = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.Equals(syntax_predicate))
                            && (item.kind.Equals(morphology_preposition))
                            && (item.kind.Equals(morphology_order))) preposition = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.CompareTo(syntax_predicate) != -1)
                            && (item.kind.CompareTo(morphology_preposition) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) preposition = item.term;
                    }
                }

                return preposition;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbDirectObject(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, int order_verb, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb direct object \"Syntax\" service failed!");

                byte[]? adnominal = null;
                byte[]? adverbial = null;
                byte[]? preposition = null;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                adnominal = VerifyNoun(words, order_noun, level, Rotate.Rear, Seat.Predicate);
                preposition = VerifyPreposition(words, order_noun, level);

                bool similarity = false;
                if (preposition == null) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, adnominal);
                if (preposition != null) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbDirectObject(List<Word> words, Dictionary<(string, string), int> word_2_vec, Level level, int order_verb, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb direct object \"Syntax\" service failed!");

                string adnominal = string.Empty;
                string adverbial = string.Empty;
                string preposition = string.Empty;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                adnominal = VerifyNoun(words, order_noun, level, Rotate.Rear, Seat.Predicate);
                preposition = VerifyPreposition(words, order_noun, level);

                bool similarity = false;
                if (preposition == string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, adnominal);
                if (preposition != string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbDirectObject(List<Guidance> words, Dictionary<(int, int), int> word_2_vec, Level level, int order_verb, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb direct object \"Syntax\" service failed!");

                int adnominal = -1;
                int adverbial = -1;
                int preposition = -1;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                adnominal = VerifyNoun(words, order_noun, level, Rotate.Rear, Seat.Predicate);
                preposition = VerifyPreposition(words, order_noun, level);

                bool similarity = false;
                if (preposition == -1) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, adnominal);
                if (preposition != -1) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyNumeral(List<Instruction> words, int order, Level level, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify numeral \"Syntax\" service failed!");

                byte[] syntax = null;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_order = this._wordEmbeddingService.Encode(order, this._order);

                byte[]? numeral = null;

                if (level == Level.Default)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_numeral)
                            && (item.kind == morphology_numeral)
                            && (item.order == morphology_order)) numeral = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_numeral))
                            && (item.kind.Equals(morphology_numeral))
                            && (item.order.Equals(morphology_order))) numeral = item.term;
                    }

                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_numeral))
                            && (item.kind.AsSpan().SequenceEqual(morphology_numeral))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) numeral = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_numeral))
                            && (item.kind.SequenceEqual(morphology_numeral))
                            && (item.order.SequenceEqual(morphology_order))) numeral = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_numeral) != -1)
                            && (item.kind.SequenceCompareTo(morphology_numeral) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) numeral = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_numeral) != -1)
                            && (item.kind.IndexOf(morphology_numeral) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) numeral = item.term;
                    }
                }

                return numeral;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyNumeral(List<Word> words, int order, Level level, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify numeral \"Syntax\" service failed!");

                string syntax = string.Empty;
                if (seat == Seat.Subject)
                    syntax = this._subject;
                if (seat == Seat.Predicate)
                    syntax = this._predicate;

                string morphology_numeral = this._numeral;
                int morphology_order = order;

                string numeral = string.Empty;

                if (level == Level.Default)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_numeral)
                            && (item.kind == morphology_numeral)
                            && (item.order == morphology_order)) numeral = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_numeral))
                            && (item.kind.Equals(morphology_numeral))
                            && (item.order.Equals(morphology_order))) numeral = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_numeral))
                            && (item.kind.AsSpan().SequenceEqual(morphology_numeral))
                            && (item.order == morphology_order)) numeral = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_numeral))
                            && (item.kind.SequenceEqual(morphology_numeral))
                            && (item.order == morphology_order)) numeral = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_numeral) != -1)
                            && (item.kind.CompareTo(morphology_numeral) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) numeral = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_numeral) != -1)
                            && (item.kind.IndexOf(morphology_numeral) != -1)
                            && (item.order == morphology_order)) numeral = item.term;
                    }
                }

                return numeral;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyNumeral(List<Guidance> words, int order, Level level, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify numeral \"Syntax\" service failed!");

                int syntax = -1;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.EncodeInt(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);

                int morphology_numeral = this._wordEmbeddingService.EncodeInt(this._numeral, this._morphology);
                int morphology_order = this._wordEmbeddingService.EncodeInt(order, this._order);

                int numeral = -1;

                if (level == Level.Default)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_numeral)
                            && (item.kind == morphology_numeral)
                            && (item.order == morphology_order)) numeral = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_numeral))
                            && (item.kind.Equals(morphology_numeral))
                            && (item.order.Equals(morphology_order))) numeral = item.term;
                    }

                }
                if (level == Level.Compare)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_numeral) != -1)
                            && (item.kind.CompareTo(morphology_numeral) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) numeral = item.term;
                    }
                }

                return numeral;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private byte[]? VerifyAdjective(List<Instruction> words, int order, Level level, Rotate rotate, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify adjective \"Syntax\" service failed!");

                byte[] syntax = null;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);
                byte[] morphology_order = this._wordEmbeddingService.Encode(order, this._order);

                byte[]? adjective = null;
                byte[]? adverb = null;
                byte[]? adverb_adverb = null;

                byte[]? adverbial_adjective = null;

                if (level == Level.Default)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adjective)
                            && (item.order == morphology_order)) adjective = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adverb)
                            && (item.order == morphology_order)) adverb = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adverb_adverb)
                            && (item.order == morphology_order)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adjective))
                            && (item.order.Equals(morphology_order))) adjective = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adverb))
                            && (item.order.Equals(morphology_order))) adverb = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adverb_adverb))
                            && (item.order.Equals(morphology_order))) adverb_adverb = item.term;
                    }
                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) adjective = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) adverb = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))
                            && (item.order.AsSpan().SequenceEqual(morphology_order))) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adjective))
                            && (item.kind.SequenceEqual(morphology_adjective))
                            && (item.order.SequenceEqual(morphology_order))) adjective = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adjective))
                            && (item.kind.SequenceEqual(morphology_adverb))
                            && (item.order.SequenceEqual(morphology_order))) adverb = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adjective))
                            && (item.kind.SequenceEqual(morphology_adverb_adverb))
                            && (item.order.SequenceEqual(morphology_order))) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adjective) != -1)
                            && (item.kind.SequenceCompareTo(morphology_adjective) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) adjective = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adjective) != -1)
                            && (item.kind.SequenceCompareTo(morphology_adverb) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) adverb = item.term;
                        if ((item.sentence.SequenceCompareTo(syntax) != -1)
                            && (item.team.SequenceCompareTo(morphology_adjective) != -1)
                            && (item.kind.SequenceCompareTo(morphology_adverb_adverb) != -1)
                            && (item.order.SequenceCompareTo(morphology_order) != -1)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Instruction item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adjective) != -1)
                            && (item.kind.IndexOf(morphology_adjective) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) adjective = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adjective) != -1)
                            && (item.kind.IndexOf(morphology_adverb) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) adverb = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adjective) != -1)
                            && (item.kind.IndexOf(morphology_adverb_adverb) != -1)
                            && (item.order.IndexOf(morphology_order) != -1)) adverb_adverb = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (adjective != null)
                        adverbial_adjective = adjective;
                    if ((adjective != null) && (adverb != null))
                        adverbial_adjective = adverb;
                    if ((adjective != null) && (adverb != null) && (adverb_adverb != null))
                        adverbial_adjective = adverb_adverb;
                }
                if (rotate == Rotate.Rear)
                {
                    if (adjective != null)
                        adverbial_adjective = adjective;
                    if ((adjective != null) && (adverb != null))
                        adverbial_adjective = adjective;
                    if ((adjective != null) && (adverb != null) && (adverb_adverb != null))
                        adverbial_adjective = adjective;
                }

                return adverbial_adjective;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private string VerifyAdjective(List<Word> words, int order, Level level, Rotate rotate, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify adjective \"Syntax\" service failed!");

                string syntax = string.Empty;
                if (seat == Seat.Subject)
                    syntax = this._subject;
                if (seat == Seat.Predicate)
                    syntax = this._predicate;

                string morphology_adverbial_adjective = this._adverbial_adjective;
                string morphology_adjective = this._adjective;
                string morphology_adverb = this._adverb;
                string morphology_adverb_adverb = this._adverb_adverb;
                int morphology_order = order;

                string adjective = string.Empty;
                string adverb = string.Empty;
                string adverb_adverb = string.Empty;

                string adverbial_adjective = string.Empty;

                if (level == Level.Default)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adjective)
                            && (item.order == morphology_order)) adjective = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adverb)
                            && (item.order == morphology_order)) adverb = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adverb_adverb)
                            && (item.order == morphology_order)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adjective))
                            && (item.order.Equals(morphology_order))) adjective = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adverb))
                            && (item.order.Equals(morphology_order))) adverb = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adverb_adverb))
                            && (item.order.Equals(morphology_order))) adverb_adverb = item.term;
                    }

                }
                if (level == Level.AsSpanSequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.order == morphology_order)) adjective = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb))
                            && (item.order == morphology_order)) adverb = item.term;
                        if ((item.sentence.AsSpan().SequenceEqual(syntax))
                            && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                            && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))
                            && (item.order == morphology_order)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Sequence)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adjective))
                            && (item.kind.SequenceEqual(morphology_adjective))
                            && (item.order == morphology_order)) adjective = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adjective))
                            && (item.kind.SequenceEqual(morphology_adverb))
                            && (item.order == morphology_order)) adverb = item.term;
                        if ((item.sentence.SequenceEqual(syntax))
                            && (item.team.SequenceEqual(morphology_adjective))
                            && (item.kind.SequenceEqual(morphology_adverb_adverb))
                            && (item.order == morphology_order)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Compare)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adjective) != -1)
                            && (item.kind.CompareTo(morphology_adjective) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) adjective = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adjective) != -1)
                            && (item.kind.CompareTo(morphology_adverb) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) adverb = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adjective) != -1)
                            && (item.kind.CompareTo(morphology_adverb_adverb) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Index)
                {
                    foreach (Word item in words)
                    {
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adjective) != -1)
                            && (item.kind.IndexOf(morphology_adjective) != -1)
                            && (item.order == morphology_order)) adjective = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adjective) != -1)
                            && (item.kind.IndexOf(morphology_adverb) != -1)
                            && (item.order == morphology_order)) adverb = item.term;
                        if ((item.sentence.IndexOf(syntax) != -1)
                            && (item.team.IndexOf(morphology_adjective) != -1)
                            && (item.kind.IndexOf(morphology_adverb_adverb) != -1)
                            && (item.order == morphology_order)) adverb_adverb = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (adjective != string.Empty)
                        adverbial_adjective = adjective;
                    if ((adjective != string.Empty) && (adverb != string.Empty))
                        adverbial_adjective = adverb;
                    if ((adjective != string.Empty) && (adverb != string.Empty) && (adverb_adverb != string.Empty))
                        adverbial_adjective = adverb_adverb;
                }
                if (rotate == Rotate.Rear)
                {
                    if (adjective != string.Empty)
                        adverbial_adjective = adjective;
                    if ((adjective != string.Empty) && (adverb != string.Empty))
                        adverbial_adjective = adjective;
                    if ((adjective != string.Empty) && (adverb != string.Empty) && (adverb_adverb != string.Empty))
                        adverbial_adjective = adjective;
                }

                return adverbial_adjective;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private int VerifyAdjective(List<Guidance> words, int order, Level level, Rotate rotate, Seat seat)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify adjective \"Syntax\" service failed!");

                int syntax = -1;
                if (seat == Seat.Subject)
                    syntax = this._wordEmbeddingService.EncodeInt(this._subject, this._syntax);
                if (seat == Seat.Predicate)
                    syntax = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);

                int morphology_adverbial_adjective = this._wordEmbeddingService.EncodeInt(this._adverbial_adjective, this._morphology);
                int morphology_adjective = this._wordEmbeddingService.EncodeInt(this._adjective, this._morphology);
                int morphology_adverb = this._wordEmbeddingService.EncodeInt(this._adverb, this._morphology);
                int morphology_adverb_adverb = this._wordEmbeddingService.EncodeInt(this._adverb_adverb, this._morphology);
                int morphology_order = this._wordEmbeddingService.EncodeInt(order, this._order);

                int adjective = -1;
                int adverb = -1;
                int adverb_adverb = -1;

                int adverbial_adjective = -1;

                if (level == Level.Default)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adjective)
                            && (item.order == morphology_order)) adjective = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adverb)
                            && (item.order == morphology_order)) adverb = item.term;
                        if ((item.sentence == syntax)
                            && (item.team == morphology_adjective)
                            && (item.kind == morphology_adverb_adverb)
                            && (item.order == morphology_order)) adverb_adverb = item.term;
                    }
                }
                if (level == Level.Equal)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adjective))
                            && (item.order.Equals(morphology_order))) adjective = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adverb))
                            && (item.order.Equals(morphology_order))) adverb = item.term;
                        if ((item.sentence.Equals(syntax))
                            && (item.team.Equals(morphology_adjective))
                            && (item.kind.Equals(morphology_adverb_adverb))
                            && (item.order.Equals(morphology_order))) adverb_adverb = item.term;
                    }

                }
                if (level == Level.Compare)
                {
                    foreach (Guidance item in words)
                    {
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adjective) != -1)
                            && (item.kind.CompareTo(morphology_adjective) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) adjective = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adjective) != -1)
                            && (item.kind.CompareTo(morphology_adverb) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) adverb = item.term;
                        if ((item.sentence.CompareTo(syntax) != -1)
                            && (item.team.CompareTo(morphology_adjective) != -1)
                            && (item.kind.CompareTo(morphology_adverb_adverb) != -1)
                            && (item.order.CompareTo(morphology_order) != -1)) adverb_adverb = item.term;
                    }
                }

                if (rotate == Rotate.Front)
                {
                    if (adjective != -1)
                        adverbial_adjective = adjective;
                    if ((adjective != -1) && (adverb != -1))
                        adverbial_adjective = adverb;
                    if ((adjective != -1) && (adverb != -1) && (adverb_adverb != -1))
                        adverbial_adjective = adverb_adverb;
                }
                if (rotate == Rotate.Rear)
                {
                    if (adjective != -1)
                        adverbial_adjective = adjective;
                    if ((adjective != -1) && (adverb != -1))
                        adverbial_adjective = adjective;
                    if ((adjective != -1) && (adverb != -1) && (adverb_adverb != -1))
                        adverbial_adjective = adjective;
                }

                return adverbial_adjective;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbNounConjunctionNoun(List<Instruction> words, List<Instruction> firsts, List<Instruction> lasts, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, int order_verb, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb noun compound noun \"Syntax\" service failed!");

                byte[]? conjunction = null;
                byte[]? adnominal = null;
                byte[]? adnominal_rear = null;
                byte[]? adnominal_second = null;
                byte[]? numeral = null;
                byte[]? adverbial_verb = null;
                byte[]? adverbial_adjective = null;
                byte[]? adverbial_adjective_rear = null;
                byte[]? preposition = null;

                int order_last = this._order_3;

                preposition = VerifyPreposition(words, order_noun, level);
                conjunction = VerifyConjunction(words, order_noun, level, Seat.Predicate);
                adverbial_verb = VerifyVerb(words, order_verb, level, Rotate.Front);
                adnominal = VerifyNoun(firsts, order_noun, level, Rotate.Front, Seat.Predicate);
                adnominal_rear = VerifyNoun(firsts, order_noun, level, Rotate.Rear, Seat.Predicate);
                adnominal_second = VerifyNoun(lasts, order_noun, level, Rotate.Rear, Seat.Predicate, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal_second);
                if ((similarity) && (preposition == null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adnominal_rear);
                if ((similarity) && (preposition != null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_rear);
                if (similarity) return true;

                adverbial_adjective = VerifyAdjective(firsts, order_noun, level, Rotate.Front, Seat.Predicate);
                if (adverbial_adjective != null)
                {
                    adverbial_adjective_rear = VerifyAdjective(firsts, order_noun, level, Rotate.Rear, Seat.Predicate);
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_adjective, conjunction);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal);
                    if ((similarity) && (preposition == null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adverbial_adjective_rear);
                    if ((similarity) && (preposition != null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adverbial_adjective_rear);
                    if (similarity) return true;
                }

                numeral = VerifyNumeral(firsts, order_noun, level, Seat.Predicate);
                if (numeral != null)
                {
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, numeral);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, numeral, conjunction);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal_second);
                    if (similarity) return true;
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbNounConjunctionNoun(List<Word> words, List<Word> firsts, List<Word> lasts, Dictionary<(string, string), int> word_2_vec, Level level, int order_verb, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb noun compound noun \"Syntax\" service failed!");

                string conjunction = string.Empty;
                string adnominal = string.Empty;
                string adnominal_rear = string.Empty;
                string adnominal_second = string.Empty;
                string numeral = string.Empty;
                string adverbial_verb = string.Empty;
                string adverbial_adjective = string.Empty;
                string adverbial_adjective_rear = string.Empty;
                string preposition = string.Empty;

                int order_last = this._order_3;

                preposition = VerifyPreposition(words, order_noun, level);
                conjunction = VerifyConjunction(words, order_noun, level, Seat.Predicate);
                adverbial_verb = VerifyVerb(words, order_verb, level, Rotate.Front);
                adnominal = VerifyNoun(firsts, order_noun, level, Rotate.Front, Seat.Predicate);
                adnominal_rear = VerifyNoun(firsts, order_noun, level, Rotate.Rear, Seat.Predicate);
                adnominal_second = VerifyNoun(lasts, order_noun, level, Rotate.Rear, Seat.Predicate, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal_second);
                if ((similarity) && (preposition == string.Empty)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adnominal_rear);
                if ((similarity) && (preposition != string.Empty)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_rear);
                if (similarity) return true;

                adverbial_adjective = VerifyAdjective(firsts, order_noun, level, Rotate.Front, Seat.Predicate);
                if (adverbial_adjective != string.Empty)
                {
                    adverbial_adjective_rear = VerifyAdjective(firsts, order_noun, level, Rotate.Rear, Seat.Predicate);
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_adjective, conjunction);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal);
                    if ((similarity) && (preposition == string.Empty)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adverbial_adjective_rear);
                    if ((similarity) && (preposition != string.Empty)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adverbial_adjective_rear);
                    if (similarity) return true;
                }

                numeral = VerifyNumeral(firsts, order_noun, level, Seat.Predicate);
                if (numeral != string.Empty)
                {
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, numeral);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, numeral, conjunction);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal_second);
                    if (similarity) return true;
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbNounConjunctionNoun(List<Guidance> words, List<Guidance> firsts, List<Guidance> lasts, Dictionary<(int, int), int> word_2_vec, Level level, int order_verb, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb noun compound noun \"Syntax\" service failed!");

                int conjunction = -1;
                int adnominal = -1;
                int adnominal_rear = -1;
                int adnominal_second = -1;
                int numeral = -1;
                int adverbial_verb = -1;
                int adverbial_adjective = -1;
                int adverbial_adjective_rear = -1;
                int preposition = -1;

                int order_last = this._order_3;

                preposition = VerifyPreposition(words, order_noun, level);
                conjunction = VerifyConjunction(words, order_noun, level, Seat.Predicate);
                adverbial_verb = VerifyVerb(words, order_verb, level, Rotate.Front);
                adnominal = VerifyNoun(firsts, order_noun, level, Rotate.Front, Seat.Predicate);
                adnominal_rear = VerifyNoun(firsts, order_noun, level, Rotate.Rear, Seat.Predicate);
                adnominal_second = VerifyNoun(lasts, order_noun, level, Rotate.Rear, Seat.Predicate, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal_second);
                if ((similarity) && (preposition == -1)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adnominal_rear);
                if ((similarity) && (preposition != -1)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_rear);
                if (similarity) return true;

                adverbial_adjective = VerifyAdjective(firsts, order_noun, level, Rotate.Front, Seat.Predicate);
                if (adverbial_adjective != -1)
                {
                    adverbial_adjective_rear = VerifyAdjective(firsts, order_noun, level, Rotate.Rear, Seat.Predicate);
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_adjective, conjunction);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal);
                    if ((similarity) && (preposition == -1)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adverbial_adjective_rear);
                    if ((similarity) && (preposition != -1)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adverbial_adjective_rear);
                    if (similarity) return true;
                }

                numeral = VerifyNumeral(firsts, order_noun, level, Seat.Predicate);
                if (numeral != -1)
                {
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, numeral);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, numeral, conjunction);
                    if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal_second);
                    if (similarity) return true;
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private Word Lecture(string term, string kind, string sentence, string team, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation lecture \"Syntax\" service failed!");

                Word word = new Word();
                word.term = term;
                word.kind = kind;
                word.sentence = sentence;
                word.team = team;
                word.order = order;
                word.sequence = this._order_1;
                return word;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private Word Lecture(string term, string kind, string sentence, string team, int order, int sequence)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation lecture \"Syntax\" service failed!");

                Word word = new Word();
                word.term = term;
                word.kind = kind;
                word.sentence = sentence;
                word.team = team;
                word.order = order;
                word.sequence = sequence;
                return word;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private Instruction Lecture(byte[] term, byte[] kind, byte[] sentence, byte[] team, byte[] order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation lecture \"Syntax\" view model failed!");

                Instruction word = new Instruction();
                word.term = term;
                word.kind = kind;
                word.sentence = sentence;
                word.team = team;
                word.order = order;
                word.sequence = this._tutorial_sequence_1;
                return word;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private Instruction Lecture(byte[] term, byte[] kind, byte[] sentence, byte[] team, byte[] order, byte[] sequence)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation lecture \"Syntax\" view model failed!");

                Instruction word = new Instruction();
                word.term = term;
                word.kind = kind;
                word.sentence = sentence;
                word.team = team;
                word.order = order;
                word.sequence = sequence;
                return word;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private Guidance Lecture(int term, int kind, int sentence, int team, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation lecture \"Syntax\" view model failed!");

                Guidance word = new Guidance();
                word.term = term;
                word.kind = kind;
                word.sentence = sentence;
                word.team = team;
                word.order = order;
                word.sequence = this._practice_sequence_1;
                return word;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private Guidance Lecture(int term, int kind, int sentence, int team, int order, int sequence)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation lecture \"Syntax\" view model failed!");

                Guidance word = new Guidance();
                word.term = term;
                word.kind = kind;
                word.sentence = sentence;
                word.team = team;
                word.order = order;
                word.sequence = sequence;
                return word;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> DecodeLesson(List<Tutorial> tutorials, HashSet<string> vocabulary)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation decode lesson \"Word Embedding\" service failed!");

                List<Lesson> lessons = new List<Lesson>();

                List<byte[]> glossaries = this._wordEmbeddingService.VocabularySHA256(vocabulary);
                List<byte[]> morphologies = this._wordEmbeddingService.VocabularySHA256(this._morphology);
                List<byte[]> syntaxes = this._wordEmbeddingService.VocabularySHA256(this._syntax);
                List<byte[]> orders = this._wordEmbeddingService.VocabularySHA256(this._order);

                foreach (Tutorial tutorial in tutorials)
                {
                    Lesson lesson = new Lesson();
                    List<Word> words = new List<Word>();
                    foreach (Instruction instruction in tutorial.lecture)
                    {
                        byte[] term = instruction.term;
                        int index_term = glossaries.FindIndex(index => index.SequenceEqual(term));

                        byte[] kind = instruction.kind;
                        int index_kind = morphologies.FindIndex(index => index.SequenceEqual(kind));

                        byte[] sentence = instruction.sentence;
                        int index_sentence = syntaxes.FindIndex(index => index.SequenceEqual(sentence));

                        byte[] team = instruction.team;
                        int index_team = morphologies.FindIndex(index => index.SequenceEqual(team));

                        byte[] order = instruction.order;
                        int index_order = orders.FindIndex(index => index.SequenceEqual(order));

                        byte[] sequence = instruction.sequence;
                        int index_sequence = orders.FindIndex(index => index.SequenceEqual(sequence));

                        Word word = new Word();
                        word.term = vocabulary.ElementAt(index_term);
                        word.kind = this._morphology.ElementAt(index_kind);
                        word.sentence = this._syntax.ElementAt(index_sentence);
                        word.team = this._morphology.ElementAt(index_team);
                        word.order = this._order.ElementAt(index_order);
                        word.sequence = this._order.ElementAt(index_sequence);                                                
                        words.Add(word);
                    }
                    lesson.lecture = words;
                    lessons.Add(lesson);
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> DecodeLesson(List<Practice> practices, HashSet<string> vocabulary)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation decode lesson \"Word Embedding\" service failed!");

                List<Lesson> lessons = new List<Lesson>();

                List<int> glossaries = this._wordEmbeddingService.VocabularyInt(vocabulary);
                List<int> morphologies = this._wordEmbeddingService.VocabularyInt(this._morphology);
                List<int> syntaxes = this._wordEmbeddingService.VocabularyInt(this._syntax);
                List<int> orders = this._wordEmbeddingService.VocabularyInt(this._order);

                foreach (Practice practice in practices)
                {
                    Lesson lesson = new Lesson();
                    List<Word> words = new List<Word>();
                    foreach (Guidance guidance in practice.lecture)
                    {
                        int term = guidance.term;
                        int index_term = glossaries.FindIndex(index => index.Equals(term));

                        int kind = guidance.kind;
                        int index_kind = morphologies.FindIndex(index => index.Equals(kind));

                        int sentence = guidance.sentence;
                        int index_sentence = syntaxes.FindIndex(index => index.Equals(sentence));

                        int team = guidance.team;
                        int index_team = morphologies.FindIndex(index => index.Equals(team));

                        int order = guidance.order;
                        int index_order = orders.FindIndex(index => index.Equals(order));

                        int sequence = guidance.sequence;
                        int index_sequence = orders.FindIndex(index => index.Equals(sequence));

                        Word word = new Word();
                        word.term = vocabulary.ElementAt(index_term);
                        word.kind = this._morphology.ElementAt(index_kind);
                        word.sentence = this._syntax.ElementAt(index_sentence);
                        word.team = this._morphology.ElementAt(index_team);
                        word.order = this._order.ElementAt(index_order);
                        word.sequence = this._order.ElementAt(index_sequence);
                        words.Add(word);
                    }
                    lesson.lecture = words;
                    lessons.Add(lesson);
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> EncodeLesson(List<Lesson> lessons, HashSet<string> vocabulary)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation encode lesson \"Word Embedding\" service failed!");

                List<Tutorial> tutorials = new List<Tutorial>();
                foreach (Lesson lesson in lessons)
                {
                    Tutorial tutorial = new Tutorial();
                    tutorial.team = this._wordEmbeddingService.Encode(lesson.team, this._morphology);
                    List<Instruction> instructions = new List<Instruction>();
                    foreach (Word word in lesson.lecture)
                    {
                        Instruction instruction = new Instruction();
                        int term = Array.IndexOf(vocabulary.ToArray(), word.term);
                        instruction.term = this._wordEmbeddingService.HashSHA256(term);
                        instruction.kind = this._wordEmbeddingService.Encode(word.kind, this._morphology);
                        instructions.Add(instruction);
                    }
                    ;
                    tutorial.lecture = instructions;
                    tutorials.Add(tutorial);
                }
                ;
                return tutorials;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Practice> EncodeLessonInt(List<Lesson> lessons, HashSet<string> vocabulary)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation encode lesson int \"Word Embedding\" service failed!");

                List<Practice> practices = new List<Practice>();
                foreach (Lesson lesson in lessons)
                {
                    Practice practice = new Practice();
                    practice.team = this._wordEmbeddingService.EncodeInt(lesson.team, this._morphology);
                    List<Guidance> guidances = new List<Guidance>();
                    foreach (Word word in lesson.lecture)
                    {
                        Guidance guidance = new Guidance();
                        int term = Array.IndexOf(vocabulary.ToArray(), word.term);
                        guidance.term = term;
                        guidance.kind = this._wordEmbeddingService.EncodeInt(word.kind, this._morphology);
                        guidances.Add(guidance);
                    }
                    ;
                    practice.lecture = guidances;
                    practices.Add(practice);
                }
                ;
                return practices;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountNounVerb<TKey, TValue>(List<Tutorial> adverbials_verbs, List<Tutorial> adnominals_adjuncts, Dictionary<TKey, TValue> dictionaries) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount noun verb \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                byte[] subject = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_noun = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_verb = this._wordEmbeddingService.Encode(this._order_2, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                foreach (Tutorial adverbial_verb in adverbials_verbs)
                {
                    foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                    {
                        List<Instruction> words = new List<Instruction>();
                        foreach (Instruction item in adverbial_verb.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                            words.Add(word);
                        }
                        ;
                        foreach (Instruction item in adnominal_adjunct.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun);
                            words.Add(word);
                        }
                        ;
                        if (!VerifyVerbSampleSubject(words, word_2_vec, Level.AsSpanSequence, this._order_1, this._order_2)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountNounVerb<TKey, TValue>(List<Practice> adverbials_verbs, List<Practice> adnominals_adjuncts, Dictionary<TKey, TValue> dictionaries) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount noun verb \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                int subject = this._wordEmbeddingService.EncodeInt(this._subject, this._syntax);
                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_noun = this._wordEmbeddingService.EncodeInt(this._order_1, this._order);
                int order_verb = this._wordEmbeddingService.EncodeInt(this._order_2, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                foreach (Practice adverbial_verb in adverbials_verbs)
                {
                    foreach (Practice adnominal_adjunct in adnominals_adjuncts)
                    {
                        List<Guidance> words = new List<Guidance>();
                        foreach (Guidance item in adverbial_verb.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                            words.Add(word);
                        }
                        ;
                        foreach (Guidance item in adnominal_adjunct.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun);
                            words.Add(word);
                        }
                        if (!VerifyVerbSampleSubject(words, word_2_vec, Level.Default, this._order_1, this._order_2)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountNounVerb<TKey, TValue>(List<Lesson> adverbials_verbs, List<Lesson> adnominals_adjuncts, Dictionary<TKey, TValue> dictionaries) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount noun verb \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                string subject = this._subject;
                string predicate = this._predicate;
                int order_noun = this._order_1;
                int order_verb = this._order_2;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                foreach (Lesson adverbial_verb in adverbials_verbs)
                {
                    foreach (Lesson adnominal_adjunct in adnominals_adjuncts)
                    {
                        List<Word> words = new List<Word>();
                        foreach (Word item in adverbial_verb.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                            words.Add(word);
                        }
                        foreach (Word item in adnominal_adjunct.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun);
                            words.Add(word);
                        }
                        if (!VerifyVerbSampleSubject(words, word_2_vec, Level.Index, this._order_1, this._order_2)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountNounVerb<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount noun verb \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_verbs = new List<Tutorial>();
                List<Lesson> lesson_verbs = new List<Lesson>();
                List<Practice> practice_verbs = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_verb = new List<byte[]>();
                    byte[] sha_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                    kind_verb.Add(sha_verb);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_verbs = FilterLesson(tutorials, kind_verb);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_verb = new List<string>();
                    kind_verb.Add(this._adverbial_verb);
                    lessons = homeworks as List<Lesson>;
                    lesson_verbs = FilterLesson(lessons, kind_verb);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_verb = new List<int>();
                    int index = this._wordEmbeddingService.EncodeInt(this._adverbial_verb, this._morphology);
                    kind_verb.Add(index);
                    practices = homeworks as List<Practice>;
                    practice_verbs = FilterLesson(practices, kind_verb);
                }

                List<Tutorial> tutorial_adnominals = new List<Tutorial>();
                List<Lesson> lesson_adnominals = new List<Lesson>();
                List<Practice> practice_adnominals = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adnominal = new List<byte[]>();
                    byte[] sha_adnominal = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(sha_adnominal);
                    byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                    kind_adnominal.Add(sha_personal);
                    byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                    kind_adnominal.Add(sha_demonstrative);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_adnominals = FilterLesson(tutorials, kind_adnominal);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adnominal = new List<string>();
                    kind_adnominal.Add(this._adnominal_adjunct);
                    kind_adnominal.Add(this._personal);
                    kind_adnominal.Add(this._demonstrative);
                    lessons = homeworks as List<Lesson>;
                    lesson_adnominals = FilterLesson(lessons, kind_adnominal);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adnominal = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(index_adnominal);
                    int index_personal = this._wordEmbeddingService.EncodeInt(this._personal, this._morphology);
                    kind_adnominal.Add(index_personal);
                    int index_demostrative = this._wordEmbeddingService.EncodeInt(this._demonstrative, this._morphology);
                    kind_adnominal.Add(index_demostrative);
                    practices = homeworks as List<Practice>;
                    practice_adnominals = FilterLesson(practices, kind_adnominal);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountNounVerb(tutorial_verbs, tutorial_adnominals, dictionaries);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    seminars = MountNounVerb(lesson_verbs, lesson_adnominals, dictionaries);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountNounVerb(practice_verbs, practice_adnominals, dictionaries);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountCompoundVerb<TKey, TValue>(List<Tutorial> adverbials_verbs, List<Tutorial> adnominals_adjuncts, List<Tutorial> adnominals_second, List<Tutorial> conjunctions, Dictionary<TKey, TValue> dictionaries) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount compound verb \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                byte[] subject = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_noun = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_verb = this._wordEmbeddingService.Encode(this._order_2, this._order);

                byte[] order_first = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_middle = this._wordEmbeddingService.Encode(this._order_2, this._order);
                byte[] order_second = this._wordEmbeddingService.Encode(this._order_3, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                foreach (Tutorial conjunction in conjunctions)
                {
                    foreach (Tutorial adverbial_verb in adverbials_verbs)
                    {
                        foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                        {
                            foreach (Tutorial adnominal_second in adnominals_second)
                            {
                                List<Instruction> words = new List<Instruction>();
                                List<Instruction> firsts = new List<Instruction>();
                                List<Instruction> second = new List<Instruction>();
                                words.ForEach(item => words.Add(item));
                                foreach (Instruction item in adverbial_verb.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                                    words.Add(word);
                                }
                                foreach (Instruction item in adnominal_second.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, subject, adnominal_second.team, order_noun, order_second);
                                    words.Add(word);
                                    second.Add(word);
                                }
                                foreach (Instruction item in adnominal_adjunct.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun, order_first);
                                    words.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, subject, conjunction.team, order_noun, order_middle);
                                    words.Add(word);
                                }
                                if (!VerifyVerbCompoundSubject(words, firsts, second, word_2_vec, Level.AsSpanSequence, this._order_1, this._order_2)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountCompoundVerb<TKey, TValue>(List<Lesson> adverbials_verbs, List<Lesson> adnominals_adjuncts, List<Lesson> adnominals_second, List<Lesson> conjunctions, Dictionary<TKey, TValue> dictionaries) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount compound verb \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                string subject = this._subject;
                string predicate = this._predicate;
                int order_noun = this._order_1;
                int order_verb = this._order_2;

                int order_first = this._order_1;
                int order_middle = this._order_2;
                int order_second = this._order_3;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                foreach (Lesson conjunction in conjunctions)
                {
                    foreach (Lesson adverbial_verb in adverbials_verbs)
                    {
                        foreach (Lesson adnominal_adjunct in adnominals_adjuncts)
                        {
                            foreach (Lesson adnominal_second in adnominals_second)
                            {
                                List<Word> words = new List<Word>();
                                List<Word> firsts = new List<Word>();
                                List<Word> second = new List<Word>();
                                words.ForEach(item => words.Add(item));
                                foreach (Word item in adverbial_verb.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                                    words.Add(word);
                                }
                                foreach (Word item in adnominal_second.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, subject, adnominal_second.team, order_noun, order_second);
                                    words.Add(word);
                                    second.Add(word);
                                }
                                foreach (Word item in adnominal_adjunct.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun, order_first);
                                    words.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Word item in conjunction.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, subject, conjunction.team, order_noun, order_middle);
                                    words.Add(word);
                                }
                                if (!VerifyVerbCompoundSubject(words, firsts, second, word_2_vec, Level.Index, this._order_1, this._order_2)) continue;
                                Lesson seminar = new Lesson();
                                seminar.lecture = words;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountCompoundVerb<TKey, TValue>(List<Practice> adverbials_verbs, List<Practice> adnominals_adjuncts, List<Practice> adnominals_second, List<Practice> conjunctions, Dictionary<TKey, TValue> dictionaries) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount compound verb \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                int subject = this._wordEmbeddingService.EncodeInt(this._subject, this._syntax);
                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_noun = this._wordEmbeddingService.EncodeInt(this._order_1, this._order);
                int order_verb = this._wordEmbeddingService.EncodeInt(this._order_2, this._order);

                int order_first = this._wordEmbeddingService.EncodeInt(this._order_1, this._order);
                int order_middle = this._wordEmbeddingService.EncodeInt(this._order_2, this._order);
                int order_second = this._wordEmbeddingService.EncodeInt(this._order_3, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                foreach (Practice conjunction in conjunctions)
                {
                    foreach (Practice adverbial_verb in adverbials_verbs)
                    {
                        foreach (Practice adnominal_adjunct in adnominals_adjuncts)
                        {
                            foreach (Practice adnominal_second in adnominals_second)
                            {
                                List<Guidance> words = new List<Guidance>();
                                List<Guidance> firsts = new List<Guidance>();
                                List<Guidance> second = new List<Guidance>();
                                words.ForEach(item => words.Add(item));
                                foreach (Guidance item in adverbial_verb.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                                    words.Add(word);
                                }
                                foreach (Guidance item in adnominal_second.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, subject, adnominal_second.team, order_noun, order_second);
                                    words.Add(word);
                                    second.Add(word);
                                }
                                foreach (Guidance item in adnominal_adjunct.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun, order_first);
                                    words.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Guidance item in conjunction.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, subject, conjunction.team, order_noun, order_middle);
                                    words.Add(word);
                                }
                                if (!VerifyVerbCompoundSubject(words, firsts, second, word_2_vec, Level.Default, this._order_1, this._order_2)) continue;
                                Practice seminar = new Practice();
                                seminar.lecture = words;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountCompoundVerb<T, TKey, TValue>(List<T> homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount compound verb \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_verbs = new List<Tutorial>();
                List<Lesson> lesson_verbs = new List<Lesson>();
                List<Practice> practice_verbs = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_verb = new List<byte[]>();
                    byte[] sha_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                    kind_verb.Add(sha_verb);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_verbs = FilterLesson(tutorials, kind_verb);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_verb = new List<string>();
                    kind_verb.Add(this._adverbial_verb);
                    lessons = homeworks as List<Lesson>;
                    lesson_verbs = FilterLesson(lessons, kind_verb);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_verb = new List<int>();
                    int index = this._wordEmbeddingService.EncodeInt(this._adverbial_verb, this._morphology);
                    kind_verb.Add(index);
                    practices = homeworks as List<Practice>;
                    practice_verbs = FilterLesson(practices, kind_verb);
                }

                List<Tutorial> tutorial_adnominals = new List<Tutorial>();
                List<Tutorial> tutorial_adnominals_second = new List<Tutorial>();
                List<Lesson> lesson_adnominals = new List<Lesson>();
                List<Lesson> lesson_adnominals_second = new List<Lesson>();
                List<Practice> practice_adnominals = new List<Practice>();
                List<Practice> practice_adnominals_second = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adnominal = new List<byte[]>();
                    byte[] sha_adnominal = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(sha_adnominal);
                    byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                    kind_adnominal.Add(sha_personal);
                    byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                    kind_adnominal.Add(sha_demonstrative);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_adnominals = FilterLesson(tutorials, kind_adnominal);
                    tutorial_adnominals_second = FilterLesson(tutorials, kind_adnominal);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adnominal = new List<string>();
                    kind_adnominal.Add(this._adnominal_adjunct);
                    kind_adnominal.Add(this._personal);
                    kind_adnominal.Add(this._demonstrative);
                    lessons = homeworks as List<Lesson>;
                    lesson_adnominals = FilterLesson(lessons, kind_adnominal);
                    lesson_adnominals_second = FilterLesson(lessons, kind_adnominal);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adnominal = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(index_adnominal);
                    int index_personal = this._wordEmbeddingService.EncodeInt(this._personal, this._morphology);
                    kind_adnominal.Add(index_personal);
                    int index_demostrative = this._wordEmbeddingService.EncodeInt(this._demonstrative, this._morphology);
                    kind_adnominal.Add(index_demostrative);
                    practices = homeworks as List<Practice>;
                    practice_adnominals = FilterLesson(practices, kind_adnominal);
                    practice_adnominals_second = FilterLesson(practices, kind_adnominal);
                }

                List<Tutorial> tutorial_conjunctions = new List<Tutorial>();
                List<Lesson> lesson_conjunctions = new List<Lesson>();
                List<Practice> practice_conjunctions = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_conjunction = new List<byte[]>();
                    byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                    kind_conjunction.Add(sha_conjunction);
                    tutorial_conjunctions = FilterLesson(tutorials, kind_conjunction);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_conjunction = new List<string>();
                    kind_conjunction.Add(this._conjunction);
                    lesson_conjunctions = FilterLesson(lessons, kind_conjunction);
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    List<int> kind_conjunction = new List<int>();
                    int index_conjunction = this._wordEmbeddingService.EncodeInt(this._conjunction, this._morphology);
                    kind_conjunction.Add(index_conjunction);
                    practice_conjunctions = FilterLesson(practices, kind_conjunction);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountCompoundVerb(tutorial_verbs, tutorial_adnominals, tutorial_adnominals_second, tutorial_conjunctions, dictionaries);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountCompoundVerb(lesson_verbs, lesson_adnominals, lesson_adnominals_second, lesson_conjunctions, dictionaries);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountCompoundVerb(practice_verbs, practice_adnominals, practice_adnominals_second, practice_conjunctions, dictionaries);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbNoun<TKey, TValue>(List<Tutorial> adnominals_adjunts, List<Tutorial>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_noun) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_predicate = this._wordEmbeddingService.Encode(order_noun, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in adnominal_adjunt.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_predicate);
                            words1.Add(word);
                        }
                        if (!VerifyVerbDirectObject(words1, word_2_vec, Level.AsSpanSequence, order_verb, order_noun)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbNoun<TKey, TValue>(List<Lesson> adnominals_adjunts, List<Lesson>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_noun) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                string predicate = this._predicate;
                int order_predicate = order_noun;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Word item in adnominal_adjunt.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_predicate);
                            words1.Add(word);
                        }
                        if (!VerifyVerbDirectObject(words1, word_2_vec, Level.Index, order_verb, order_noun)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountVerbNoun<TKey, TValue>(List<Practice> adnominals_adjunts, List<Practice>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_noun) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_predicate = this._wordEmbeddingService.EncodeInt(order_noun, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Guidance> words1 = new List<Guidance>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Guidance item in adnominal_adjunt.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_predicate);
                            words1.Add(word);
                        }
                        if (!VerifyVerbDirectObject(words1, word_2_vec, Level.Default, order_verb, order_noun)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountVerbNoun<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_verb, int order_noun) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_adnominals = new List<Tutorial>();
                List<Lesson> lesson_adnominals = new List<Lesson>();
                List<Practice> practice_adnominals = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adnominal = new List<byte[]>();
                    byte[] sha_adnominal = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(sha_adnominal);
                    byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                    kind_adnominal.Add(sha_personal);
                    byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                    kind_adnominal.Add(sha_demonstrative);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_adnominals = FilterLesson(tutorials, kind_adnominal);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adnominal = new List<string>();
                    kind_adnominal.Add(this._adnominal_adjunct);
                    kind_adnominal.Add(this._personal);
                    kind_adnominal.Add(this._demonstrative);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_adnominals = FilterLesson(lessons, kind_adnominal);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adnominal = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(index_adnominal);
                    int index_personal = this._wordEmbeddingService.EncodeInt(this._personal, this._morphology);
                    kind_adnominal.Add(index_personal);
                    int index_demostrative = this._wordEmbeddingService.EncodeInt(this._demonstrative, this._morphology);
                    kind_adnominal.Add(index_demostrative);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_adnominals = FilterLesson(practices, kind_adnominal);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountVerbNoun(tutorial_adnominals, tutorial_sources, dictionaries, order_verb, order_noun);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountVerbNoun(lesson_adnominals, lesson_sources, dictionaries, order_verb, order_noun);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountVerbNoun(practice_adnominals, practice_sources, dictionaries, order_verb, order_noun);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbNounConjunctionNoun<TKey, TValue>(List<Tutorial> adnominals_adjuncts, List<Tutorial> adnominals_second, List<Tutorial> conjunctions, Dictionary<TKey, TValue> dictionaries, List<Tutorial>? sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order_predicate, this._order);

                byte[] order_first = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_middle = this._wordEmbeddingService.Encode(this._order_2, this._order);
                byte[] order_second = this._wordEmbeddingService.Encode(this._order_3, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adnominal_first in adnominals_adjuncts)
                        {
                            foreach (Tutorial adnominal_last in adnominals_second)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                List<Instruction> firsts = new List<Instruction>();
                                List<Instruction> lasts = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_first.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound, order_first);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Instruction item in adnominal_last.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound, order_second);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound, order_middle);
                                    words1.Add(word);
                                }
                                if (!VerifyVerbNounConjunctionNoun(words1, firsts, lasts, word_2_vec, Level.AsSpanSequence, order_verb, order_predicate)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbNounConjunctionNoun<TKey, TValue>(List<Lesson> adnominals_adjuncts, List<Lesson> adnominals_second, List<Lesson> conjunctions, Dictionary<TKey, TValue> dictionaries, List<Lesson>? sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                string predicate = this._predicate;
                int order_compound = order_predicate;

                int order_first = this._order_1;
                int order_middle = this._order_2;
                int order_second = this._order_3;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson conjunction in conjunctions)
                    {
                        foreach (Lesson adnominal_first in adnominals_adjuncts)
                        {
                            foreach (Lesson adnominal_last in adnominals_second)
                            {
                                List<Word> words1 = new List<Word>();
                                List<Word> firsts = new List<Word>();
                                List<Word> lasts = new List<Word>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Word item in adnominal_first.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound, order_first);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Word item in adnominal_last.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound, order_second);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Word item in conjunction.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound, order_middle);
                                    words1.Add(word);
                                }
                                if (!VerifyVerbNounConjunctionNoun(words1, firsts, lasts, word_2_vec, Level.Index, order_verb, order_predicate)) continue;
                                Lesson seminar = new Lesson();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountVerbNounConjunctionNoun<TKey, TValue>(List<Practice> adnominals_adjuncts, List<Practice> adnominals_second, List<Practice> conjunctions, Dictionary<TKey, TValue> dictionaries, List<Practice>? sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_compound = this._wordEmbeddingService.EncodeInt(order_predicate, this._order);

                int order_first = this._wordEmbeddingService.EncodeInt(this._order_1, this._order);
                int order_middle = this._wordEmbeddingService.EncodeInt(this._order_2, this._order);
                int order_second = this._wordEmbeddingService.EncodeInt(this._order_3, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice conjunction in conjunctions)
                    {
                        foreach (Practice adnominal_first in adnominals_adjuncts)
                        {
                            foreach (Practice adnominal_last in adnominals_second)
                            {
                                List<Guidance> words1 = new List<Guidance>();
                                List<Guidance> firsts = new List<Guidance>();
                                List<Guidance> lasts = new List<Guidance>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Guidance item in adnominal_first.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound, order_first);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Guidance item in adnominal_last.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound, order_second);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Guidance item in conjunction.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound, order_middle);
                                    words1.Add(word);
                                }
                                if (!VerifyVerbNounConjunctionNoun(words1, firsts, lasts, word_2_vec, Level.Default, order_verb, order_predicate)) continue;
                                Practice seminar = new Practice();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbNounConjunctionNoun<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                List<Tutorial> tutorial_adnominals = new List<Tutorial>();
                List<Tutorial> tutorial_adnominals_second = new List<Tutorial>();
                List<Lesson> lesson_adnominals = new List<Lesson>();
                List<Lesson> lesson_adnominals_second = new List<Lesson>();
                List<Practice> practice_adnominals = new List<Practice>();
                List<Practice> practice_adnominals_second = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adnominal = new List<byte[]>();
                    byte[] sha_adnominal = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(sha_adnominal);
                    byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                    kind_adnominal.Add(sha_personal);
                    byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                    kind_adnominal.Add(sha_demonstrative);
                    byte[] sha_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                    kind_adnominal.Add(sha_numeral);
                    byte[] sha_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                    kind_adnominal.Add(sha_adverbial_adjective);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_adnominals = FilterLesson(tutorials, kind_adnominal);
                    tutorial_adnominals_second = FilterLesson(tutorials, kind_adnominal);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adnominal = new List<string>();
                    kind_adnominal.Add(this._adnominal_adjunct);
                    kind_adnominal.Add(this._personal);
                    kind_adnominal.Add(this._demonstrative);
                    kind_adnominal.Add(this._numeral);
                    kind_adnominal.Add(this._adverbial_adjective);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_adnominals = FilterLesson(lessons, kind_adnominal);
                    lesson_adnominals_second = FilterLesson(lessons, kind_adnominal);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adnominal = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(index_adnominal);
                    int index_personal = this._wordEmbeddingService.EncodeInt(this._personal, this._morphology);
                    kind_adnominal.Add(index_personal);
                    int index_demostrative = this._wordEmbeddingService.EncodeInt(this._demonstrative, this._morphology);
                    kind_adnominal.Add(index_demostrative);
                    int sha_numeral = this._wordEmbeddingService.EncodeInt(this._numeral, this._morphology);
                    kind_adnominal.Add(sha_numeral);
                    int sha_adverbial_adjective = this._wordEmbeddingService.EncodeInt(this._adverbial_adjective, this._morphology);
                    kind_adnominal.Add(sha_adverbial_adjective);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_adnominals = FilterLesson(practices, kind_adnominal);
                    practice_adnominals_second = FilterLesson(practices, kind_adnominal);
                }

                List<Tutorial> tutorial_conjunctions = new List<Tutorial>();
                List<Lesson> lesson_conjunctions = new List<Lesson>();
                List<Practice> practice_conjunctions = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_conjunction = new List<byte[]>();
                    byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                    kind_conjunction.Add(sha_conjunction);
                    tutorial_conjunctions = FilterLesson(tutorials, kind_conjunction);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_conjunction = new List<string>();
                    kind_conjunction.Add(this._conjunction);
                    lesson_conjunctions = FilterLesson(lessons, kind_conjunction);
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    List<int> kind_conjunction = new List<int>();
                    int index_conjunction = this._wordEmbeddingService.EncodeInt(this._conjunction, this._morphology);
                    kind_conjunction.Add(index_conjunction);
                    practice_conjunctions = FilterLesson(practices, kind_conjunction);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountVerbNounConjunctionNoun(tutorial_adnominals, tutorial_adnominals_second, tutorial_conjunctions, dictionaries, tutorial_sources, order_verb, order_predicate);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountVerbNounConjunctionNoun(lesson_adnominals, lesson_adnominals_second, lesson_conjunctions, dictionaries, lesson_sources, order_verb, order_predicate);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountVerbNounConjunctionNoun(practice_adnominals, practice_adnominals_second, practice_conjunctions, dictionaries, practice_sources, order_verb, order_predicate);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbPredicative(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, int order_verb, int order_adjective)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb predicative \"Syntax\" service failed!");

                byte[]? adverbial = null;
                byte[]? predicative = null;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                predicative = VerifyAdjective(words, order_adjective, level, Rotate.Rear, Seat.Predicate);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, predicative);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbPredicative(List<Word> words, Dictionary<(string, string), int> word_2_vec, Level level, int order_verb, int order_adjective)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb predicative \"Syntax\" service failed!");

                string adverbial = string.Empty;
                string predicative = string.Empty;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                predicative = VerifyAdjective(words, order_adjective, level, Rotate.Rear, Seat.Predicate);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, predicative);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbPredicative(List<Guidance> words, Dictionary<(int, int), int> word_2_vec, Level level, int order_verb, int order_adjective)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb predicative \"Syntax\" service failed!");

                int adverbial = -1;
                int predicative = -1;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                predicative = VerifyAdjective(words, order_adjective, level, Rotate.Rear, Seat.Predicate);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, predicative);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbPredicative<TKey, TValue>(List<Tutorial> adverbials_adjectives, List<Tutorial>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb predicative \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_predicative = this._wordEmbeddingService.Encode(order_predicate, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                if ((sources == null) || (adverbials_adjectives == null)) return seminars;
                if ((sources.Count == 0) || (adverbials_adjectives.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adverbial_adjective in adverbials_adjectives)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in adverbial_adjective.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_predicative);
                            words1.Add(word);
                        }
                        if (!VerifyVerbPredicative(words1, word_2_vec, Level.AsSpanSequence, order_verb, order_predicate)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbPredicative<TKey, TValue>(List<Lesson> adverbials_adjectives, List<Lesson>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb predicative \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();

                string predicate = this._predicate;
                int order_predicative = order_predicate;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                if ((sources == null) || (adverbials_adjectives == null)) return seminars;
                if ((sources.Count == 0) || (adverbials_adjectives.Count == 0)) return seminars;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adverbial_adjective in adverbials_adjectives)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Word item in adverbial_adjective.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_predicative);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyVerbPredicative(words1, word_2_vec, Level.Index, order_verb, order_predicate)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountVerbPredicative<TKey, TValue>(List<Practice> adverbials_adjectives, List<Practice>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb predicative \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();

                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_predicative = this._wordEmbeddingService.EncodeInt(order_predicate, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                if ((sources == null) || (adverbials_adjectives == null)) return seminars;
                if ((sources.Count == 0) || (adverbials_adjectives.Count == 0)) return seminars;
                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice adverbial_adjective in adverbials_adjectives)
                    {
                        List<Guidance> words1 = new List<Guidance>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Guidance item in adverbial_adjective.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_predicative);
                            words1.Add(word);
                        }
                        if (!VerifyVerbPredicative(words1, word_2_vec, Level.Default, order_verb, order_predicative)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountVerbPredicative<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb predicative \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_adverbials = new List<Tutorial>();
                List<Lesson> lesson_adverbials = new List<Lesson>();
                List<Practice> practice_adverbials = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adverbial = new List<byte[]>();
                    byte[] sha_adverbial = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                    kind_adverbial.Add(sha_adverbial);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_adverbials = FilterLesson(tutorials, kind_adverbial);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adverbial = new List<string>();
                    kind_adverbial.Add(this._adverbial_adjective);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_adverbials = FilterLesson(lessons, kind_adverbial);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adverbial = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adverbial_adjective, this._morphology);
                    kind_adverbial.Add(index_adnominal);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_adverbials = FilterLesson(practices, kind_adverbial);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountVerbPredicative(tutorial_adverbials, tutorial_sources, dictionaries, order_verb, order_predicate);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountVerbPredicative(lesson_adverbials, lesson_sources, dictionaries, order_verb, order_predicate);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountVerbPredicative(practice_adverbials, practice_sources, dictionaries, order_verb, order_predicate);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbIndirectObject(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, int order_verb, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                byte[]? adverbial = null;
                byte[]? preposition = null;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                preposition = VerifyPreposition(words, order_preposition, level);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbIndirectObject(List<Word> words, Dictionary<(string, string), int> word_2_vec, Level level, int order_verb, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                string adverbial = string.Empty;
                string preposition = string.Empty;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                preposition = VerifyPreposition(words, order_preposition, level);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbIndirectObject(List<Guidance> words, Dictionary<(int, int), int> word_2_vec, Level level, int order_verb, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                int adverbial = -1;
                int preposition = -1;

                adverbial = VerifyVerb(words, order_verb, level, Rotate.Front);
                preposition = VerifyPreposition(words, order_preposition, level);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbIndirectObject<TKey, TValue>(List<Tutorial> prepositions, List<Tutorial>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_indirect_object = this._wordEmbeddingService.Encode(order_predicate, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                if ((sources == null) || (prepositions == null)) return seminars;
                if ((sources.Count == 0) || (prepositions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial preposition in prepositions)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Instruction item in preposition.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_indirect_object);
                            words1.Add(word);
                        }
                        if (!VerifyVerbIndirectObject(words1, word_2_vec, Level.AsSpanSequence, order_verb, order_predicate)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbIndirectObject<TKey, TValue>(List<Lesson> prepositions, List<Lesson>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();

                string predicate = this._predicate;
                int order_indirect_object = order_predicate;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                if ((sources == null) || (prepositions == null)) return seminars;
                if ((sources.Count == 0) || (prepositions.Count == 0)) return seminars;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson preposition in prepositions)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Word item in preposition.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_indirect_object);
                            words1.Add(word);
                        }
                        if (!VerifyVerbIndirectObject(words1, word_2_vec, Level.Index, order_verb, order_predicate)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountVerbIndirectObject<TKey, TValue>(List<Practice> prepositions, List<Practice>? sources, Dictionary<TKey, TValue> dictionaries, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();

                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_indirect_object = this._wordEmbeddingService.EncodeInt(order_predicate, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                if ((sources == null) || (prepositions == null)) return seminars;
                if ((sources.Count == 0) || (prepositions.Count == 0)) return seminars;
                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice preposition in prepositions)
                    {
                        List<Guidance> words1 = new List<Guidance>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Guidance item in preposition.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_indirect_object);
                            words1.Add(word);
                        }
                        if (!VerifyVerbIndirectObject(words1, word_2_vec, Level.Default, order_verb, order_predicate)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountVerbIndirectObject<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_prepositions = new List<Tutorial>();
                List<Lesson> lesson_prepositions = new List<Lesson>();
                List<Practice> practice_prepositions = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_preposition = new List<byte[]>();
                    byte[] sha_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                    kind_preposition.Add(sha_preposition);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_prepositions = FilterLesson(tutorials, kind_preposition);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_preposition = new List<string>();
                    kind_preposition.Add(this._preposition);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_prepositions = FilterLesson(lessons, kind_preposition);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_preposition = new List<int>();
                    int index_preposition = this._wordEmbeddingService.EncodeInt(this._preposition, this._morphology);
                    kind_preposition.Add(index_preposition);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_prepositions = FilterLesson(practices, kind_preposition);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountVerbIndirectObject(tutorial_prepositions, tutorial_sources, dictionaries, order_verb, order_predicate);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountVerbIndirectObject(lesson_prepositions, lesson_sources, dictionaries, order_verb, order_predicate);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountVerbIndirectObject(practice_prepositions, practice_sources, dictionaries, order_verb, order_predicate);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPreposition(List<Instruction> words, Dictionary<(byte[], byte[]), int>? word_2_vec, Level level, int order, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                byte[]? preposition = null;
                byte[]? adnominal = null;

                preposition = VerifyPreposition(words, order_preposition, level);
                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPreposition(List<Word> words, Dictionary<(string, string), int>? word_2_vec, Level level, int order, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                string preposition = string.Empty;
                string adnominal = string.Empty;

                preposition = VerifyPreposition(words, order_preposition, level);
                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPreposition(List<Guidance> words, Dictionary<(int, int), int>? word_2_vec, Level level, int order, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                int preposition = -1;
                int adnominal = -1;

                preposition = VerifyPreposition(words, order_preposition, level);
                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountDirectObjectPreposition<TKey, TValue>(List<Tutorial> prepositions, List<Tutorial>? sources, Dictionary<TKey, TValue> dictionaries, int order_direct_object, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order = this._wordEmbeddingService.Encode(order_direct_object, this._order);
                byte[] order_preposition = this._wordEmbeddingService.Encode(order_indirect_object, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                if ((prepositions == null) || (sources == null)) return seminars;
                if ((prepositions.Count == 0) || (sources.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial preposition in prepositions)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in preposition.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        }
                        if (!VerifyDirectObjectPreposition(words1, word_2_vec, Level.AsSpanSequence, order_direct_object, order_indirect_object)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountDirectObjectPreposition<TKey, TValue>(List<Lesson> prepositions, List<Lesson>? sources, Dictionary<TKey, TValue> dictionaries, int order_direct_object, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();

                string predicate = this._predicate;
                int order = order_direct_object;
                int order_preposition = order_indirect_object;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                if ((prepositions == null) || (sources == null)) return seminars;
                if ((prepositions.Count == 0) || (sources.Count == 0)) return seminars;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson preposition in prepositions)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Word item in preposition.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        }
                        if (!VerifyDirectObjectPreposition(words1, word_2_vec, Level.AsSpanSequence, order_direct_object, order_indirect_object)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountDirectObjectPreposition<TKey, TValue>(List<Practice> prepositions, List<Practice>? sources, Dictionary<TKey, TValue> dictionaries, int order_direct_object, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();

                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order = this._wordEmbeddingService.EncodeInt(order_direct_object, this._order);
                int order_preposition = this._wordEmbeddingService.EncodeInt(order_indirect_object, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                if ((prepositions == null) || (sources == null)) return seminars;
                if ((prepositions.Count == 0) || (sources.Count == 0)) return seminars;
                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice preposition in prepositions)
                    {
                        List<Guidance> words1 = new List<Guidance>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Guidance item in preposition.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        }
                        if (!VerifyDirectObjectPreposition(words1, word_2_vec, Level.AsSpanSequence, order_direct_object, order_indirect_object)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountDirectObjectPreposition<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_direct_object, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_prepositions = new List<Tutorial>();
                List<Lesson> lesson_prepositions = new List<Lesson>();
                List<Practice> practice_prepositions = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_preposition = new List<byte[]>();
                    byte[] sha_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                    kind_preposition.Add(sha_preposition);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_prepositions = FilterLesson(tutorials, kind_preposition);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_preposition = new List<string>();
                    kind_preposition.Add(this._preposition);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_prepositions = FilterLesson(lessons, kind_preposition);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_preposition = new List<int>();
                    int index_preposition = this._wordEmbeddingService.EncodeInt(this._preposition, this._morphology);
                    kind_preposition.Add(index_preposition);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_prepositions = FilterLesson(practices, kind_preposition);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountDirectObjectPreposition(tutorial_prepositions, tutorial_sources, dictionaries, order_direct_object, order_indirect_object);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountDirectObjectPreposition(lesson_prepositions, lesson_sources, dictionaries, order_direct_object, order_indirect_object);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountDirectObjectPreposition(practice_prepositions, practice_sources, dictionaries, order_direct_object, order_indirect_object);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObject(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                byte[]? adnominal = null;
                byte[]? preposition = null;

                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate);
                preposition = VerifyPreposition(words, order, level);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObject(List<Word> words, Dictionary<(string, string), int> word_2_vec, Level level, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                string adnominal = string.Empty;
                string preposition = string.Empty;

                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate);
                preposition = VerifyPreposition(words, order, level);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObject(List<Guidance> words, Dictionary<(int, int), int> word_2_vec, Level level, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                int adnominal = -1;
                int preposition = -1;

                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate);
                preposition = VerifyPreposition(words, order, level);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountIndirectObjectSample<TKey, TValue>(List<Lesson> adnominals_adjunts, List<Lesson>? sources, Dictionary<TKey, TValue> dictionaries, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                string predicate = this._predicate;
                int order_predicate = order_indirect_object;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Word item in adnominal_adjunt.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_predicate);
                            words1.Add(word);
                        }
                        if (!VerifyIndirectObject(words1, word_2_vec, Level.Index, order_indirect_object)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountIndirectObjectSample<TKey, TValue>(List<Tutorial> adnominals_adjunts, List<Tutorial>? sources, Dictionary<TKey, TValue> dictionaries, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                byte[]? predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[]? order_predicate = this._wordEmbeddingService.Encode(order_indirect_object, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in adnominal_adjunt.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_predicate);
                            words1.Add(word);
                        }
                        if (!VerifyIndirectObject(words1, word_2_vec, Level.Index, order_indirect_object)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountIndirectObjectSample<TKey, TValue>(List<Practice> adnominals_adjunts, List<Practice>? sources, Dictionary<TKey, TValue> dictionaries, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_predicate = this._wordEmbeddingService.EncodeInt(order_indirect_object, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Guidance> words1 = new List<Guidance>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Guidance item in adnominal_adjunt.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_predicate);
                            words1.Add(word);
                        }
                        if (!VerifyIndirectObject(words1, word_2_vec, Level.Index, order_indirect_object)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountIndirectObjectSample<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount direct object indirect object \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_adnominals = new List<Tutorial>();
                List<Lesson> lesson_adnominals = new List<Lesson>();
                List<Practice> practice_adnominals = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adnominal = new List<byte[]>();
                    byte[] sha_adnominal = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(sha_adnominal);
                    byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                    kind_adnominal.Add(sha_personal);
                    byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                    kind_adnominal.Add(sha_demonstrative);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_adnominals = FilterLesson(tutorials, kind_adnominal);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adnominal = new List<string>();
                    kind_adnominal.Add(this._adnominal_adjunct);
                    kind_adnominal.Add(this._personal);
                    kind_adnominal.Add(this._demonstrative);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_adnominals = FilterLesson(lessons, kind_adnominal);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adnominal = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(index_adnominal);
                    int index_personal = this._wordEmbeddingService.EncodeInt(this._personal, this._morphology);
                    kind_adnominal.Add(index_personal);
                    int index_demostrative = this._wordEmbeddingService.EncodeInt(this._demonstrative, this._morphology);
                    kind_adnominal.Add(index_demostrative);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_adnominals = FilterLesson(practices, kind_adnominal);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountIndirectObjectSample(tutorial_adnominals, tutorial_sources, dictionaries, order_indirect_object);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountIndirectObjectSample(lesson_adnominals, lesson_sources, dictionaries, order_indirect_object);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountIndirectObjectSample(practice_adnominals, practice_sources, dictionaries, order_indirect_object);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObjectConjunction(List<Instruction> words, List<Instruction> firsts, List<Instruction> lasts, Dictionary<(byte[], byte[]), int> word_2_vec, Level level, Seat seat, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                byte[]? preposition = null;
                byte[]? conjunction = null;
                byte[]? adnominal_front = null;
                byte[]? adnominal_rear = null;
                byte[]? adnominal2 = null;

                int order_last = this._order_3;

                preposition = VerifyPreposition(words, order, level);
                conjunction = VerifyConjunction(words, order, level, seat);
                adnominal_front = VerifyNoun(firsts, order, level, Rotate.Front, seat);
                adnominal_rear = VerifyNoun(firsts, order, level, Rotate.Rear, seat);
                adnominal2 = VerifyNoun(lasts, order, level, Rotate.Rear, seat, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_rear);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal_front, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObjectConjunction(List<Word> words, List<Word> firsts, List<Word> lasts, Dictionary<(string, string), int> word_2_vec, Level level, Seat seat, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                string preposition = string.Empty;
                string conjunction = string.Empty;
                string adnominal_front = string.Empty;
                string adnominal_rear = string.Empty;
                string adnominal2 = string.Empty;

                int order_last = this._order_3;

                preposition = VerifyPreposition(words, order, level);
                conjunction = VerifyConjunction(words, order, level, seat);
                adnominal_front = VerifyNoun(firsts, order, level, Rotate.Front, seat);
                adnominal_rear = VerifyNoun(firsts, order, level, Rotate.Rear, seat);
                adnominal2 = VerifyNoun(lasts, order, level, Rotate.Rear, seat, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_rear);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal_front, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObjectConjunction(List<Guidance> words, List<Guidance> firsts, List<Guidance> lasts, Dictionary<(int, int), int> word_2_vec, Level level, Seat seat, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                int preposition = -1;
                int conjunction = -1;
                int adnominal_front = -1;
                int adnominal_rear = -1;
                int adnominal2 = -1;

                int order_last = this._order_3;

                preposition = VerifyPreposition(words, order, level);
                conjunction = VerifyConjunction(words, order, level, seat);
                adnominal_front = VerifyNoun(firsts, order, level, Rotate.Front, seat);
                adnominal_rear = VerifyNoun(firsts, order, level, Rotate.Rear, seat);
                adnominal2 = VerifyNoun(lasts, order, level, Rotate.Rear, seat, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_rear);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal_front, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountIndirectObjectConjunction<TKey, TValue>(List<Tutorial> adnominals_adjuncts, List<Tutorial> adnominals_second, List<Tutorial> conjunctions, Dictionary<TKey, TValue> dictionaries, List<Tutorial>? sources, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order_indirect_object, this._order);

                byte[] order_first = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_middle = this._wordEmbeddingService.Encode(this._order_2, this._order);
                byte[] order_second = this._wordEmbeddingService.Encode(this._order_3, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adnominal_first in adnominals_adjuncts)
                        {
                            foreach (Tutorial adnominal_last in adnominals_second)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                List<Instruction> firsts = new List<Instruction>();
                                List<Instruction> lasts = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_first.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound, order_first);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Instruction item in adnominal_last.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound, order_second);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound, order_middle);
                                    words1.Add(word);
                                }
                                if (!VerifyIndirectObjectConjunction(words1, firsts, lasts, word_2_vec, Level.AsSpanSequence, Seat.Predicate, order_indirect_object)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountIndirectObjectConjunction<TKey, TValue>(List<Lesson> adnominals_adjuncts, List<Lesson> adnominals_second, List<Lesson> conjunctions, Dictionary<TKey, TValue> dictionaries, List<Lesson>? sources, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                string predicate = this._predicate;
                int order_compound = order_indirect_object;

                int order_first = this._order_1;
                int order_middle = this._order_2;
                int order_second = this._order_3;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson conjunction in conjunctions)
                    {
                        foreach (Lesson adnominal_first in adnominals_adjuncts)
                        {
                            foreach (Lesson adnominal_last in adnominals_second)
                            {
                                List<Word> words1 = new List<Word>();
                                List<Word> firsts = new List<Word>();
                                List<Word> lasts = new List<Word>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Word item in adnominal_first.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound, order_first);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Word item in adnominal_last.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound, order_second);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Word item in conjunction.lecture)
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound, order_middle);
                                    words1.Add(word);
                                }
                                if (!VerifyIndirectObjectConjunction(words1, firsts, lasts, word_2_vec, Level.AsSpanSequence, Seat.Predicate, order_indirect_object)) continue;
                                Lesson seminar = new Lesson();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountIndirectObjectConjunction<TKey, TValue>(List<Practice> adnominals_adjuncts, List<Practice> adnominals_second, List<Practice> conjunctions, Dictionary<TKey, TValue> dictionaries, List<Practice>? sources, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();
                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order_compound = this._wordEmbeddingService.EncodeInt(order_indirect_object, this._order);

                int order_first = this._wordEmbeddingService.EncodeInt(this._order_1, this._order);
                int order_middle = this._wordEmbeddingService.EncodeInt(this._order_2, this._order);
                int order_second = this._wordEmbeddingService.EncodeInt(this._order_3, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice conjunction in conjunctions)
                    {
                        foreach (Practice adnominal_first in adnominals_adjuncts)
                        {
                            foreach (Practice adnominal_last in adnominals_second)
                            {
                                List<Guidance> words1 = new List<Guidance>();
                                List<Guidance> firsts = new List<Guidance>();
                                List<Guidance> lasts = new List<Guidance>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Guidance item in adnominal_first.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound, order_first);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Guidance item in adnominal_last.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound, order_second);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Guidance item in conjunction.lecture)
                                {
                                    Guidance word = new Guidance();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound, order_middle);
                                    words1.Add(word);
                                }
                                if (!VerifyIndirectObjectConjunction(words1, firsts, lasts, word_2_vec, Level.AsSpanSequence, Seat.Predicate, order_indirect_object)) continue;
                                Practice seminar = new Practice();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountIndirectObjectConjunction<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                List<Tutorial> tutorial_adnominals = new List<Tutorial>();
                List<Tutorial> tutorial_adnominals_second = new List<Tutorial>();
                List<Lesson> lesson_adnominals = new List<Lesson>();
                List<Lesson> lesson_adnominals_second = new List<Lesson>();
                List<Practice> practice_adnominals = new List<Practice>();
                List<Practice> practice_adnominals_second = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adnominal = new List<byte[]>();
                    byte[] sha_adnominal = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(sha_adnominal);
                    byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                    kind_adnominal.Add(sha_personal);
                    byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                    kind_adnominal.Add(sha_demonstrative);
                    byte[] sha_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                    kind_adnominal.Add(sha_numeral);
                    byte[] sha_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                    kind_adnominal.Add(sha_adverbial_adjective);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_adnominals = FilterLesson(tutorials, kind_adnominal);
                    tutorial_adnominals_second = FilterLesson(tutorials, kind_adnominal);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adnominal = new List<string>();
                    kind_adnominal.Add(this._adnominal_adjunct);
                    kind_adnominal.Add(this._personal);
                    kind_adnominal.Add(this._demonstrative);
                    kind_adnominal.Add(this._numeral);
                    kind_adnominal.Add(this._adverbial_adjective);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_adnominals = FilterLesson(lessons, kind_adnominal);
                    lesson_adnominals_second = FilterLesson(lessons, kind_adnominal);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adnominal = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adnominal_adjunct, this._morphology);
                    kind_adnominal.Add(index_adnominal);
                    int index_personal = this._wordEmbeddingService.EncodeInt(this._personal, this._morphology);
                    kind_adnominal.Add(index_personal);
                    int index_demostrative = this._wordEmbeddingService.EncodeInt(this._demonstrative, this._morphology);
                    kind_adnominal.Add(index_demostrative);
                    int sha_numeral = this._wordEmbeddingService.EncodeInt(this._numeral, this._morphology);
                    kind_adnominal.Add(sha_numeral);
                    int sha_adverbial_adjective = this._wordEmbeddingService.EncodeInt(this._adverbial_adjective, this._morphology);
                    kind_adnominal.Add(sha_adverbial_adjective);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_adnominals = FilterLesson(practices, kind_adnominal);
                    practice_adnominals_second = FilterLesson(practices, kind_adnominal);
                }

                List<Tutorial> tutorial_conjunctions = new List<Tutorial>();
                List<Lesson> lesson_conjunctions = new List<Lesson>();
                List<Practice> practice_conjunctions = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_conjunction = new List<byte[]>();
                    byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                    kind_conjunction.Add(sha_conjunction);
                    tutorial_conjunctions = FilterLesson(tutorials, kind_conjunction);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_conjunction = new List<string>();
                    kind_conjunction.Add(this._conjunction);
                    lesson_conjunctions = FilterLesson(lessons, kind_conjunction);
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    List<int> kind_conjunction = new List<int>();
                    int index_conjunction = this._wordEmbeddingService.EncodeInt(this._conjunction, this._morphology);
                    kind_conjunction.Add(index_conjunction);
                    practice_conjunctions = FilterLesson(practices, kind_conjunction);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountIndirectObjectConjunction(tutorial_adnominals, tutorial_adnominals_second, tutorial_conjunctions, dictionaries, tutorial_sources, order_indirect_object);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountIndirectObjectConjunction(lesson_adnominals, lesson_adnominals_second, lesson_conjunctions, dictionaries, lesson_sources, order_indirect_object);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountIndirectObjectConjunction(practice_adnominals, practice_adnominals_second, practice_conjunctions, dictionaries, practice_sources, order_indirect_object);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyObjectPredicative(List<Instruction> words, Dictionary<(byte[], byte[]), int>? word_2_vec, Level level, int order, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                byte[]? predicative = null;
                byte[]? adnominal = null;

                int order_last = this._order_3;

                predicative = VerifyAdjective(words, order_predicative, level, Rotate.Front, Seat.Predicate);
                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, predicative);
                if (similarity) return true;

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyObjectPredicative(List<Word> words, Dictionary<(string, string), int>? word_2_vec, Level level, int order, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                string predicative = string.Empty;
                string adnominal = string.Empty;

                int order_last = this._order_3;

                predicative = VerifyAdjective(words, order_predicative, level, Rotate.Front, Seat.Predicate);
                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, predicative);
                if (similarity) return true;

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyObjectPredicative(List<Guidance> words, Dictionary<(int, int), int>? word_2_vec, Level level, int order, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                int predicative = -1;
                int adnominal = -1;

                int order_last = this._order_3;

                predicative = VerifyAdjective(words, order_predicative, level, Rotate.Front, Seat.Predicate);
                adnominal = VerifyNoun(words, order, level, Rotate.Rear, Seat.Predicate, order_last);

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, predicative);
                if (similarity) return true;

                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountObjectPredicative<TKey, TValue>(List<Tutorial> predicatives, List<Tutorial>? sources, Dictionary<TKey, TValue> dictionaries, int order_direct_object, int order_predicative) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order = this._wordEmbeddingService.Encode(order_direct_object, this._order);
                byte[] order_adjective = this._wordEmbeddingService.Encode(order_predicative, this._order);

                Dictionary<(byte[], byte[]), int> word_2_vec = dictionaries as Dictionary<(byte[], byte[]), int>;

                if ((predicatives == null) || (sources == null)) return seminars;
                if ((predicatives.Count == 0) || (sources.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial preposition in predicatives)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in preposition.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_adjective);
                            words1.Add(word);
                        }
                        if (!VerifyObjectPredicative(words1, word_2_vec, Level.AsSpanSequence, order_direct_object, order_predicative)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountObjectPredicative<TKey, TValue>(List<Lesson> predicatives, List<Lesson>? sources, Dictionary<TKey, TValue> dictionaries, int order_direct_object, int order_predicative) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();

                string predicate = this._predicate;
                int order = order_direct_object;
                int order_adjective = order_predicative;

                Dictionary<(string, string), int> word_2_vec = dictionaries as Dictionary<(string, string), int>;

                if ((predicatives == null) || (sources == null)) return seminars;
                if ((predicatives.Count == 0) || (sources.Count == 0)) return seminars;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson preposition in predicatives)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Word item in preposition.lecture)
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_adjective);
                            words1.Add(word);
                        }
                        if (!VerifyObjectPredicative(words1, word_2_vec, Level.AsSpanSequence, order_direct_object, order_predicative)) continue;
                        Lesson seminar = new Lesson();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Practice> MountObjectPredicative<TKey, TValue>(List<Practice> predicatives, List<Practice>? sources, Dictionary<TKey, TValue> dictionaries, int order_direct_object, int order_predicative) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" view model failed!");

                List<Practice> seminars = new List<Practice>();

                int predicate = this._wordEmbeddingService.EncodeInt(this._predicate, this._syntax);
                int order = this._wordEmbeddingService.EncodeInt(order_direct_object, this._order);
                int order_adjective = this._wordEmbeddingService.EncodeInt(order_predicative, this._order);

                Dictionary<(int, int), int> word_2_vec = dictionaries as Dictionary<(int, int), int>;

                if ((predicatives == null) || (sources == null)) return seminars;
                if ((predicatives.Count == 0) || (sources.Count == 0)) return seminars;
                foreach (Practice source in sources)
                {
                    List<Guidance> words = source.lecture;
                    foreach (Practice preposition in predicatives)
                    {
                        List<Guidance> words1 = new List<Guidance>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Guidance item in preposition.lecture)
                        {
                            Guidance word = new Guidance();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_adjective);
                            words1.Add(word);
                        }
                        if (!VerifyObjectPredicative(words1, word_2_vec, Level.AsSpanSequence, order_direct_object, order_predicative)) continue;
                        Practice seminar = new Practice();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> MountObjectPredicative<T, TKey, TValue>(List<T>? homeworks, Dictionary<TKey, TValue> dictionaries, HashSet<string> vocabulary, List<T>? sources, int order_direct_object, int order_predicative) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb predicative \"Syntax\" view model failed!");

                List<Lesson> seminars = new List<Lesson>();
                if (homeworks == null) return seminars;

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Tutorial> tutorial_adverbials = new List<Tutorial>();
                List<Lesson> lesson_adverbials = new List<Lesson>();
                List<Practice> practice_adverbials = new List<Practice>();

                List<Tutorial>? tutorial_sources = new List<Tutorial>();
                List<Lesson>? lesson_sources = new List<Lesson>();
                List<Practice>? practice_sources = new List<Practice>();

                if (typeof(T) == typeof(Tutorial))
                {
                    List<byte[]> kind_adverbial = new List<byte[]>();
                    byte[] sha_adverbial = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                    kind_adverbial.Add(sha_adverbial);
                    tutorials = homeworks as List<Tutorial>;
                    tutorial_sources = sources as List<Tutorial>;
                    tutorial_adverbials = FilterLesson(tutorials, kind_adverbial);
                }
                if (typeof(T) == typeof(Lesson))
                {
                    List<string> kind_adverbial = new List<string>();
                    kind_adverbial.Add(this._adverbial_adjective);
                    lessons = homeworks as List<Lesson>;
                    lesson_sources = sources as List<Lesson>;
                    lesson_adverbials = FilterLesson(lessons, kind_adverbial);
                }
                if (typeof(T) == typeof(Practice))
                {
                    List<int> kind_adverbial = new List<int>();
                    int index_adnominal = this._wordEmbeddingService.EncodeInt(this._adverbial_adjective, this._morphology);
                    kind_adverbial.Add(index_adnominal);
                    practices = homeworks as List<Practice>;
                    practice_sources = sources as List<Practice>;
                    practice_adverbials = FilterLesson(practices, kind_adverbial);
                }

                if (typeof(T) == typeof(Tutorial))
                {
                    List<Tutorial> result = MountObjectPredicative(tutorial_adverbials, tutorial_sources, dictionaries, order_direct_object, order_predicative);
                    seminars = DecodeLesson(result, vocabulary);
                }
                if (typeof(T) == typeof(Lesson))
                    seminars = MountObjectPredicative(lesson_adverbials, lesson_sources, dictionaries, order_direct_object, order_predicative);
                if (typeof(T) == typeof(Practice))
                {
                    List<Practice> result = MountObjectPredicative(practice_adverbials, practice_sources, dictionaries, order_direct_object, order_predicative);
                    seminars = DecodeLesson(result, vocabulary);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> SampleSubjectVerb<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation sample subject verb \"Syntax\" view model failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    seminars = MountNounVerb(lessons, dictionaries, vocabularies);
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    seminars = MountNounVerb(tutorials, dictionaries, vocabularies);
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    seminars = MountNounVerb(practices, dictionaries, vocabularies);
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> CompoundSubjectVerb<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation compound subject verb \"Syntax\" view model failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    seminars = MountCompoundVerb(lessons, dictionaries, vocabularies);
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    seminars = MountCompoundVerb(tutorials, dictionaries, vocabularies);
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    seminars = MountCompoundVerb(practices, dictionaries, vocabularies);
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateDirectObject<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate direct object \"Syntax\" service failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson>? lessons_sources = new List<Lesson>();
                List<Tutorial>? tutorials_sources = new List<Tutorial>();
                List<Practice>? practices_sources = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    lessons_sources = sources;
                    seminars = MountVerbNoun(lessons, dictionaries, vocabularies, lessons_sources, order_verb, order_predicate);
                    seminars = Union(seminars, MountVerbNounConjunctionNoun(lessons, dictionaries, vocabularies, lessons_sources, order_verb, order_predicate));
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    tutorials_sources = EncodeLesson(sources, vocabularies);
                    seminars = MountVerbNoun(tutorials, dictionaries, vocabularies, tutorials_sources, order_verb, order_predicate);
                    seminars = Union(seminars, MountVerbNounConjunctionNoun(tutorials, dictionaries, vocabularies, tutorials_sources, order_verb, order_predicate));
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    practices_sources = EncodeLessonInt(sources, vocabularies);
                    seminars = MountVerbNoun(practices, dictionaries, vocabularies, practices_sources, order_verb, order_predicate);
                    seminars = Union(seminars, MountVerbNounConjunctionNoun(practices, dictionaries, vocabularies, practices_sources, order_verb, order_predicate));
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicatePredicative<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate predicative \"Syntax\" service failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson>? lessons_sources = new List<Lesson>();
                List<Tutorial>? tutorials_sources = new List<Tutorial>();
                List<Practice>? practices_sources = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    lessons_sources = sources;
                    seminars = MountVerbPredicative(lessons, dictionaries, vocabularies, lessons_sources, order_verb, order_predicate);
                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    tutorials_sources = EncodeLesson(sources, vocabularies);
                    seminars = MountVerbPredicative(tutorials, dictionaries, vocabularies, tutorials_sources, order_verb, order_predicate);
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    practices_sources = EncodeLessonInt(sources, vocabularies);
                    seminars = MountVerbPredicative(practices, dictionaries, vocabularies, practices_sources, order_verb, order_predicate);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateIndirectObject<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_verb, int order_predicate) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object \"Syntax\" service failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson>? lessons_sources = new List<Lesson>();
                List<Tutorial>? tutorials_sources = new List<Tutorial>();
                List<Practice>? practices_sources = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    lessons_sources = sources;
                    List<Lesson> prepositions = new List<Lesson>();
                    prepositions = MountVerbIndirectObject(lessons, dictionaries, vocabularies, lessons_sources, order_verb, order_predicate);
                    seminars = Union(seminars, MountVerbNoun(lessons, dictionaries, vocabularies, prepositions, order_verb, order_predicate));
                    seminars = Union(seminars, MountVerbNounConjunctionNoun(lessons, dictionaries, vocabularies, prepositions, order_verb, order_predicate));

                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    tutorials_sources = EncodeLesson(sources, vocabularies);
                    List<Lesson> prepositions = new List<Lesson>();
                    prepositions = MountVerbIndirectObject(tutorials, dictionaries, vocabularies, tutorials_sources, order_verb, order_predicate);
                    tutorials_sources = EncodeLesson(prepositions, vocabularies);
                    seminars = Union(seminars, MountVerbNoun(tutorials, dictionaries, vocabularies, tutorials_sources, order_verb, order_predicate));
                    seminars = Union(seminars, MountVerbNounConjunctionNoun(tutorials, dictionaries, vocabularies, tutorials_sources, order_verb, order_predicate));
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    practices_sources = EncodeLessonInt(sources, vocabularies);
                    List<Lesson> prepositions = new List<Lesson>();
                    prepositions = MountVerbIndirectObject(practices, dictionaries, vocabularies, practices_sources, order_verb, order_predicate);
                    practices_sources = EncodeLessonInt(prepositions, vocabularies);
                    seminars = Union(seminars, MountVerbNoun(practices, dictionaries, vocabularies, practices_sources, order_verb, order_predicate));
                    seminars = Union(seminars, MountVerbNounConjunctionNoun(practices, dictionaries, vocabularies, practices_sources, order_verb, order_predicate));
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateDirectObjectIndirectObject<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_direct_object, int order_indirect_object) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object \"Syntax\" service failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson>? lessons_sources = new List<Lesson>();
                List<Tutorial>? tutorials_sources = new List<Tutorial>();
                List<Practice>? practices_sources = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    lessons_sources = sources;
                    List<Lesson> prepositions = new List<Lesson>();
                    prepositions = MountDirectObjectPreposition(lessons, dictionaries, vocabularies, lessons_sources, order_direct_object, order_indirect_object);
                    seminars = Union(seminars, MountIndirectObjectSample(lessons, dictionaries, vocabularies, prepositions, order_indirect_object));
                    seminars = Union(seminars, MountIndirectObjectConjunction(lessons, dictionaries, vocabularies, prepositions, order_indirect_object));

                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    tutorials_sources = EncodeLesson(sources, vocabularies);
                    List<Lesson> prepositions = new List<Lesson>();
                    prepositions = MountDirectObjectPreposition(tutorials, dictionaries, vocabularies, tutorials_sources, order_direct_object, order_indirect_object);
                    tutorials_sources = EncodeLesson(prepositions, vocabularies);
                    seminars = Union(seminars, MountIndirectObjectSample(tutorials, dictionaries, vocabularies, tutorials_sources, order_indirect_object));
                    seminars = Union(seminars, MountIndirectObjectConjunction(tutorials, dictionaries, vocabularies, tutorials_sources, order_indirect_object));
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    practices_sources = EncodeLessonInt(sources, vocabularies);
                    List<Lesson> prepositions = new List<Lesson>();
                    prepositions = MountDirectObjectPreposition(practices, dictionaries, vocabularies, practices_sources, order_direct_object, order_indirect_object);
                    practices_sources = EncodeLessonInt(prepositions, vocabularies);
                    seminars = Union(seminars, MountIndirectObjectSample(practices, dictionaries, vocabularies, practices_sources, order_indirect_object));
                    seminars = Union(seminars, MountIndirectObjectConjunction(practices, dictionaries, vocabularies, practices_sources, order_indirect_object));
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateObjectPredicative<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_direct_object, int order_predicative) where TKey : notnull
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object \"Syntax\" service failed!");

                List<Lesson>? lessons = new List<Lesson>();
                List<Tutorial>? tutorials = new List<Tutorial>();
                List<Practice>? practices = new List<Practice>();

                List<Lesson>? lessons_sources = new List<Lesson>();
                List<Tutorial>? tutorials_sources = new List<Tutorial>();
                List<Practice>? practices_sources = new List<Practice>();

                List<Lesson> seminars = new List<Lesson>();

                if (typeof(T) == typeof(Lesson))
                {
                    lessons = homeworks as List<Lesson>;
                    lessons_sources = sources;
                    seminars = MountObjectPredicative(lessons, dictionaries, vocabularies, lessons_sources, order_direct_object, order_predicative);

                }
                if (typeof(T) == typeof(Tutorial))
                {
                    tutorials = homeworks as List<Tutorial>;
                    tutorials_sources = EncodeLesson(sources, vocabularies);
                    seminars = MountObjectPredicative(tutorials, dictionaries, vocabularies, tutorials_sources, order_direct_object, order_predicative);
                }
                if (typeof(T) == typeof(Practice))
                {
                    practices = homeworks as List<Practice>;
                    practices_sources = EncodeLessonInt(sources, vocabularies);
                    seminars = MountObjectPredicative(practices, dictionaries, vocabularies, practices_sources, order_direct_object, order_predicative);
                }

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        //------------------
        private bool VerifyVerbSampleSubject(List<Word> words, List<Sentenca> sentences)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb sample subject \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string noun = string.Empty;
                string verb = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._subject) && (item.team == this._noun) && (item.kind == this._noun)) noun = item.term;
                    if ((item.sentence == this._subject) && (item.kind == this._pronoun)) noun = item.term;
                    if (item.kind == this._verb) verb = item.term;
                });
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, noun, verb);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbCompoundSubject(List<Word> words, List<Sentenca> sentences)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string noun = string.Empty;
                string last = string.Empty;
                string adjunct = string.Empty;
                string conjunction = string.Empty;
                string verb = string.Empty;
                int order_first = this._order_1;
                int order_last = this._order_3;
                words.ForEach(item =>
                {
                    if (item.order == order_first)
                    {
                        if ((item.sentence == this._subject) && (item.team == this._noun) && (item.kind == this._noun)) noun = item.term;
                        if ((item.sentence == this._subject) && (item.kind == this._pronoun)) noun = item.term;
                    }
                    if (item.order == order_last)
                    {
                        if ((item.sentence == this._subject) && (item.team == this._noun) && (item.kind == this._noun)) last = item.term;
                        if ((item.sentence == this._subject) && (item.kind == this._pronoun)) last = item.term;
                        if ((item.sentence == this._subject) && (item.kind == this._noun) &&
                            (item.kind == this._numeral) || (item.kind == this._article) || (item.kind == this._pronoun)) adjunct = item.term;
                    }
                    if ((item.sentence == this._subject) && (item.kind == this._conjunction)) conjunction = item.term;
                    if (item.kind == this._verb) verb = item.term;
                });
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, noun, conjunction);
                if (similarity)
                {
                    if (adjunct != string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, conjunction, adjunct);
                    else similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, conjunction, last);
                }
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, last, verb);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbCompoundSubject(List<Instruction> words, List<Instruction> firsts, List<Instruction> lasts, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb compound subject \"Syntax\" service failed!");

                byte[] syntax_subject = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);

                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);

                byte[]? conjunction = null;

                byte[]? noun = null;
                byte[]? adjective = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? noun2 = null;
                byte[]? adjective2 = null;
                byte[]? article2 = null;
                byte[]? numeral2 = null;
                byte[]? pronoun2 = null;

                byte[]? adnominal = null;
                byte[]? adnominal2 = null;
                byte[]? adnominal2_last = null;
                byte[]? adverbial = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;
                }

                foreach (Instruction item in firsts)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;
                }

                foreach (Instruction item in lasts)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun2 = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_subject))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun2 = item.term;
                }

                if (noun != null)
                    adnominal = noun;
                if ((noun != null) && (adjective != null))
                    adnominal = noun;
                if ((noun != null) && (article != null))
                    adnominal = noun;
                if ((noun != null) && (numeral != null))
                    adnominal = noun;
                if ((noun != null) && (pronoun != null))
                    adnominal = noun;

                if (noun2 != null)
                {
                    adnominal2 = noun2;
                    adnominal2_last = noun2;
                }
                if ((noun2 != null) && (adjective2 != null))
                {
                    adnominal2 = adjective2;
                    adnominal2_last = noun;
                }
                if ((noun2 != null) && (article2 != null))
                {
                    adnominal2 = article2;
                    adnominal2_last = noun;
                }
                if ((noun2 != null) && (numeral2 != null))
                {
                    adnominal2 = numeral2;
                    adnominal2_last = noun;
                }
                if ((noun2 != null) && (pronoun2 != null))
                {
                    adnominal2 = pronoun2;
                    adnominal2_last = noun;
                }

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal2_last, adverbial);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbPredicative(List<Word> words, List<Sentenca> sentences)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb predicative \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string word_adjective = string.Empty;
                string word_verb = string.Empty;
                string verb = string.Empty;
                string verb_adverb = string.Empty;
                string verb_adverb_adverb = string.Empty;
                string adjective = string.Empty;
                string adjective_adverb = string.Empty;
                string adjective_adverb_adverb = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._adjective) && (item.kind == this._adjective)) adjective = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective) && (item.kind == this._adverb)) adjective_adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective) && (item.kind == this._adverb_adverb)) adjective_adverb_adverb = item.term;
                    if (item.kind == this._verb) verb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == this._adverb)) verb_adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == this._adverb_adverb)) verb_adverb_adverb = item.term;
                });
                if (verb_adverb_adverb != string.Empty) word_verb = verb_adverb_adverb;
                else
                {
                    if (verb_adverb != string.Empty) word_verb = verb_adverb;
                    else
                    {
                        if (verb != string.Empty) word_verb = verb;
                    }
                }
                if (adjective_adverb_adverb != string.Empty) word_adjective = adjective_adverb_adverb;
                else
                {
                    if (adjective_adverb != string.Empty) word_adjective = adjective_adverb;
                    else
                    {
                        if (adjective != string.Empty) word_adjective = adjective;
                    }
                }
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, word_verb, word_adjective);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbPredicative(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb predicative \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._syntax);
                byte[] morphology_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._syntax);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);

                byte[]? adjective = null;
                byte[]? adjective_adverb = null;
                byte[]? adjective_adverb_adverb = null;
                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? predicative = null;
                byte[]? adverbial = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) adjective_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) adjective_adverb_adverb = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;
                }

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb_adverb;

                if (adjective != null)
                    predicative = adjective;
                if ((adjective_adverb != null) && (adjective != null))
                    predicative = adjective;
                if ((adjective_adverb_adverb != null) && (adjective_adverb != null) && (adjective != null))
                    predicative = adjective;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, predicative);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbAdjectiveNoun(List<Word> words, List<Sentenca> sentences)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb adjective noun \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string word_noun = string.Empty;
                string word_verb = string.Empty;
                string noun = string.Empty;
                string adjunct = string.Empty;
                string adjective = string.Empty;
                string verb = string.Empty;
                string adverb = string.Empty;
                string adverb_adverb = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_noun) && (item.kind == this._noun)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_noun)
                        && ((item.kind == this._article) || (item.kind == this._numeral) || (item.kind == this._pronoun))) adjunct = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_noun) && (item.kind == this._adjective)) adjective = item.term;
                    if (item.kind == this._verb) verb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == this._adverb)) adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == _adverb_adverb)) adverb_adverb = item.term;
                });
                if (adjunct != string.Empty) word_noun = adjunct;
                else
                {
                    if (adjective != string.Empty) word_noun = adjective;
                    else word_noun = noun;
                }
                if (adverb_adverb != string.Empty) word_verb = adverb_adverb;
                else
                {
                    if (adverb != string.Empty) word_verb = adverb;
                    else word_verb = verb;
                }
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, word_verb, word_noun);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbAdjectiveNoun(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb adjective noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);

                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);

                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[]? noun = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;
                byte[]? adjective = null;

                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? adverbial = null;
                byte[]? adnominal = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;
                }
                ;

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb_adverb;

                if ((noun != null) && (adjective != null))
                    adnominal = adjective;
                if ((noun != null) && (article != null) && (adjective != null))
                    adnominal = article;
                if ((noun != null) && (numeral != null) && (adjective != null))
                    adnominal = numeral;
                if ((noun != null) && (pronoun != null) && (adjective != null))
                    adnominal = pronoun;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbDirectObject(List<Word> words, List<Sentenca> sentences)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb direct object \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string word_noun = string.Empty;
                string word_verb = string.Empty;
                string noun = string.Empty;
                string adjunct = string.Empty;
                string verb = string.Empty;
                string adverb = string.Empty;
                string adverb_adverb = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._noun) && (item.kind == this._noun)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._noun) &&
                        ((item.kind == this._numeral) || (item.kind == this._article) || (item.kind == this._pronoun))) adjunct = item.term;
                    if ((item.sentence == this._predicate) && (item.kind == this._pronoun)) noun = item.term;
                    if (item.kind == this._verb) verb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == this._adverb)) adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == _adverb_adverb)) adverb_adverb = item.term;
                });
                if (adjunct != string.Empty)
                    word_noun = adjunct;
                else
                    word_noun = noun;
                if (adverb_adverb != string.Empty) word_verb = adverb_adverb;
                else
                {
                    if (adverb != string.Empty) word_verb = adverb;
                    else
                    {
                        if (verb != string.Empty) word_verb = verb;
                    }
                }
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, word_verb, word_noun);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbDirectObject(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb direct object \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);

                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[]? noun = null;
                byte[]? numeral = null;
                byte[]? article = null;
                byte[]? pronoun = null;
                byte[]? adjective = null;
                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;
                byte[]? preposition = null;

                byte[]? adnominal = null;
                byte[]? adverbial = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb_adverb;

                if (noun != null)
                    adnominal = noun;
                if ((adjective != null) && (noun != null))
                    adnominal = adjective;
                if ((numeral != null) && (noun != null))
                    adnominal = numeral;
                if ((article != null) && (noun != null))
                    adnominal = article;
                if ((pronoun != null) && (noun != null))
                    adnominal = pronoun;

                bool similarity = false;
                if (preposition == null) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, adnominal);
                if (preposition != null) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbIndirectObject(List<Word> words, List<Sentenca> sentences)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string word_preposition = string.Empty;
                string word_verb = string.Empty;
                string word_noun = string.Empty;
                string verb = string.Empty;
                string adverb = string.Empty;
                string adverb_adverb = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.kind == this._preposition)) word_preposition = item.term;
                    if (item.kind == this._verb) verb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == this._adverb)) adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._verb) && (item.kind == _adverb_adverb)) adverb_adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._noun)) word_noun = item.term;
                });
                if ((adverb_adverb != string.Empty) && (adverb != string.Empty) && (verb != string.Empty)) word_verb = adverb_adverb;
                if ((adverb_adverb == string.Empty) && (adverb != string.Empty) && (verb != string.Empty)) word_verb = adverb;
                if ((adverb_adverb == string.Empty) && (adverb == string.Empty) && (verb != string.Empty)) word_verb = verb;
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, word_verb, word_preposition);
                if (similarity == false) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, word_noun, word_preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbIndirectObject(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify verb indirect object \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[]? preposition = null;
                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? adverbial = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;
                }

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb_adverb;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyNumeralConjunctionNoun(List<Word> words, List<Sentenca> sentences, int order_conjunction)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify numeral conjunction noun \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string conjunction = string.Empty;
                string numeral = string.Empty;
                string noun = string.Empty;
                string preposition = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._conjunction) && (item.kind == this._conjunction) && (item.order == order_conjunction)) conjunction = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._numeral) && (item.kind == this._numeral) && (item.order == order_conjunction)) numeral = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._numeral_noun) && (item.kind == this._numeral) && (item.order == order_conjunction)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.kind == this._preposition) && (item.order == order_conjunction)) preposition = item.term;
                });
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, numeral, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, conjunction, noun);
                if ((similarity) && (preposition != string.Empty)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, preposition, numeral);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbNumeralConjunctionNoun(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify numeral conjunction noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);

                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);

                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[]? numeral = null;
                byte[]? numeral_noun = null;

                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? conjunction = null;
                byte[]? preposition = null;
                byte[]? adverbial = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_numeral))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral_noun = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb_adverb;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, numeral, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, numeral_noun);
                if ((similarity) && (preposition == null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, numeral);
                if ((similarity) && (preposition != null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, numeral);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyPrepositionNumeralConjunctionNoun(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, byte[] order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify numeral conjunction noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);

                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);

                byte[]? numeral = null;
                byte[]? numeral_noun = null;

                byte[]? conjunction = null;
                byte[]? preposition = null;

                foreach (Instruction item in words)
                {
                    if (!item.order.AsSpan().SequenceEqual(order)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_numeral))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral_noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, numeral);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, numeral, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, numeral_noun);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyAdjectiveConjunctionNoun(List<Word> words, List<Sentenca> sentences, int order_conjunction)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify adjective conjunction noun \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string conjunction = string.Empty;
                string adjective = string.Empty;
                string noun = string.Empty;
                string preposition = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._conjunction) && (item.kind == this._conjunction) && (item.order == order_conjunction)) conjunction = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective) && (item.kind == this._adjective) && (item.order == order_conjunction)) adjective = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_noun) && (item.kind == this._adjective) && (item.order == order_conjunction)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.kind == this._preposition) && (item.order == order_conjunction)) preposition = item.term;
                });
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, adjective, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, conjunction, noun);
                if ((similarity) && (preposition != string.Empty)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, preposition, adjective);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbAdjectiveConjunctionNoun(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify adjective conjunction noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);

                byte[] morphology_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);

                byte[]? conjunction = null;
                byte[]? preposition = null;

                byte[]? adjective = null;
                byte[]? adverb = null;
                byte[]? adverb_adverb = null;

                byte[]? noun = null;
                byte[]? adjective_noun = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? adnominal = null;
                byte[]? adverbial_verb = null;
                byte[]? adverbial_adjective = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) adverb_adverb = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective_noun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                if ((noun != null) && (adjective_noun != null))
                    adnominal = adjective_noun;
                if ((noun != null) && (article != null))
                    adnominal = article;
                if ((noun != null) && (numeral != null))
                    adnominal = numeral;
                if ((noun != null) && (pronoun != null))
                    adnominal = pronoun;

                if (adjective != null)
                    adverbial_adjective = adjective;
                if ((adjective != null) && (adverb != null))
                    adverbial_adjective = adverb;
                if ((adjective != null) && (adverb != null) && (adverb_adverb != null))
                    adverbial_adjective = adverb_adverb;

                if (verb != null)
                    adverbial_verb = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial_verb = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial_verb = verb_adverb_adverb;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_adjective, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal);
                if ((similarity) && (preposition == null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_verb, adjective);
                if ((similarity) && (preposition != null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adjective);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyPrepositionAdjectiveConjunctionNoun(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, byte[] order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify adjective conjunction noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);

                byte[] morphology_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[]? conjunction = null;
                byte[]? preposition = null;

                byte[]? adjective = null;
                byte[]? adverb = null;
                byte[]? adverb_adverb = null;

                byte[]? noun = null;
                byte[]? adjective_noun = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? adnominal = null;
                byte[]? adverbial_adjective = null;

                foreach (Instruction item in words)
                {
                    if (!item.order.AsSpan().SequenceEqual(order)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) adverb_adverb = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective_noun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                if ((noun != null) && (adjective_noun != null))
                    adnominal = adjective_noun;
                if ((noun != null) && (article != null))
                    adnominal = article;
                if ((noun != null) && (numeral != null))
                    adnominal = numeral;
                if ((noun != null) && (pronoun != null))
                    adnominal = pronoun;

                if (adjective != null)
                    adverbial_adjective = adjective;
                if ((adjective != null) && (adverb != null))
                    adverbial_adjective = adverb;
                if ((adjective != null) && (adverb != null) && (adverb_adverb != null))
                    adverbial_adjective = adverb_adverb;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adverbial_adjective);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial_adjective, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyVerbNounConjunctionNoun(List<Instruction> words, List<Instruction> firsts, List<Instruction> lasts, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun conjunction noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);

                byte[] morphology_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                byte[] morphology_verb = this._wordEmbeddingService.Encode(this._verb, this._morphology);
                byte[] morphology_adverb = this._wordEmbeddingService.Encode(this._adverb, this._morphology);
                byte[] morphology_adverb_adverb = this._wordEmbeddingService.Encode(this._adverb_adverb, this._morphology);

                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[]? conjunction = null;
                byte[]? preposition = null;

                byte[]? noun = null;
                byte[]? adjective = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? verb = null;
                byte[]? verb_adverb = null;
                byte[]? verb_adverb_adverb = null;

                byte[]? noun2 = null;
                byte[]? adjective2 = null;
                byte[]? article2 = null;
                byte[]? numeral2 = null;
                byte[]? pronoun2 = null;

                byte[]? adnominal = null;
                byte[]? adnominal_first = null;
                byte[]? adnominal2 = null;
                byte[]? adverbial = null;

                foreach (Instruction item in words)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;

                    if (item.kind.AsSpan().SequenceEqual(morphology_verb)) verb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb))) verb_adverb = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_verb))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adverb_adverb))) verb_adverb_adverb = item.term;
                }

                foreach (Instruction item in firsts)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;
                }

                foreach (Instruction item in lasts)
                {
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun2 = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun2 = item.term;
                }

                if (noun != null)
                {
                    adnominal = noun;
                    adnominal_first = noun;
                }
                if ((noun != null) && (adjective != null))
                {
                    adnominal = noun;
                    adnominal_first = adjective;
                }
                if ((noun != null) && (article != null))
                {
                    adnominal = noun;
                    adnominal_first = article;
                }
                if ((noun != null) && (numeral != null))
                {
                    adnominal = noun;
                    adnominal_first = numeral;
                }
                if ((noun != null) && (pronoun != null))
                {
                    adnominal = noun;
                    adnominal_first = pronoun;
                }

                if (noun2 != null)
                    adnominal2 = noun2;
                if ((noun2 != null) && (adjective2 != null))
                    adnominal2 = adjective2;
                if ((noun2 != null) && (article2 != null))
                    adnominal2 = article2;
                if ((noun2 != null) && (numeral2 != null))
                    adnominal2 = numeral2;
                if ((noun2 != null) && (pronoun2 != null))
                    adnominal2 = pronoun2;

                if (verb != null)
                    adverbial = verb;
                if ((verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb;
                if ((verb_adverb_adverb != null) && (verb_adverb != null) && (verb != null))
                    adverbial = verb_adverb_adverb;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if ((similarity) && (preposition == null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adverbial, adnominal_first);
                if ((similarity) && (preposition != null)) similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_first);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyPrepositionNounConjunctionNoun(List<Instruction> words, List<Instruction> firsts, List<Instruction> lasts, Dictionary<(byte[], byte[]), int> word_2_vec, byte[] order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify noun conjunction noun \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);

                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);

                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[]? conjunction = null;
                byte[]? preposition = null;

                byte[]? noun = null;
                byte[]? adjective = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? noun2 = null;
                byte[]? adjective2 = null;
                byte[]? article2 = null;
                byte[]? numeral2 = null;
                byte[]? pronoun2 = null;

                byte[]? adnominal = null;
                byte[]? adnominal_first = null;
                byte[]? adnominal2 = null;

                foreach (Instruction item in words)
                {
                    if (!item.order.AsSpan().SequenceEqual(order)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_conjunction))
                        && (item.kind.AsSpan().SequenceEqual(morphology_conjunction))) conjunction = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                foreach (Instruction item in firsts)
                {
                    if (!item.order.AsSpan().SequenceEqual(order)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;
                }

                foreach (Instruction item in lasts)
                {
                    if (!item.order.AsSpan().SequenceEqual(order)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun2 = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun2 = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun2 = item.term;
                }

                if (noun != null)
                {
                    adnominal = noun;
                    adnominal_first = noun;
                }
                if ((noun != null) && (adjective != null))
                {
                    adnominal = noun;
                    adnominal_first = adjective;
                }
                if ((noun != null) && (article != null))
                {
                    adnominal = noun;
                    adnominal_first = article;
                }
                if ((noun != null) && (numeral != null))
                {
                    adnominal = noun;
                    adnominal_first = numeral;
                }
                if ((noun != null) && (pronoun != null))
                {
                    adnominal = noun;
                    adnominal_first = pronoun;
                }

                if (noun2 != null)
                    adnominal2 = noun2;
                if ((noun2 != null) && (adjective2 != null))
                    adnominal2 = adjective2;
                if ((noun2 != null) && (article2 != null))
                    adnominal2 = article2;
                if ((noun2 != null) && (numeral2 != null))
                    adnominal2 = numeral2;
                if ((noun2 != null) && (pronoun2 != null))
                    adnominal2 = pronoun2;

                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal_first);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, adnominal, conjunction);
                if (similarity) similarity = this._wordEmbeddingService.Similarity(word_2_vec, conjunction, adnominal2);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPreposition(List<Word> words, List<Sentenca> sentences, int order_direct_object)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify direct object preposition \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string preposition = string.Empty;
                string noun = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._noun) && (item.order == order_direct_object)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._preposition)) preposition = item.term;
                });
                bool similarity = false;
                similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, noun, preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPreposition(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, byte[] order_direct_object, byte[] order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify direct object preposition \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[]? preposition = null;

                foreach (Instruction item in words)
                {
                    if (!item.order.AsSpan().SequenceEqual(order_preposition)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_preposition))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                byte[] morphology_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);

                List<Instruction> compound_conjunction = words.FindAll(index => index.team.SequenceEqual(morphology_conjunction)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_adnominal = words.FindAll(index => index.team.SequenceEqual(morphology_adnominal_adjunct)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_numeral = words.FindAll(index => index.team.SequenceEqual(morphology_numeral)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_adjective = words.FindAll(index => index.team.SequenceEqual(morphology_adverbial_adjective)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_pronoun = words.FindAll(index => (!index.team.SequenceEqual(morphology_pronoun))
                    && (index.kind.SequenceEqual(morphology_pronoun))
                    && index.sentence.SequenceEqual(morphology_predicate));

                byte[]? noun = null;
                byte[]? noun2 = null;
                byte[]? pronoun = null;
                byte[]? pronoun2 = null;

                bool similarity = false;
                if (((compound_conjunction.Count > 0) && (compound_numeral.Count > 0))
                    || ((compound_conjunction.Count > 0) && (compound_adjective.Count > 0)))
                {
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, preposition);
                    if (similarity)
                        return true;
                }
                if ((compound_conjunction.Count > 0) && (compound_pronoun.Count > 1))
                {
                    int index = 0;
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun)))
                        {
                            if (index == 0) pronoun = item.term;
                            if (index == 1) pronoun2 = item.term;
                        }
                        index++;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, pronoun, preposition);
                    if (similarity)
                        return true;
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, pronoun2, preposition);
                    if (similarity)
                        return true;
                }
                if ((compound_conjunction.Count > 0) && (compound_adnominal.Count > 1))
                {
                    int index = 0;
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun)))
                        {
                            if (index == 0) noun = item.term;
                            if (index == 1) noun2 = item.term;
                        }
                        index++;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, preposition);
                    if (similarity)
                        return true;
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun2, preposition);
                    if (similarity)
                        return true;
                }
                if ((compound_conjunction.Count > 0)
                    && (compound_adnominal.Count > 0)
                    && (compound_pronoun.Count > 0))
                {
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, preposition);
                    if (similarity)
                        return true;
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, pronoun, preposition);
                    if (similarity)
                        return true;
                }
                if (compound_conjunction.Count == 0)
                {
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, preposition);
                    if (similarity)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObject(List<Word> words, List<Sentenca> sentences, int order_indirect_object)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify indirect object \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string preposition = string.Empty;
                string noun = string.Empty;
                string adjunct = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._noun) && (item.kind == this._noun) && (item.order == order_indirect_object)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.kind == this._pronoun) && (item.order == order_indirect_object)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._noun) && (item.order == order_indirect_object)
                        && ((item.kind == this._numeral) || (item.kind == this._article) || (item.kind == this._pronoun))) adjunct = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._preposition) && (item.order == order_indirect_object)) preposition = item.term;
                });
                bool similarity = false;
                if (adjunct != string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, preposition, adjunct);
                else similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, preposition, noun);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObject(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, byte[] order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify indirect object \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_article = this._wordEmbeddingService.Encode(this._article, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);

                byte[] morphology_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);

                byte[]? noun = null;
                byte[]? adjective = null;
                byte[]? article = null;
                byte[]? numeral = null;
                byte[]? pronoun = null;

                byte[]? preposition = null;
                byte[]? adnominal = null;

                foreach (Instruction item in words)
                {
                    if (!item.order.AsSpan().SequenceEqual(order)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_article))) article = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_numeral))) numeral = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                        && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.kind.AsSpan().SequenceEqual(morphology_preposition))) preposition = item.term;
                }

                if (noun != null)
                    adnominal = noun;
                if ((noun != null) && (adjective != null))
                    adnominal = adjective;
                if ((noun != null) && (article != null))
                    adnominal = article;
                if ((noun != null) && (numeral != null))
                    adnominal = numeral;
                if ((noun != null) && (pronoun != null))
                    adnominal = pronoun;

                bool similarity = false;

                similarity = this._wordEmbeddingService.Similarity(word_2_vec, preposition, adnominal);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyIndirectObjectAdjectiveNoun(List<Word> words, List<Sentenca> sentences, int order_indirect_object)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify indirect object adjective noun \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string adjective = string.Empty;
                string adjunct = string.Empty;
                string preposition = string.Empty;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._preposition) && (item.order == order_indirect_object)) preposition = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_noun) && (item.order == order_indirect_object)
                        && ((item.kind == this._article) || (item.kind == this._numeral) || (item.kind == this._pronoun))) adjunct = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_noun) && (item.kind == this._adjective) && (item.order == order_indirect_object)) adjective = item.term;
                });
                bool similarity = false;
                if (adjunct != string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, preposition, adjunct);
                else similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, preposition, adjective);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPredicative(List<Word> words, List<Sentenca> sentences, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify direct object predicative \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string adjective = string.Empty;
                string pronoun = string.Empty;
                string noun = string.Empty;
                int order_object_direct = order_predicative - 1;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_adverb) && (item.kind == this._adjective) && (item.order == order_predicative)) adjective = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._noun) && (item.kind == this._noun) && (item.order == order_object_direct)) noun = item.term;
                    if ((item.sentence == this._predicate) && (item.kind == this._pronoun) && (item.order == order_object_direct)) pronoun = item.term;
                });
                bool similarity = false;
                if (pronoun != string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, pronoun, adjective);
                else similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, noun, adjective);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyDirectObjectPredicative(List<Instruction> words, Dictionary<(byte[], byte[]), int> word_2_vec, byte[] order_direct_object, byte[] order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify direct object predicative \"Syntax\" service failed!");

                byte[] syntax_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                byte[] morphology_adjective = this._wordEmbeddingService.Encode(this._adjective, this._morphology);

                byte[]? adjective = null;

                foreach (Instruction item in words)
                {
                    if (!item.order.AsSpan().SequenceEqual(order_predicative)) continue;

                    if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                        && (item.team.AsSpan().SequenceEqual(morphology_adverbial_adjective))
                        && (item.kind.AsSpan().SequenceEqual(morphology_adjective))) adjective = item.term;
                }

                byte[] morphology_predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] morphology_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                byte[] morphology_pronoun = this._wordEmbeddingService.Encode(this._pronoun, this._morphology);
                byte[] morphology_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                byte[] morphology_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                byte[] morphology_noun = this._wordEmbeddingService.Encode(this._noun, this._morphology);

                List<Instruction> compound_conjunction = words.FindAll(index => index.team.SequenceEqual(morphology_conjunction)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_adnominal = words.FindAll(index => index.team.SequenceEqual(morphology_adnominal_adjunct)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_numeral = words.FindAll(index => index.team.SequenceEqual(morphology_numeral)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_adjective = words.FindAll(index => index.team.SequenceEqual(morphology_adverbial_adjective)
                    && index.sentence.SequenceEqual(morphology_predicate));
                List<Instruction> compound_pronoun = words.FindAll(index => (!index.team.SequenceEqual(morphology_pronoun))
                    && (index.kind.SequenceEqual(morphology_pronoun))
                    && index.sentence.SequenceEqual(morphology_predicate));

                byte[]? noun = null;
                byte[]? noun2 = null;
                byte[]? pronoun = null;
                byte[]? pronoun2 = null;

                bool similarity = false;
                if (((compound_conjunction.Count > 0) && (compound_numeral.Count > 0))
                    || ((compound_conjunction.Count > 0) && (compound_adjective.Count > 0)))
                {
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, adjective);
                    if (similarity) return true;
                }
                if ((compound_conjunction.Count > 0) && (compound_pronoun.Count > 1))
                {
                    int index = 0;
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun)))
                        {
                            if (index == 0) pronoun = item.term;
                            if (index == 1) pronoun2 = item.term;
                        }
                        index++;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, pronoun, adjective);
                    if (similarity) return true;
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, pronoun2, adjective);
                    if (similarity) return true;
                }
                if ((compound_conjunction.Count > 0) && (compound_adnominal.Count > 1))
                {
                    int index = 0;
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun)))
                        {
                            if (index == 0) noun = item.term;
                            if (index == 1) noun2 = item.term;
                        }
                        index++;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, adjective);
                    if (similarity) return true;
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun2, adjective);
                    if (similarity) return true;
                }
                if ((compound_conjunction.Count > 0) && (compound_adnominal.Count > 0) && (compound_pronoun.Count > 0))
                {
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) pronoun = item.term;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, adjective);
                    if (similarity) return true;
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, pronoun, adjective);
                    if (similarity) return true;
                }
                if (compound_conjunction.Count == 0)
                {
                    foreach (Instruction item in words)
                    {
                        if (!item.order.AsSpan().SequenceEqual(order_direct_object)) continue;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_noun))) noun = item.term;

                        if ((item.sentence.AsSpan().SequenceEqual(syntax_predicate))
                            && (!item.team.AsSpan().SequenceEqual(morphology_adnominal_adjunct))
                            && (item.kind.AsSpan().SequenceEqual(morphology_pronoun))) noun = item.term;
                    }
                    similarity = this._wordEmbeddingService.Similarity(word_2_vec, noun, adjective);
                    if (similarity) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private bool VerifyPredicativePreposition(List<Word> words, List<Sentenca> sentences, int order_preposicao)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation verify predicative preposition \"Syntax\" service failed!");

                HashSet<string> vocabulary = this._wordEmbeddingService.Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = this._wordEmbeddingService.Word2Vec(sentences);
                string preposition = string.Empty;
                string adjective = string.Empty;
                string adverb = string.Empty;
                int order_predicative = order_preposicao - 1;
                words.ForEach(item =>
                {
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_adverb) && (item.kind == this._adjective) && (item.order == order_predicative)) adjective = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._adjective_adverb) && (item.kind == this._adverb) && (item.order == order_predicative)) adverb = item.term;
                    if ((item.sentence == this._predicate) && (item.team == this._preposition) && (item.order == order_preposicao)) preposition = item.term;
                });
                bool similarity = false;
                if (adverb != string.Empty) similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, adverb, preposition);
                else similarity = this._wordEmbeddingService.Similarity(word_2_vec, vocabulary, adjective, preposition);
                if (similarity) return true;
                return false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountNounVerb(List<Sentenca> sentences, List<Lesson> matters)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation nount noun verb \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind_verb = new List<string>();
                kind_verb.Add(this._verb);
                List<string> kind_noun = new List<string>();
                kind_noun.Add(this._noun);
                List<Lesson> verbs = new List<Lesson>();
                verbs = FilterLesson(matters, kind_verb);
                List<Lesson> nouns = new List<Lesson>();
                nouns = FilterLesson(matters, kind_noun);
                int order_noun = this._order_1;
                int order_verb = this._order_2;
                foreach (Lesson verb in verbs)
                {
                    foreach (Lesson noun in nouns)
                    {
                        List<Word> words = new List<Word>();
                        verb.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, verb.team, order_verb);
                            words.Add(word);
                        });
                        noun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._subject, noun.team, order_noun);
                            words.Add(word);
                        });
                        if (!VerifyVerbSampleSubject(words, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountNounVerb(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount noun verb \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adverbial_verb = new List<byte[]>();
                byte[] sha_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                kind_adverbial_verb.Add(sha_adverbial_verb);
                List<Tutorial> adverbials_verbs = new List<Tutorial>();
                adverbials_verbs = FilterLesson(tutorials, kind_adverbial_verb);

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                kind_adnominal_adjunct.Add(sha_personal);
                byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                kind_adnominal_adjunct.Add(sha_demonstrative);
                List<Tutorial> adnominals_adjuncts = new List<Tutorial>();
                adnominals_adjuncts = FilterLesson(tutorials, kind_adnominal_adjunct);

                byte[] subject = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_noun = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_verb = this._wordEmbeddingService.Encode(this._order_2, this._order);

                foreach (Tutorial adverbial_verb in adverbials_verbs)
                {
                    foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                    {
                        List<Instruction> words = new List<Instruction>();
                        foreach (Instruction item in adverbial_verb.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                            words.Add(word);
                        }
                        ;
                        foreach (Instruction item in adnominal_adjunct.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, subject, adnominal_adjunct.team, order_noun);
                            words.Add(word);
                        }
                        if (!VerifyVerbSampleSubject(words, word_2_vec, Level.AsSpanSequence, this._order_1, this._order_2)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountPronounVerb(List<Sentenca> sentences, List<Lesson> matters)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount pronoun verb \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind_verb = new List<string>();
                kind_verb.Add(this._verb);
                List<string> kind_pronoun = new List<string>();
                kind_pronoun.Add(this._personal);
                kind_pronoun.Add(this._demonstrative);
                List<Lesson> verbs = new List<Lesson>();
                verbs = FilterLesson(matters, kind_verb);
                List<Lesson> pronouns = new List<Lesson>();
                pronouns = FilterLesson(matters, kind_pronoun);
                int order_pronoun = this._order_1;
                int order_verb = this._order_2;
                foreach (Lesson verb in verbs)
                {
                    foreach (Lesson pronoun in pronouns)
                    {
                        List<Word> words = new List<Word>();
                        verb.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, verb.team, order_verb);
                            words.Add(word);
                        });
                        pronoun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._subject, pronoun.team, order_pronoun);
                            words.Add(word);
                        });
                        if (!VerifyVerbSampleSubject(words, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountCompoundVerb(List<Sentenca> sentences, List<Lesson> matters)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount compound verb \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind_verb = new List<string>();
                kind_verb.Add(this._verb);
                List<string> kind_noun = new List<string>();
                kind_noun.Add(this._noun);
                kind_noun.Add(this._personal);
                kind_noun.Add(this._adjective_noun);
                List<string> kind_conjunction = new List<string>();
                kind_conjunction.Add(this._conjunction);
                List<Lesson> verbs = new List<Lesson>();
                verbs = FilterLesson(matters, kind_verb);
                List<Lesson> nouns = new List<Lesson>();
                nouns = FilterLesson(matters, kind_noun);
                List<Lesson> conjunctions = new List<Lesson>();
                conjunctions = FilterLesson(matters, kind_conjunction);
                List<Lesson> lasts = new List<Lesson>();
                lasts = FilterLesson(matters, kind_noun);
                int order_noun = this._order_1;
                int order_conjunction = this._order_2;
                int order_last = this._order_3;
                int order_verb = this._order_4;
                foreach (Lesson verb in verbs)
                {
                    foreach (Lesson conjunction in conjunctions)
                    {
                        foreach (Lesson noun in nouns)
                        {
                            foreach (Lesson last in lasts)
                            {
                                List<Word> words = new List<Word>();
                                verb.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, verb.team, order_verb);
                                    words.Add(word);
                                });
                                noun.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._subject, noun.team, order_noun);
                                    words.Add(word);
                                });
                                last.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._subject, last.team, order_last);
                                    words.Add(word);
                                });
                                conjunction.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._subject, conjunction.team, order_conjunction);
                                    words.Add(word);
                                });
                                if (!VerifyVerbCompoundSubject(words, sentences)) continue;
                                Lesson lesson = new Lesson();
                                lesson.lecture = words;
                                lessons.Add(lesson);
                            }
                        }
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountCompoundVerb(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount compound verb \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                byte[] sha_personal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                kind_adnominal_adjunct.Add(sha_personal);
                byte[] sha_demonstrative = this._wordEmbeddingService.Encode(this._demonstrative, this._morphology);
                kind_adnominal_adjunct.Add(sha_demonstrative);
                List<Tutorial> adnominals_firsts = new List<Tutorial>();
                adnominals_firsts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<Tutorial> adnominals_lasts = new List<Tutorial>();
                adnominals_lasts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_adverbial_verb = new List<byte[]>();
                byte[] sha_adverbial_verb = this._wordEmbeddingService.Encode(this._adverbial_verb, this._morphology);
                kind_adverbial_verb.Add(sha_adverbial_verb);
                List<Tutorial> adverbials_verbs = new List<Tutorial>();
                adverbials_verbs = FilterLesson(tutorials, kind_adverbial_verb);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] subject = this._wordEmbeddingService.Encode(this._subject, this._syntax);
                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_noun = this._wordEmbeddingService.Encode(this._order_1, this._order);
                byte[] order_verb = this._wordEmbeddingService.Encode(this._order_2, this._order);

                foreach (Tutorial adverbial_verb in adverbials_verbs)
                {
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adnominal_first in adnominals_firsts)
                        {
                            foreach (Tutorial adnominal_last in adnominals_lasts)
                            {
                                List<Instruction> words = new List<Instruction>();
                                List<Instruction> firsts = new List<Instruction>();
                                List<Instruction> lasts = new List<Instruction>();
                                words.ForEach(item => words.Add(item));
                                foreach (Instruction item in adverbial_verb.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adverbial_verb.team, order_verb);
                                    words.Add(word);
                                }
                                foreach (Instruction item in adnominal_last.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, subject, adnominal_last.team, order_noun);
                                    words.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Instruction item in adnominal_first.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, subject, adnominal_first.team, order_noun);
                                    words.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, subject, conjunction.team, order_noun);
                                    words.Add(word);
                                }
                                if (!VerifyVerbCompoundSubject(words, firsts, lasts, word_2_vec)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbNoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._noun);
                List<Lesson> nouns = new List<Lesson>();
                nouns = FilterLesson(matters, kind);
                if (nouns.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson noun in nouns)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        noun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, noun.team, order_noun);
                            words1.Add(word);
                        });
                        if (!VerifyVerbDirectObject(words1, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                byte[] sha_possessive = this._wordEmbeddingService.Encode(this._possessive, this._morphology);
                kind_adnominal_adjunct.Add(sha_possessive);
                byte[] sha_pessoal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                kind_adnominal_adjunct.Add(sha_pessoal);
                List<Tutorial> adnominals_adjunts = new List<Tutorial>();
                adnominals_adjunts = FilterLesson(tutorials, kind_adnominal_adjunct);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_noun = this._wordEmbeddingService.Encode(order, this._order);

                if (adnominals_adjunts.Count == 0) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adnominal_adjunt in adnominals_adjunts)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in adnominal_adjunt.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunt.team, order_noun);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyVerbDirectObject(words1, word_2_vec)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbPronoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_pronoun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb pronoun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._possessive);
                List<Lesson> pronouns = new List<Lesson>();
                pronouns = FilterLesson(matters, kind);
                if (pronouns.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson pronoun in pronouns)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        pronoun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, pronoun.team, order_pronoun);
                            words1.Add(word);
                        });
                        if (!VerifyVerbDirectObject(words1, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbAdjectiveNoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_adjective_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective noun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._adjective_noun);
                List<Lesson> adjectives_nouns = new List<Lesson>();
                adjectives_nouns = FilterLesson(matters, kind);
                if (adjectives_nouns.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adjective_noun in adjectives_nouns)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        adjective_noun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, adjective_noun.team, order_adjective_noun);
                            words1.Add(word);
                        });
                        if (!VerifyVerbAdjectiveNoun(words1, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbAdjectiveNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adjective_noun = new List<byte[]>();
                byte[] ssh_adjective_noun = this._wordEmbeddingService.Encode(this._adjective_noun, this._morphology);
                kind_adjective_noun.Add(ssh_adjective_noun);
                List<Tutorial> adjectives_nouns = new List<Tutorial>();
                adjectives_nouns = FilterLesson(tutorials, kind_adjective_noun);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_adjective_noun = this._wordEmbeddingService.Encode(order, this._order);

                if (adjectives_nouns.Count == 0) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adjective_noun in adjectives_nouns)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Instruction item in adjective_noun.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adjective_noun.team, order_adjective_noun);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyVerbAdjectiveNoun(words1, word_2_vec)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountPredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount predicative \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._adjective_adverb);
                List<Lesson> adjectives = new List<Lesson>();
                adjectives = FilterLesson(matters, kind);
                if (adjectives.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adjective in adjectives)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        adjective.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, adjective.team, order_predicative);
                            words1.Add(word);
                        });
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbAdjective(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_adjective)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._adjective_adverb);
                List<Lesson> adjectives = new List<Lesson>();
                adjectives = FilterLesson(matters, kind);
                if (adjectives.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adjective in adjectives)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        adjective.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, adjective.team, order_adjective);
                            words1.Add(word);
                        });
                        if (!VerifyVerbPredicative(words1, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbAdjective(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adverbial_adjective = new List<byte[]>();
                byte[] sha_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                kind_adverbial_adjective.Add(sha_adverbial_adjective);
                List<Tutorial> adverbials_adjectives = new List<Tutorial>();
                adverbials_adjectives = FilterLesson(tutorials, kind_adverbial_adjective);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_adjective = this._wordEmbeddingService.Encode(order, this._order);

                if (adverbials_adjectives.Count == 0) return seminars;
                foreach (Tutorial source in tutorials)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adverbial_adjective in adverbials_adjectives)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in adverbial_adjective.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_adjective);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyVerbPredicative(words1, word_2_vec)) continue;
                        Tutorial tutorial = new Tutorial();
                        tutorial.lecture = words1;
                        tutorials.Add(tutorial);
                    }
                }
                return tutorials;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountObjectPredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount object predicative \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._adjective_adverb);
                List<Lesson> adjectives = new List<Lesson>();
                adjectives = FilterLesson(matters, kind);
                if (adjectives.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adjective in adjectives)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        adjective.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, adjective.team, order_predicative);
                            words1.Add(word);
                        });
                        if (!VerifyDirectObjectPredicative(words1, sentences, order_predicative)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountObjectPredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_sample, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount object predicative \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adverbial_adjective = new List<byte[]>();
                byte[] sha_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                kind_adverbial_adjective.Add(sha_adverbial_adjective);
                List<Tutorial> adverbials_adjectives = new List<Tutorial>();
                adverbials_adjectives = FilterLesson(tutorials, kind_adverbial_adjective);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_object = this._wordEmbeddingService.Encode(order_sample, this._order);
                byte[] order_predicate = this._wordEmbeddingService.Encode(order_predicative, this._order);

                if (adverbials_adjectives.Count == 0) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adverbial_adjective in adverbials_adjectives)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Instruction item in adverbial_adjective.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_predicate);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyDirectObjectPredicative(words1, word_2_vec, order_object, order_predicate)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountAdjectivePreposition(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount adjective preposition \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._preposition);
                List<Lesson> prepositions = new List<Lesson>();
                prepositions = FilterLesson(matters, kind);
                if (prepositions.Count == 0) return lessons;
                int order_direct_object = order_preposition - 1;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson preposition in prepositions)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        preposition.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        });
                        if (!VerifyPredicativePreposition(words1, sentences, order_direct_object)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountDirectObjectPreposition(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount preposition \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._preposition);
                List<Lesson> prepositions = new List<Lesson>();
                prepositions = FilterLesson(matters, kind);
                if (prepositions.Count == 0) return lessons;
                int order_direct_object = order_preposition - 1;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson preposition in prepositions)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        preposition.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        });
                        if (!VerifyDirectObjectPreposition(words1, sentences, order_direct_object)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountDirectObjectPreposition(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_direct_object, int order_indirect_object)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount preposition indirect object \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_preposition = new List<byte[]>();
                byte[] sha_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                kind_preposition.Add(sha_preposition);
                List<Tutorial> prepositions = new List<Tutorial>();
                prepositions = FilterLesson(tutorials, kind_preposition);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order = this._wordEmbeddingService.Encode(order_direct_object, this._order);
                byte[] order_preposition = this._wordEmbeddingService.Encode(order_indirect_object, this._order);

                if (prepositions.Count == 0) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial preposition in prepositions)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));
                        foreach (Instruction item in preposition.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyDirectObjectPreposition(words1, word_2_vec, order, order_preposition)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_preposition)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._preposition);
                List<Lesson> prepositions = new List<Lesson>();
                prepositions = FilterLesson(matters, kind);
                if (prepositions.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson preposition in prepositions)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        preposition.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        });
                        if (!VerifyVerbIndirectObject(words1, sentences)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbIndirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb indirect object \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_preposition = new List<byte[]>();
                byte[] sha_preposition = this._wordEmbeddingService.Encode(this._preposition, this._morphology);
                kind_preposition.Add(sha_preposition);
                List<Tutorial> prepositions = new List<Tutorial>();
                prepositions = FilterLesson(tutorials, kind_preposition);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_preposition = this._wordEmbeddingService.Encode(order, this._order);

                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial preposition in prepositions)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Instruction item in preposition.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, preposition.team, order_preposition);
                            words1.Add(word);
                        }
                        ;
                        if (!VerifyVerbIndirectObject(words1, word_2_vec)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountIndirectObjectNoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount indirect object noun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._noun);
                List<Lesson> nouns = new List<Lesson>();
                nouns = FilterLesson(matters, kind);
                if (nouns.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson noun in nouns)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        noun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, noun.team, order_noun);
                            words1.Add(word);
                        });
                        if (!VerifyIndirectObject(words1, sentences, order_noun)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountDirectObjectIndirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount indirect object noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                byte[] sha_possessive = this._wordEmbeddingService.Encode(this._possessive, this._morphology);
                kind_adnominal_adjunct.Add(sha_possessive);
                byte[] sha_pessoal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                kind_adnominal_adjunct.Add(sha_pessoal);
                List<Tutorial> adnominals_adjuncts = new List<Tutorial>();
                adnominals_adjuncts = FilterLesson(tutorials, kind_adnominal_adjunct);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_indirect_object = this._wordEmbeddingService.Encode(order, this._order);

                if (adnominals_adjuncts.Count == 0) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                    {
                        List<Instruction> words1 = new List<Instruction>();
                        words.ForEach(item => words1.Add(item));

                        foreach (Instruction item in adnominal_adjunct.lecture)
                        {
                            Instruction word = new Instruction();
                            word = Lecture(item.term, item.kind, predicate, adnominal_adjunct.team, order_indirect_object);
                            words1.Add(word);
                        }
                        if (!VerifyIndirectObject(words1, word_2_vec, order_indirect_object)) continue;
                        Tutorial seminar = new Tutorial();
                        seminar.lecture = words1;
                        seminars.Add(seminar);
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountIndirectObjectPronoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_pronoun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount indirect object pronoun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._possessive);
                List<Lesson> pronouns = new List<Lesson>();
                pronouns = FilterLesson(matters, kind);
                if (pronouns.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson pronoun in pronouns)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        pronoun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, pronoun.team, order_pronoun);
                            words1.Add(word);
                        });
                        if (!VerifyIndirectObject(words1, sentences, order_pronoun)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountIndirectObjectAdjectiveNoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_adjective_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount indirect object adjective noun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._adjective_noun);
                List<Lesson> adjectives_nouns = new List<Lesson>();
                adjectives_nouns = FilterLesson(matters, kind);
                if (adjectives_nouns.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson adjective_noun in adjectives_nouns)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        adjective_noun.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, adjective_noun.team, order_adjective_noun);
                            words1.Add(word);
                        });
                        if (!VerifyIndirectObjectAdjectiveNoun(words1, sentences, order_adjective_noun)) continue;
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountConjunction(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_conjunction)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount conjunction \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind = new List<string>();
                kind.Add(this._conjunction);
                List<Lesson> conjunctions = new List<Lesson>();
                conjunctions = FilterLesson(matters, kind);
                if (conjunctions.Count == 0) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson conjunction in conjunctions)
                    {
                        List<Word> words1 = new List<Word>();
                        words.ForEach(item =>
                        {
                            words1.Add(item);
                        });
                        conjunction.lecture.ForEach(item =>
                        {
                            Word word = new Word();
                            word = Lecture(item.term, item.kind, this._predicate, conjunction.team, order_conjunction);
                            words1.Add(word);
                        });
                        Lesson lesson = new Lesson();
                        lesson.lecture = words1;
                        lessons.Add(lesson);
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbNumeralConjunctionNoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb numeral conjunction noun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind_noun = new List<string>();
                kind_noun.Add(this._numeral_noun);
                List<string> kind_numeral = new List<string>();
                kind_numeral.Add(this._numeral);
                List<string> kind_conjunction = new List<string>();
                kind_conjunction.Add(this._conjunction);
                List<Lesson> nouns = new List<Lesson>();
                nouns = FilterLesson(matters, kind_noun);
                List<Lesson> numerals = new List<Lesson>();
                numerals = FilterLesson(matters, kind_numeral);
                List<Lesson> conjunctions = new List<Lesson>();
                conjunctions = FilterLesson(matters, kind_conjunction);
                if ((nouns.Count == 0) || (numerals.Count == 0) || (conjunctions.Count == 0)) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson conjunction in conjunctions)
                    {
                        foreach (Lesson numeral in numerals)
                        {
                            foreach (Lesson noun in nouns)
                            {
                                List<Word> words1 = new List<Word>();
                                words.ForEach(item =>
                                {
                                    words1.Add(item);
                                });
                                noun.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, noun.team, order_noun);
                                    words1.Add(word);
                                });
                                numeral.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, numeral.team, order_noun);
                                    words1.Add(word);
                                });
                                conjunction.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, conjunction.team, order_noun);
                                    words1.Add(word);
                                });
                                if (!VerifyNumeralConjunctionNoun(words1, sentences, order_noun)) continue;
                                Lesson lesson = new Lesson();
                                lesson.lecture = words1;
                                lessons.Add(lesson);
                            }
                        }
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbNumeralConjunctionNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb numeral conjunction noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                List<Tutorial> adnominals_adjuncts = new List<Tutorial>();
                adnominals_adjuncts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_numeral = new List<byte[]>();
                byte[] sha_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                kind_numeral.Add(sha_numeral);
                List<Tutorial> numerals = new List<Tutorial>();
                numerals = FilterLesson(tutorials, kind_numeral);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order, this._order);

                if ((adnominals_adjuncts.Count == 0) || (numerals.Count == 0) || (conjunctions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial numeral in numerals)
                        {
                            foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_adjunct.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_adjunct.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in numeral.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, numeral.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                if (!VerifyVerbNumeralConjunctionNoun(words1, word_2_vec)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountPrepositionNumeralConjunctionNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb numeral conjunction noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                List<Tutorial> adnominals_adjuncts = new List<Tutorial>();
                adnominals_adjuncts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_numeral = new List<byte[]>();
                byte[] sha_numeral = this._wordEmbeddingService.Encode(this._numeral, this._morphology);
                kind_numeral.Add(sha_numeral);
                List<Tutorial> numerals = new List<Tutorial>();
                numerals = FilterLesson(tutorials, kind_numeral);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order, this._order);

                if ((adnominals_adjuncts.Count == 0) || (numerals.Count == 0) || (conjunctions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial numeral in numerals)
                        {
                            foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_adjunct.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_adjunct.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in numeral.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, numeral.team, order_compound);
                                    words1.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound);
                                    words1.Add(word);
                                }
                                if (!VerifyPrepositionNumeralConjunctionNoun(words1, word_2_vec, order_compound)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Lesson> MountVerbAdjectiveConjunctionNoun(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_noun)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective conjunction noun \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<string> kind_noun = new List<string>();
                kind_noun.Add(this._adjective_noun);
                List<string> kind_adjective = new List<string>();
                kind_adjective.Add(this._adjective);
                List<string> kind_conjunction = new List<string>();
                kind_conjunction.Add(this._conjunction);
                List<Lesson> nouns = new List<Lesson>();
                nouns = FilterLesson(matters, kind_noun);
                List<Lesson> adjectives = new List<Lesson>();
                adjectives = FilterLesson(matters, kind_adjective);
                List<Lesson> conjunctions = new List<Lesson>();
                conjunctions = FilterLesson(matters, kind_conjunction);
                if ((nouns.Count == 0) || (adjectives.Count == 0) || (conjunctions.Count == 0)) return lessons;
                foreach (Lesson source in sources)
                {
                    List<Word> words = source.lecture;
                    foreach (Lesson conjunction in conjunctions)
                    {
                        foreach (Lesson adjective in adjectives)
                        {
                            foreach (Lesson noun in nouns)
                            {
                                List<Word> words1 = new List<Word>();
                                words.ForEach(item =>
                                {
                                    words1.Add(item);
                                });
                                noun.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, noun.team, order_noun);
                                    words1.Add(word);
                                });
                                adjective.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, adjective.team, order_noun);
                                    words1.Add(word);
                                });
                                conjunction.lecture.ForEach(item =>
                                {
                                    Word word = new Word();
                                    word = Lecture(item.term, item.kind, this._predicate, conjunction.team, order_noun);
                                    words1.Add(word);
                                });
                                if (!VerifyAdjectiveConjunctionNoun(words1, sentences, order_noun)) continue;
                                Lesson lesson = new Lesson();
                                lesson.lecture = words1;
                                lessons.Add(lesson);
                            }
                        }
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbAdjectiveConjunctionNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective conjunction noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                List<Tutorial> adnominals_adjuncts = new List<Tutorial>();
                adnominals_adjuncts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_adverbial_adjective = new List<byte[]>();
                byte[] sha_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                kind_adverbial_adjective.Add(sha_adverbial_adjective);
                List<Tutorial> adverbials_adjectives = new List<Tutorial>();
                adverbials_adjectives = FilterLesson(tutorials, kind_adverbial_adjective);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_noun = this._wordEmbeddingService.Encode(order, this._order);

                if ((adnominals_adjuncts.Count == 0) || (adverbials_adjectives.Count == 0) || (conjunctions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adverbial_adjective in adverbials_adjectives)
                        {
                            foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_adjunct.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_adjunct.team, order_noun);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in adverbial_adjective.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_noun);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_noun);
                                    words1.Add(word);
                                }
                                ;
                                if (!VerifyVerbAdjectiveConjunctionNoun(words1, word_2_vec)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountPrepositionAdjectiveConjunctionNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb adjective conjunction noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                List<Tutorial> adnominals_adjuncts = new List<Tutorial>();
                adnominals_adjuncts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_adverbial_adjective = new List<byte[]>();
                byte[] sha_adverbial_adjective = this._wordEmbeddingService.Encode(this._adverbial_adjective, this._morphology);
                kind_adverbial_adjective.Add(sha_adverbial_adjective);
                List<Tutorial> adverbials_adjectives = new List<Tutorial>();
                adverbials_adjectives = FilterLesson(tutorials, kind_adverbial_adjective);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order, this._order);

                if ((adnominals_adjuncts.Count == 0) || (adverbials_adjectives.Count == 0) || (conjunctions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adverbial_adjective in adverbials_adjectives)
                        {
                            foreach (Tutorial adnominal_adjunct in adnominals_adjuncts)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_adjunct.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_adjunct.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in adverbial_adjective.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adverbial_adjective.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                if (!VerifyPrepositionAdjectiveConjunctionNoun(words1, word_2_vec, order_compound)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountVerbNounConjunctionNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                byte[] sha_possessive = this._wordEmbeddingService.Encode(this._possessive, this._morphology);
                kind_adnominal_adjunct.Add(sha_possessive);
                byte[] sha_pessoal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                kind_adnominal_adjunct.Add(sha_pessoal);
                List<Tutorial> adnominals_firsts = new List<Tutorial>();
                adnominals_firsts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<Tutorial> adnominals_lasts = new List<Tutorial>();
                adnominals_lasts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order, this._order);

                if ((adnominals_firsts.Count == 0) || (adnominals_lasts.Count == 0) || (conjunctions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adnominal_first in adnominals_firsts)
                        {
                            foreach (Tutorial adnominal_last in adnominals_lasts)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                List<Instruction> firsts = new List<Instruction>();
                                List<Instruction> lasts = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_first.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Instruction item in adnominal_last.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound);
                                    words1.Add(word);
                                }
                                if (!VerifyVerbNounConjunctionNoun(words1, firsts, lasts, word_2_vec)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private List<Tutorial> MountPrepositionNounConjunctionNoun(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation mount verb noun conjunction noun \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<byte[]> kind_adnominal_adjunct = new List<byte[]>();
                byte[] sha_adnominal_adjunct = this._wordEmbeddingService.Encode(this._adnominal_adjunct, this._morphology);
                kind_adnominal_adjunct.Add(sha_adnominal_adjunct);
                byte[] sha_possessive = this._wordEmbeddingService.Encode(this._possessive, this._morphology);
                kind_adnominal_adjunct.Add(sha_possessive);
                byte[] sha_pessoal = this._wordEmbeddingService.Encode(this._personal, this._morphology);
                kind_adnominal_adjunct.Add(sha_pessoal);
                List<Tutorial> adnominals_firsts = new List<Tutorial>();
                adnominals_firsts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<Tutorial> adnominals_lasts = new List<Tutorial>();
                adnominals_lasts = FilterLesson(tutorials, kind_adnominal_adjunct);

                List<byte[]> kind_conjunction = new List<byte[]>();
                byte[] sha_conjunction = this._wordEmbeddingService.Encode(this._conjunction, this._morphology);
                kind_conjunction.Add(sha_conjunction);
                List<Tutorial> conjunctions = new List<Tutorial>();
                conjunctions = FilterLesson(tutorials, kind_conjunction);

                byte[] predicate = this._wordEmbeddingService.Encode(this._predicate, this._syntax);
                byte[] order_compound = this._wordEmbeddingService.Encode(order, this._order);

                if ((adnominals_firsts.Count == 0) || (adnominals_lasts.Count == 0) || (conjunctions.Count == 0)) return seminars;
                foreach (Tutorial source in sources)
                {
                    List<Instruction> words = source.lecture;
                    foreach (Tutorial conjunction in conjunctions)
                    {
                        foreach (Tutorial adnominal_first in adnominals_firsts)
                        {
                            foreach (Tutorial adnominal_last in adnominals_lasts)
                            {
                                List<Instruction> words1 = new List<Instruction>();
                                List<Instruction> firsts = new List<Instruction>();
                                List<Instruction> lasts = new List<Instruction>();
                                words.ForEach(item => words1.Add(item));
                                foreach (Instruction item in adnominal_first.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_first.team, order_compound);
                                    words1.Add(word);
                                    firsts.Add(word);
                                }
                                foreach (Instruction item in adnominal_last.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, adnominal_last.team, order_compound);
                                    words1.Add(word);
                                    lasts.Add(word);
                                }
                                foreach (Instruction item in conjunction.lecture)
                                {
                                    Instruction word = new Instruction();
                                    word = Lecture(item.term, item.kind, predicate, conjunction.team, order_compound);
                                    words1.Add(word);
                                }
                                ;
                                if (!VerifyPrepositionNounConjunctionNoun(words1, firsts, lasts, word_2_vec, order_compound)) continue;
                                Tutorial seminar = new Tutorial();
                                seminar.lecture = words1;
                                seminars.Add(seminar);
                            }
                        }
                    }
                }
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> SampleSubjectVerb(List<Sentenca> sentences, List<Lesson> matters)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation sample subject verb \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountNounVerb(sentences, matters);
                lessons = Union(lessons, MountPronounVerb(sentences, matters));
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> SampleSubjectVerb(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation sample subject verb \"Syntax\" view model failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                seminars = MountNounVerb(tutorials, word_2_vec);
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> CompoundSubjectVerb(List<Sentenca> sentences, List<Lesson> matters)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation compound subject verb \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountCompoundVerb(sentences, matters);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> CompoundSubjectVerb(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation compound subject verb \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                seminars = MountCompoundVerb(tutorials, word_2_vec);
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateDirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate direct object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountVerbNoun(sentences, matters, sources, order_init);
                lessons = Union(lessons, MountVerbPronoun(sentences, matters, sources, order_init));
                lessons = Union(lessons, MountVerbAdjectiveNoun(sentences, matters, sources, order_init));
                lessons = Union(lessons, MountVerbNumeralConjunctionNoun(sentences, matters, sources, order_init));
                lessons = Union(lessons, MountVerbAdjectiveConjunctionNoun(sentences, matters, sources, order_init));
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> PredicateDirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate direct object \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                seminars = MountVerbNoun(tutorials, word_2_vec, sources, order_init);
                seminars = Union(seminars, MountVerbNumeralConjunctionNoun(tutorials, word_2_vec, sources, order_init));
                seminars = Union(seminars, MountVerbAdjectiveConjunctionNoun(tutorials, word_2_vec, sources, order_init));
                seminars = Union(seminars, MountVerbNounConjunctionNoun(tutorials, word_2_vec, sources, order_init));

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicatePredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate predicative \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountVerbAdjective(sentences, matters, sources, order_init);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> PredicatePredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate predicative \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                seminars = MountVerbAdjective(tutorials, word_2_vec, sources, order_init);
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int init_order)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountVerbIndirectObject(sentences, matters, sources, init_order);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> PredicateIndirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();
                seminars = MountVerbIndirectObject(tutorials, word_2_vec, sources, order_init);
                seminars = Union(seminars, MountVerbNoun(tutorials, word_2_vec, seminars, order_init));
                seminars = Union(seminars, MountVerbNumeralConjunctionNoun(tutorials, word_2_vec, seminars, order_init));
                seminars = Union(seminars, MountVerbAdjectiveConjunctionNoun(tutorials, word_2_vec, seminars, order_init));
                seminars = Union(seminars, MountVerbNounConjunctionNoun(tutorials, word_2_vec, seminars, order_init));
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateDirectObjectIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate direct object indirect object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();

                List<Lesson> prepositions = new List<Lesson>();
                prepositions = MountDirectObjectPreposition(sentences, matters, sources, order_init);
                List<Lesson> nouns = new List<Lesson>();
                nouns = MountIndirectObjectNoun(sentences, matters, prepositions, order_init);
                List<Lesson> pronouns = new List<Lesson>();
                pronouns = MountIndirectObjectPronoun(sentences, matters, prepositions, order_init);
                List<Lesson> adjectives_nouns = new List<Lesson>();
                adjectives_nouns = MountIndirectObjectAdjectiveNoun(sentences, matters, prepositions, order_init);

                List<Lesson> conjunctios_numerals_nouns = new List<Lesson>();
                conjunctios_numerals_nouns = MountVerbNumeralConjunctionNoun(sentences, matters, prepositions, order_init);
                List<Lesson> conjunctions_adjectives_nouns = new List<Lesson>();
                conjunctions_adjectives_nouns = MountVerbAdjectiveConjunctionNoun(sentences, matters, prepositions, order_init);

                lessons = Union(nouns, pronouns);
                lessons = Union(lessons, adjectives_nouns);
                lessons = Union(lessons, conjunctios_numerals_nouns);
                lessons = Union(lessons, conjunctions_adjectives_nouns);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> PredicateDirectObjectIndirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_direct_object, int order_indirect_object)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate direct object indirect object \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                List<Tutorial> prepositions = new List<Tutorial>();
                prepositions = MountDirectObjectPreposition(tutorials, word_2_vec, sources, order_direct_object, order_indirect_object);

                List<Tutorial> adnominals_adjunts = new List<Tutorial>();
                adnominals_adjunts = MountDirectObjectIndirectObject(tutorials, word_2_vec, prepositions, order_indirect_object);

                List<Tutorial> numerals_nouns = new List<Tutorial>();
                numerals_nouns = MountPrepositionNumeralConjunctionNoun(tutorials, word_2_vec, prepositions, order_indirect_object);

                List<Tutorial> adjectives_nouns = new List<Tutorial>();
                adjectives_nouns = MountPrepositionAdjectiveConjunctionNoun(tutorials, word_2_vec, prepositions, order_indirect_object);

                List<Tutorial> nouns_nouns = new List<Tutorial>();
                nouns_nouns = MountPrepositionNounConjunctionNoun(tutorials, word_2_vec, prepositions, order_indirect_object);

                seminars = Union(adnominals_adjunts, numerals_nouns);
                seminars = Union(seminars, adjectives_nouns);
                seminars = Union(seminars, nouns_nouns);

                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateDirectObjectPredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object predicative \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountObjectPredicative(sentences, matters, sources, order_init);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> PredicateDirectObjectPredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_sample, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object predicative \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                seminars = MountObjectPredicative(tutorials, word_2_vec, sources, order_sample, order_predicative);
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateIndirectObjectPredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object predicative \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                lessons = MountObjectPredicative(sentences, matters, sources, order_init);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Tutorial> PredicateIndirectObjectPredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_sample, int order_predicative)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object predicative \"Syntax\" service failed!");

                List<Tutorial> seminars = new List<Tutorial>();

                seminars = MountObjectPredicative(tutorials, word_2_vec, sources, order_sample, order_predicative);
                return seminars;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicatePredicativeIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate predicative indirect object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                List<Lesson> prepositions = new List<Lesson>();
                prepositions = MountAdjectivePreposition(sentences, matters, sources, order_init);

                List<Lesson> nouns = new List<Lesson>();
                nouns = MountIndirectObjectNoun(sentences, matters, prepositions, order_init);
                List<Lesson> pronouns = new List<Lesson>();
                pronouns = MountIndirectObjectPronoun(sentences, matters, sources, order_init);
                List<Lesson> adjectives_nouns = new List<Lesson>();
                adjectives_nouns = MountIndirectObjectAdjectiveNoun(sentences, matters, sources, order_init);
                List<Lesson> conjunctions_numerals_nouns = new List<Lesson>();
                conjunctions_numerals_nouns = MountVerbNumeralConjunctionNoun(sentences, matters, sources, order_init);
                List<Lesson> conjunctions_adjectives_nouns = new List<Lesson>();
                conjunctions_adjectives_nouns = MountVerbNumeralConjunctionNoun(sentences, matters, sources, order_init);

                lessons = Union(nouns, pronouns);
                lessons = Union(lessons, adjectives_nouns);
                lessons = Union(lessons, conjunctions_numerals_nouns);
                lessons = Union(lessons, conjunctions_adjectives_nouns);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateDirectObjectDirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate direct object direct object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                int order_last = order_init + 1;

                List<string> kind_noun = new List<string>();
                kind_noun.Add(this._noun);
                kind_noun.Add(this._adjective_noun);
                List<Lesson> substantives = new List<Lesson>();
                substantives = FilterLesson(sources, kind_noun);

                List<Lesson> nouns = new List<Lesson>();
                nouns = MountVerbNoun(sentences, matters, substantives, order_last);
                List<Lesson> adjectives_nouns = new List<Lesson>();
                adjectives_nouns = MountVerbAdjectiveNoun(sentences, matters, substantives, order_last);
                List<Lesson> conjunctions_nouns = new List<Lesson>();
                conjunctions_nouns = Union(nouns, adjectives_nouns);
                conjunctions_nouns = MountConjunction(sentences, matters, conjunctions_nouns, order_init);

                List<string> kind_pronoun = new List<string>();
                kind_pronoun.Add(this._pronoun);
                List<Lesson> surrogates = new List<Lesson>();
                surrogates = FilterLesson(sources, kind_pronoun);

                List<Lesson> pronouns = new List<Lesson>();
                pronouns = MountVerbPronoun(sentences, matters, surrogates, order_last);
                List<Lesson> conjunctions_pronouns = new List<Lesson>();
                conjunctions_pronouns = MountConjunction(sentences, matters, conjunctions_pronouns, order_init);

                lessons = Union(conjunctions_nouns, conjunctions_pronouns);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicateIndirectObjectIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate indirect object indirect object \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                int order_last = order_init + 1;

                List<string> kind_noun = new List<string>();
                kind_noun.Add(this._noun);
                kind_noun.Add(this._adjective_noun);
                List<Lesson> substantives = new List<Lesson>();
                substantives = FilterLesson(sources, kind_noun);

                List<Lesson> nouns = new List<Lesson>();
                nouns = MountVerbNoun(sentences, matters, substantives, order_last);
                List<Lesson> adjectives_nouns = new List<Lesson>();
                adjectives_nouns = MountVerbAdjectiveNoun(sentences, matters, substantives, order_last);
                List<Lesson> conjunctions_nouns = new List<Lesson>();
                conjunctions_nouns = Union(nouns, adjectives_nouns);
                conjunctions_nouns = MountDirectObjectPreposition(sentences, matters, conjunctions_nouns, order_last);
                conjunctions_nouns = MountConjunction(sentences, matters, conjunctions_nouns, order_init);

                List<string> kind_pronoun = new List<string>();
                kind_pronoun.Add(this._pronoun);
                List<Lesson> surrogates = new List<Lesson>();
                surrogates = FilterLesson(sources, kind_pronoun);

                List<Lesson> pronouns = new List<Lesson>();
                pronouns = MountVerbPronoun(sentences, matters, surrogates, order_last);
                List<Lesson> conjunctions_pronouns = new List<Lesson>();
                conjunctions_pronouns = MountDirectObjectPreposition(sentences, matters, conjunctions_pronouns, order_last);
                conjunctions_pronouns = MountConjunction(sentences, matters, conjunctions_pronouns, order_init);

                lessons = Union(conjunctions_nouns, conjunctions_pronouns);
                return lessons;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public List<Lesson> PredicatePredicativePredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation predicate predicative predicative \"Syntax\" service failed!");

                List<Lesson> lessons = new List<Lesson>();
                int order_last = order_init + 1;
                lessons = MountPredicative(sentences, matters, sources, order_last);
                lessons = MountConjunction(sentences, matters, lessons, order_init);
                return lessons;
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
