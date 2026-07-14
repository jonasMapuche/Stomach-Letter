using Letter.Models;

namespace Letter.Repositories
{
    public interface IPronomeRepository
    {
        Task<List<Pronomes>> GetAll();
        Task<List<Pronomes>> GetSQLAll();
        Task<int> Add(List<Pronomes> pronoun);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
