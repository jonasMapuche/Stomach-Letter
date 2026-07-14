using Letter.Models;

namespace Letter.Repositories
{
    public interface IAdverbioRepository
    {
        Task<List<Adverbios>> GetAll();
        Task<List<Adverbios>> GetSQLAll();
        Task<int> Add(List<Adverbios> adverb);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
