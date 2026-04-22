using Letter.Models;

namespace Letter.Repositories
{
    public interface IPreposicaoRepository
    {
        Task<List<Preposicoes>> GetAll();
        Task<int> Add(List<Preposicoes> model);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
