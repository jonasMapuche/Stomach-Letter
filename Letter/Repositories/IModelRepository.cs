using Letter.Models;

namespace Letter.Repositories
{
    public interface IModelRepository
    {
        Task<List<Model>> GetAll();
        Task<List<Model>> GetSQLAll();
        Task<int> Add(List<Model> model);
        void CreateTable();
        Task<int> DeleteAll();
        Task<int> DropTable();
        Task<int> ExistAsync();
        int Exist();
    }
}
