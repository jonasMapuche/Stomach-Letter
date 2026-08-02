using Letter.Enums;

namespace Letter.Interfaces
{
    public interface ICameraService
    {
        void StartPreview(int width, int height);
        void StopPreview();
        void RotateCamera(Rotate rotate);
        void FlashCamera(Flash flash);
        void StartRecord(string output);
        void StopRecord();
        Task<byte[]> CaptureCamera();
    }
}
