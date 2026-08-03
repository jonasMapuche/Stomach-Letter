using Letter.Enums;

namespace Letter.Interfaces
{
    public interface ISpeechService
    {
        void SetUp();
        void Speak(string text, string language, Profit profit, float pitch, float volume);
    }
}
