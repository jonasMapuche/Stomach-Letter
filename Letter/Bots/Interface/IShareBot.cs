using Letter.Models;

namespace Letter.Bots.Interface
{
    public interface IShareBot
    {
        Task<List<string>> SelectShare(string language);
        Task<List<string>> Load(string language, string parameter, List<Message> messages);
        Task<List<string>> Select(string language, List<Message> messages);
    }
}
