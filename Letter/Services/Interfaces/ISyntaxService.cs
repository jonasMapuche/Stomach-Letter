using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface ISyntaxService
    {
        List<Lesson> SampleSubjectVerb(List<Sentenca> sentences, List<Lesson> matters);
        List<Tutorial> SampleSubjectVerb(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec);
        List<Lesson> SampleSubjectVerb<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies) where TKey : notnull;
        List<Lesson> CompoundSubjectVerb(List<Sentenca> sentences, List<Lesson> matters);
        List<Tutorial> CompoundSubjectVerb(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec);
        List<Lesson> CompoundSubjectVerb<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies) where TKey : notnull;
        List<Lesson> PredicateDirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init);
        List<Tutorial> PredicateDirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_init);
        List<Lesson> PredicateDirectObject<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_verb, int order_predicate) where TKey : notnull;
        List<Lesson> PredicatePredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init);
        List<Tutorial> PredicatePredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_init);
        List<Lesson> PredicatePredicative<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_verb, int order_predicate) where TKey : notnull;
        List<Lesson> PredicateIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int init_order);
        List<Tutorial> PredicateIndirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_init);
        List<Lesson> PredicateIndirectObject<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_verb, int order_predicate) where TKey : notnull;
        List<Lesson> PredicateDirectObjectIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init);
        List<Tutorial> PredicateDirectObjectIndirectObject(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_sample, int order_predicative);
        List<Lesson> PredicateDirectObjectIndirectObject<T, TKey, TValue>(List<T> homeworks, Dictionary<(TKey, TValue), int> dictionaries, HashSet<string> vocabularies, List<Lesson> sources, int order_direct_object, int order_indirect_object) where TKey : notnull;
        List<Lesson> PredicateDirectObjectPredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init);
        List<Tutorial> PredicateDirectObjectPredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_sample, int order_predicative);
        List<Lesson> PredicateIndirectObjectPredicative(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init);
        List<Tutorial> PredicateIndirectObjectPredicative(List<Tutorial> tutorials, Dictionary<(byte[], byte[]), int> word_2_vec, List<Tutorial> sources, int order_sample, int order_predicative);
        List<Lesson> PredicatePredicativeIndirectObject(List<Sentenca> sentences, List<Lesson> matters, List<Lesson> sources, int order_init);
        List<Lesson> DecodeLesson(List<Tutorial> tutorials, HashSet<string> vocabulary);
        List<Lesson> DecodeLesson(List<Practice> practices, HashSet<string> vocabulary);
        List<Tutorial> EncodeLesson(List<Lesson> lessons, HashSet<string> vocabulary);
        List<Practice> EncodeLessonInt(List<Lesson> lessons, HashSet<string> vocabulary);
    }
}
