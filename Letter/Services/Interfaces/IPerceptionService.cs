using Letter.Models;

namespace Letter.Services.Interfaces
{
    public interface IPerceptionService
    {
        Task<string> SaveImage(byte[] bytes);
        Task<string> SaveLetter(List<string> grammar);
        Task<string> DownloadRaspberry();
        Task<string> DownloadFile();
        Task SendRecording(string file_path);
        Task<string> SendRecording();
        Task UploadRaspberry();
        Task<Location> GetCurrentLocation();
        double GetCharge();
        string GetMode();
        BatteryState GetState();
        BatteryPowerSource GetSource();
        void SetVibration(int time);
        Task SetupBluetooth3();
        Task<List<Mechanism>> ScanBluetooth3();
        Task ConnectBluetooth3(string device);
        void SpeakText(string text);
        string FileText(string text);
        void StartRecordMP3();
        void StartRecordWav();
        string StopRecordMP3();
        string StopRecordWav();
        void StopAudio();
        string ReceiveRecording();
        void PlayAudio(string file_path);
        Task ClearRecording();
        Task SetupWiFi();
        Task<List<Mechanism>> ScanWiFi();
        Task<List<Mechanism>> ScanPing(string address);
        Task SetupSMS(string phone);
        void SendSMS(string text);
        Task<List<Mechanism>> ScanSMS();
        void CallPhone(string phone);
        Task<List<Mechanism>> ScanPhone();
        Task<Mechanism> TokenPush();
    }
}
