using Letter.Models;

namespace Letter.Repositories
{
    public interface IElocucaoRepository
    {
        public List<Elocucao> GetLanguage(string language);
        public Task<List<Elocucao>> GetLanguageAsync(string language);
        public List<Elocucao> GetModel(string language, string model);
        public Task<List<Elocucao>> GetModelAsync(string language, string model);

    }
}
