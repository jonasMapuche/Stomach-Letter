using Letter.Models;

namespace Letter.Bots.Interface
{
    public interface IDecisionTreeBot
    {
        Task<string> Sentence(string language);
        Task<List<string>> Load(string language, string parameter, List<Message> messages);
        Task<string> Choose(string language, List<Message> messages);
    }
}
