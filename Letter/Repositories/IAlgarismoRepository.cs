using Letter.Models;

namespace Letter.Repositories
{
    public interface IAlgarismoRepository
    {
        public List<Algarismo> GetLanguage(string language);
        public Task<List<Algarismo>> GetLanguageAsync(string language);
    }
}
