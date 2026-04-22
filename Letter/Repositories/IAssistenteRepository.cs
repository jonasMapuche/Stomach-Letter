using Letter.Models;

namespace Letter.Repositories
{
    public interface IAssistenteRepository
    {
        public List<Assistente> GetLanguage(string language);
        public Task<List<Assistente>> GetLanguageAsync(string language);
    }
}
