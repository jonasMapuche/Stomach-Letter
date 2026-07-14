using Letter.Models;

namespace Letter.Repositories
{
    public interface IArtigoRepository
    {
        Task<List<Artigos>> GetAll();
        Task<List<Artigos>> GetSQLAll();
        Task<int> Add(List<Artigos> article);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
