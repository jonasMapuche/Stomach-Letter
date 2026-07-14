namespace Letter.Interfaces
{
    public interface ICameraService
    {
        void StartPreview();
        void StopPreview();
        void StartRecord(string output);
        string StopRecord();
    }
}
