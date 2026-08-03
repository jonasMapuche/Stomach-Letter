using Letter.Models;

namespace Letter.Bots.Interface
{
    public interface IPhoneBot
    {
        Task<List<string>> SelectSetup(string language);
        Task<List<string>> Load(string language, string parameter, List<Message> messages);
        Task<List<string>> Select(string language, List<Message> messages);
    }
}
