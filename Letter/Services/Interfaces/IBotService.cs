using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface IBotService
    {
        event EventHandler<string> OnError;
        Task<string> CaptureCamera(string language);
        Task<List<string>> LoadCamera(string language);
        Task<string> CaptureCamera(string language, List<Message> messages);
        Task<List<string>> CameraChoose(string language, List<Message> messages);
        Task<List<string>> CaptureCamera(string language, string parameter, List<Message> messages);
        Task<string> RecordAudio(string language);
        Task<List<string>> LoadAudio(string language);
        Task<string> RecordAudio(string language, List<Message> messages);
        Task<List<string>> RecordChoose(string language, List<Message> messages);
        Task<List<string>> RecordAudio(string language, string parameter, List<Message> messages);
        Task<string> ShareFile(string language);
        Task<List<string>> LoadShare(string language);
        Task<string> ShareFile(string language, List<Message> messages);
        Task<List<string>> ShareChoose(string language, List<Message> messages);
        Task<List<string>> ShareFile(string language, string parameter, List<Message> messages);
        Task<List<string>> Terminate(string language, List<Message> messages);
        Task<string> DecisionTree(string language);
        Task<List<string>> DecisionTree(string language, string parameter, List<Message> messages);
        Task<string> DecisionTree(string language, List<Message> messages);
    }
}
