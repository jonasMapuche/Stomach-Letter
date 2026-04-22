namespace Letter.Interfaces
{
    public interface ITextSpeakService
    {
        void SpeakText(string text);
        string FileText(string text);
        event EventHandler<string> OnError;
    }
}
