using Letter.Models;

namespace Letter.Bots.Interface
{
    public interface ICameraBot
    {
        Task<List<string>> SelectPreview(string language);
        Task<List<string>> Select(string language, List<Message> messages);
        Task<List<string>> Load(string language, string parameter, List<Message> messages);
    }
}
