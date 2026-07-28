using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface IBotService
    {
        event EventHandler<string> OnError;
        Task<List<string>> LoadCamera(string language);
        Task<List<string>> CameraChoose(string language, List<Message> messages);
        Task<List<string>> CaptureCamera(string language, string parameter, List<Message> messages);
        Task<List<string>> LoadAudio(string language);
        Task<List<string>> RecordChoose(string language, List<Message> messages);
        Task<List<string>> RecordAudio(string language, string parameter, List<Message> messages);
        Task<List<string>> LoadShare(string language);
        Task<List<string>> ShareChoose(string language, List<Message> messages);
        Task<List<string>> ShareFile(string language, string parameter, List<Message> messages);
        Task<string> DecisionTree(string language);
        Task<List<string>> DecisionTree(string language, string parameter, List<Message> messages);
        Task<string> DecisionTree(string language, List<Message> messages);
    }
}
