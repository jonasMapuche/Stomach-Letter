using Letter.Models;

namespace Letter.Repositories
{
    public interface ISubstantivoRepository
    {
        Task<List<Substantivo>> GetAll();
        Task<int> Add(List<Substantivo> noun);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
