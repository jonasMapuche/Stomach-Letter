using CommunityToolkit.Maui.Storage;
using Letter.Helpers;
using Letter.Interfaces;
using Letter.Models;
using Letter.Services.Interfaces;
using Plugin.Firebase.CloudMessaging;
using Audio = Letter.Models.Audio;

namespace Letter.Services
{
    public class PerceptionService : IPerceptionService
    {
        #region ERROR
        private bool _error_on = true;
        private bool _error_off = false;
        private string? _error_message;

        public string? error_message
        {
            get => this._error_message;
            set
            {
                this._error_message = value;
            }
        }

        public event EventHandler<string>? OnError;
        #endregion

        #region VARIABLE
        public List<Audio> _audios;
        public List<string> _phones;

        private IAudioService _audioService;
        private IRecordService _recordService;
        private ITextSpeakService _textSpeakService;
        private IHttpService _httpService;
        private IBluetoothService _bluetoothService;
        private IWiFiService _wiFiService;
        private IVPNClientService _vPNClientService;
        private ISMSService _sMSService;
        private IPhoneService _phoneService;
        #endregion

        #region CONSTRUCTOR
        public PerceptionService(IRecordService recordService, IAudioService audioService, ITextSpeakService textSpeakService, HttpService httpService, IBluetoothService bluetoothService, IWiFiService wiFiService, IVPNClientService vPNClientService, ISMSService sMSService, IPhoneService phoneService)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation contructor \"Perception\" service failed!");
                else this.error_message = string.Empty;

                this._audios = new List<Audio>();
                this._phones = new List<string>();
                this._httpService = httpService;
                FilePath.MountPath();

                this._recordService = recordService;
                this._audioService = audioService;
                this._textSpeakService = textSpeakService;
                this._bluetoothService = bluetoothService;
                this._wiFiService = wiFiService;
                this._vPNClientService = vPNClientService;
                this._sMSService = sMSService;
                this._phoneService = phoneService;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        #endregion

