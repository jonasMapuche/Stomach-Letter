namespace Letter.Services.Interfaces
{
    public interface IPerceptionService
    {
        Task<string> SaveImage(byte[] bytes);
        Task<string> UploadFile();
        Task<string> DownloadRaspberry();
        Task SendRecording(string file_path);
        Task UploadRaspberry();
        Task<Location> GetCurrentLocation();
        double GetCharge();
        string GetMode();
        BatteryState GetState();
        BatteryPowerSource GetSource();
        void SetVibration(int time);
        Task<List<string>> ScanBluetooth3();
        Task<List<string>> ScanBluetooth4();
        Task<string> ConnectBluetooth3(string device);
        Task<string> ConnectBluetooth4(string device);
        Task DisconnectBluetooth3();
        Task DisconnectBluetooth4();
        Task<string> SendBluetooth3();
        Task<string> SendBluetooth4();
        void SpeakText(string text);
        string FileText(string text);
        void StartRecordMP3();
        void StartRecordWav();
        string StopRecordMP3();
        string StopRecordWav();
        public void StopAudio();
        string ReceiveRecording();
        void PlayAudio(string file_path);
        Task ClearRecording();
    }
}
