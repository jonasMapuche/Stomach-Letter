using Letter.Models;

namespace Letter.Repositories
{
    public interface ISentencaRepository
    {
        public List<Sentenca> GetLanguage(string language);
        public Task<List<Sentenca>> GetLanguageAsync(string language);
    }
}
