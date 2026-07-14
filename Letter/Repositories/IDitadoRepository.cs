using Letter.Models;

namespace Letter.Repositories
{
    public interface IDitadoRepository
    {
        Task<List<Sentencas>> GetAll();
        Task<List<Sentencas>> GetSQLAll();
        Task<int> Add(List<Sentencas> sentence);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
