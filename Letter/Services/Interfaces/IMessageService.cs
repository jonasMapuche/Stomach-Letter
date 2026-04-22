using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface IMessageService
    {
        User GetUser(string user);
        string GetLanguage(User? sender);
        List<Message> Messages(User? sender, string text, string language);
        List<Message> Messages(string language);
        List<Message> Chats { get; set; }
        List<Message> GetChatsClear();
        List<Message> Bots(User? sender, string text, string language);
        List<Message> Bots(string language);
        void Remove(string language);
    }
}
