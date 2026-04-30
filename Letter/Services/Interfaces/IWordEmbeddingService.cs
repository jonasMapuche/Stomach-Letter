using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface IWordEmbeddingService
    {
        Dictionary<(string, string), int> Word2Vec(List<Sentenca> sentences);
        Dictionary<(byte[], byte[]), int> Word2VecSHA256(List<Sentenca> sentences, HashSet<string> vocabulary);
        Dictionary<(int, int), int> Word2VecInt(List<Sentenca> sentences, HashSet<string> vocabulary);
        HashSet<string> Vocabulary(List<Sentenca> sentences);
        bool Similarity(Dictionary<(string, string), int> word_2_vec, HashSet<string> vocabulary, string? target, string? target1);
        bool Similarity(Dictionary<(string, string), int> word_2_vec, string? target, string? target1);
        bool Similarity(Dictionary<(byte[], byte[]), int> word_2_vec, byte[]? target, byte[]? target1);
        bool Similarity(Dictionary<(int, int), int> word_2_vec, int? target, int? target2);
        string RemoveAccent(string input);
        byte[] Encode(string kind, HashSet<string> briefs);
        byte[] Encode(int kind, HashSet<int> briefs);
        int EncodeInt(string kind, HashSet<string> briefs);
        int EncodeInt(int kind, HashSet<int> briefs);
        byte[] HashSHA256(string texto);
        byte[] HashSHA256(int value);
        List<byte[]> VocabularySHA256(HashSet<string> vocabulary);
        List<int> VocabularyInt(HashSet<string> vocabulary);
        List<byte[]> VocabularySHA256(HashSet<int> vocabulary);
        List<int> VocabularyInt(HashSet<int> vocabulary);
    }
}
