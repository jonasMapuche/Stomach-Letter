using Letter.Models;

namespace Letter.Repositories
{
    public interface IPreceitoRepository
    {
        public Preceito GetName(string name);
        public List<Preceito> GetLanguage(string language);
        public Task<List<Preceito>> GetLanguageAsync(string language);
    }
}
