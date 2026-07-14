using Letter.Models;

namespace Letter.Repositories
{
    public interface IConjuncaoRepository
    {
        Task<List<Conjuncoes>> GetAll();
        Task<List<Conjuncoes>> GetSQLAll();
        Task<int> Add(List<Conjuncoes> conjunction);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
