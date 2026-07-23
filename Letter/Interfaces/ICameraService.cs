namespace Letter.Interfaces
{
    public interface ICameraService
    {
        void StartPreview(int width, int height);
        void StopPreview();
        void StartRecord(string output);
        string StopRecord();
        Task<byte[]> CaptureCamera();
    }
}
