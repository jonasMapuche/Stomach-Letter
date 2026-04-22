using Letter.Models;

namespace Letter.Repositories
{
    public interface ICircunstanciaRepository
    {
        public Circunstancia GetName(string name);
        public List<Circunstancia> GetLanguage(string language);
        public Task<List<Circunstancia>> GetLanguageAsync(string language);
    }
}
