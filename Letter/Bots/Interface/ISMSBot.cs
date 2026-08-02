using Letter.Models;

namespace Letter.Bots.Interface
{
    public interface ISMSBot
    {
        Task<List<string>> SelectKind(string language);
        Task<List<string>> Load(string language, string parameter, List<Message> messages);
        Task<List<string>> Select(string language, List<Message> messages);
    }
}
