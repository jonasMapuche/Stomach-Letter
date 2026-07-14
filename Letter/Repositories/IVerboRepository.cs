using Letter.Models;

namespace Letter.Repositories
{
    public interface IVerboRepository
    {
        Task<List<Verbos>> GetAll();
        Task<List<Verbos>> GetSQLAll();
        Task<int> Add(List<Verbos> verb);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
