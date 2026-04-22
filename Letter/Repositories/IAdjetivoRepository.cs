using Letter.Models;

namespace Letter.Repositories
{
    public interface IAdjetivoRepository
    {
        Task<List<Adjetivo>> GetAll();
        Task<int> Add(List<Adjetivo> adjective);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
