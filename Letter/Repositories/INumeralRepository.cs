using Letter.Models;

namespace Letter.Repositories
{
    public interface INumeralRepository
    {
        Task<List<Numerais>> GetAll();
        Task<List<Numerais>> GetSQLAll();
        Task<int> Add(List<Numerais> numeral);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
