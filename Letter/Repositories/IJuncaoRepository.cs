using Letter.Models;

namespace Letter.Repositories
{
    public interface IJuncaoRepository
    {
        public List<Juncao> GetLanguage(string language);
        public Task<List<Juncao>> GetLanguageAsync(string language);
    }
}
