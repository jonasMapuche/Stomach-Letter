using CommunityToolkit.Maui.Storage;
using Letter.Helpers;
using Letter.Interfaces;
using Letter.Models;
using Letter.Services.Interfaces;
using Plugin.BLE.Abstractions.Contracts;

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
        private IAudioService _audioService;
        private IRecordService _recordService;
        private ITextSpeakService _textSpeakService;
        private IHttpService _httpService;
        private IAdapter? _adapterBluetooth;
        #endregion

        #region CONSTRUCTOR
        public PerceptionService(IRecordService recordService, IAudioService audioService, ITextSpeakService textSpeakService, HttpService httpService)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation contructor \"Perception\" service failed!");
                else this.error_message = string.Empty;

                this._audios = new List<Audio>();
                this._httpService = httpService;
                FilePath.MountPath();

                this._recordService = recordService;
                this._audioService = audioService;
                this._textSpeakService = textSpeakService;
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

                string file_name = FilePath.SetFileName("jpeg");
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

        public async Task<string> UploadFile()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation upload file \"Perception\" service failed!");

                FileResult? result = await FilePicker.Default.PickAsync();
                if (result != null)
                {
                    Stream sourceStream = await result.OpenReadAsync();
                    string name_file = result.FileName;
                    string[] file_names = name_file.Split('.');
                    if (!(file_names.Length == 2)) return null;
                    if ((file_names[1] == "wav") || (file_names[1] == "mp3") || (file_names[1] == "jpeg"))
                    {
                        string output_path = FilePath.SetFileName(name_file);
                        using (FileStream destinationStream = File.Create(output_path))
                        {
                            await sourceStream.CopyToAsync(destinationStream);
                        }
                        return output_path;
                    }
                }
                return string.Empty;
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
                if (this._error_off) throw new InvalidOperationException("Operation send recording \"Perception\" service failed!");

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

                Download download = new Download();
                download.name = file_name;
                Stream stream = await this._httpService.HttpPost(download);
                stream.Position = 0;
                FileSaverResult file_save = await FileSaver.Default.SaveAsync(file_name, stream, CancellationToken.None);
                file_save.EnsureSuccess();
                return file_save.FilePath;
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

        public async Task<List<string>> ScanBluetooth3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan bluetooth 3 \"Perception\" service failed!");

                return new List<string>();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> ScanBluetooth4()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan bluetooth 4 \"Perception\" service failed!");

                return new List<string>();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
                return new List<string>();
            }
        }

        public async Task<string> ConnectBluetooth3(string device)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation connect bluetooth 3 \"Perception\" service failed!");

                return string.Empty;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> ConnectBluetooth4(string device)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation connect bluetooth 4 \"Perception\" service failed!");

                return string.Empty;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
                return string.Empty;
            }
        }

        public async Task DisconnectBluetooth3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation disconnect bluetooth 3 \"Perception\" service failed!");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task DisconnectBluetooth4()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation disconnect bluetooth 4 \"Perception\" service failed!");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }

        public async Task<string> SendBluetooth3()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send bluetooth 3 \"Perception\" service failed!");

                Audio audios = this._audios.First();
                string file_path = audios.url;

                return string.Empty;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<string> SendBluetooth4()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send bluetooth 4 \"Perception\" service failed!");

                Audio audios = this._audios.First();
                string file_path = audios.url;

                return string.Empty;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
                return string.Empty;
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

        #endregion
    }
}
