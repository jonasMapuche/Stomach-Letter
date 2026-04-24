using Letter.Models;

namespace Letter.Interfaces
{
    public interface ITextSpeakService
    {
        void SpeakText(string text);
        string FileText(string text);
        Task<FileStream> ReadStream(Audio audio);
        event EventHandler<string> OnError;
    }
}