        #region FUNCTION
        public async Task<string> SaveImage(byte[] bytes)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation save image \"Perception\" service failed!");

                string file_name = FilePath.MountFileName("jpeg");
                string file_path = FilePath.MountFilePath(file_name);
                await File.WriteAllBytesAsync(file_path, bytes);
                return file_path;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> SaveLetter(List<string> grammar)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation save letter \"Perception\" service failed!");

                string file_name = FilePath.MountFileName("txt");
                string file_path = FilePath.MountFilePath(file_name);

                FileStream file = new(file_path, FileMode.OpenOrCreate);
                if ((grammar != null) && (grammar.Count > 0)) 
                {
                    StreamWriter stream = new StreamWriter(file, System.Text.Encoding.UTF8);
                    foreach (string item in grammar)
                    {
                        await stream.WriteLineAsync(item);
                    }
                    stream.Close();
                }
                file.Close();
                return file_path;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task SendRecording(string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send recording \"Perception\" service failed!");

                await ClearRecording();
                Audio audio = new Audio();
                audio.name = Path.GetFileName(file_path);
                audio.url = file_path;
                this._audios.Add(audio);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task ClearRecording()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation clear recording \"Perception\" service failed!");

                this._audios = new List<Audio>();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task UploadRaspberry()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation upload raspberry \"Perception\" service failed!");

                Audio audio = this._audios.First();
                string file_path = audio.url;
                FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                MemoryStream ms = new MemoryStream();
                await fs.CopyToAsync(ms);
                ms.Position = 0;
                using StreamContent streamContent = new StreamContent(ms);
                await this._httpService.HttpPost(streamContent, file_path);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> DownloadRaspberry()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation download raspberry \"Perception\" service failed!");

                Audio audio = this._audios.First();
                string file_name = audio.name;
                string path = "Download";
                FileSaverResult file_result = await this._httpService.HttpDownload(path, file_name);
                file_result.EnsureSuccess();
                return file_result.FilePath;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> DownloadFile()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation download file \"Perception\" service failed!");

                string file_name = string.Empty;
                string file_path = string.Empty;
                if (this._audios.Count == 0) return file_path;
                Audio audio = this._audios.First();
                file_name = audio.name;
                file_path = audio.url;
                FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                MemoryStream memory_stream = new MemoryStream();
                await fs.CopyToAsync(memory_stream);
                Stream stream = memory_stream;
                FileSaverResult file_save = await FileSaver.Default.SaveAsync(file_name, stream, CancellationToken.None);
                return file_path;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation current location \"Perception\" service failed!");

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
                Location location = await Geolocation.GetLocationAsync(request);
                return location;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public double GetCharge()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation get charge \"Perception\" service failed!");

                return (Battery.ChargeLevel * 100);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public string GetMode()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation get mode \"Perception\" service failed!");

                return Battery.Default.EnergySaverStatus == EnergySaverStatus.On ? "On" : Battery.Default.EnergySaverStatus == EnergySaverStatus.Off ? "Off" : "Unknown";
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public BatteryState GetState()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation get state \"Perception\" service failed!");

                return Battery.Default.State;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public BatteryPowerSource GetSource()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation get source \"Perception\" service failed!");

                return Battery.Default.PowerSource;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void SetVibration(int time)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation set vibration \"Perception\" service failed!");

                int secondsToVibrate = Random.Shared.Next(1, time);
                TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);
                Vibration.Default.Vibrate(vibrationLength);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task SetupBluetooth3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup bluetooth 3 \"Perception\" service failed!");

                this._bluetoothService.SetUp();
                this._bluetoothService.Scan();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task SetupWiFi()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup wifi \"Perception\" service failed!");

                this._wiFiService.SetUp();
                this._wiFiService.Scan();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<Mechanism>> ScanWiFi()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan wifi \"Perception\" service failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                mechanisms = this._wiFiService.Receiver;
                this._wiFiService.Scan();
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<Mechanism>> ScanBluetooth3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan bluetooth 3 \"Perception\" service failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                mechanisms = this._bluetoothService.Receiver;
                this._bluetoothService.Scan();
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> ConnectBluetooth3(string device)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation connect bluetooth 3 \"Perception\" service failed!");

                Audio audio = this._audios.First();
                string file_name = audio.name;
                this._bluetoothService.Connect(device, file_name);
                return string.Empty;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void SpeakText(string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation speak text \"Perception\" service failed!");

                this._textSpeakService.OnError += OnError;
                this._textSpeakService.SpeakText(text);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public string FileText(string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation file text \"Perception\" service failed!");

                return this._textSpeakService.FileText(text);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void StartRecordMP3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start record mp3 \"Perception\" service failed!");

                this._recordService.StartRecordMP3();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void StartRecordWav()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start record wav \"Perception\" service failed!");

                this._recordService.StartRecordWav();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public string StopRecordMP3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start record mp3 \"Perception\" service failed!");

                return this._recordService.StopRecordMP3();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public string StopRecordWav()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start record wav \"Perception\" service failed!");

                return this._recordService.StopRecordWav();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void StopAudio()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop audio \"Perception\" service failed!");

                this._audioService.StopAudio();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public string ReceiveRecording()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation receive recording \"Perception\" service failed!");

                Audio audio = this._audios.First();
                string file_path = audio.url;
                return file_path;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void PlayAudio(string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation play audio \"Perception\" service failed!");

                this._audioService.PlayAudio(file_path);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task SetupSMS(string phone)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup sms \"Perception\" service failed!");

                await ClearPhone();
                this._phones.Add(phone);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task ClearPhone()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation clear phone \"Perception\" service failed!");

                this._phones = new List<string>();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void SendSMS(string text)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send sms \"Perception\" service failed!");

                string phone = this._phones.First(); 
                this._sMSService.Send(phone, text);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<Mechanism>> ScanSMS()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan sms \"Perception\" service failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                mechanisms = this._sMSService.Receiver;
                this._sMSService.Scan();
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void CallPhone(string phone)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation call phone \"Perception\" service failed!");

                this._phoneService.Call(phone);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<Mechanism>> ScanPhone()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan phone \"Perception\" service failed!");

                List<Mechanism> mechanisms = new List<Mechanism>();
                mechanisms = this._phoneService.Receiver;
                this._phoneService.Scan();
                return mechanisms;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<Mechanism> TokenPush()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation token push \"Perception\" service failed!");

                await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
                string token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
                Mechanism mechanism = new Mechanism();
                mechanism.name = token;
                mechanism.implied = token;
                return mechanism;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion
    }
}
