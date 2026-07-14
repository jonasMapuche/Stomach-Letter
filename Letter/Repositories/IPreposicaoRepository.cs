using Letter.Models;

namespace Letter.Repositories
{
    public interface IPreposicaoRepository
    {
        Task<List<Preposicoes>> GetAll();
        Task<List<Preposicoes>> GetSQLAll();
        Task<int> Add(List<Preposicoes> model);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
