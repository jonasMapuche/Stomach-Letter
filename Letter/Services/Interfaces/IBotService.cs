using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface IBotService
    {
        event EventHandler<string> OnError;
        Task<string> CaptureCamera(string language);
        Task<string> CaptureCamera(string language, List<Message> messages);
        Task<List<string>> CaptureCamera(string language, string parameter, List<Message> messages);
        Task<string> RecordAudio(string language);
        Task<string> RecordAudio(string language, List<Message> messages);
        Task<List<string>> RecordAudio(string language, string parameter, List<Message> messages);
        Task<string> ShareFile(string language);
        Task ShareScan(List<string> scan);
        Task<List<string>> ShareScan();
        Task<string> ShareFile(string language, List<Message> messages);
        Task<List<string>> ShareFile(string language, string parameter, List<Message> messages);
        Task<List<string>> Terminate(string language, List<Message> messages);
        Task<bool> DeviceShare(string language, List<Message> messages, string device);
        Task<string> DeviceShare();
        Task<string> DecisionTree(string language);
        Task<List<string>> DecisionTree(string language, string parameter, List<Message> messages);
        Task<string> DecisionTree(string language, List<Message> messages);
    }
}
