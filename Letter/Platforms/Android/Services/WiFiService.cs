using Android.Content;
using Android.Net.Wifi;
using Android.Provider;
using Letter.Interfaces;
using Letter.Models;
using Letter.Platforms.Android.Broadcasts;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using ProtocolType = System.Net.Sockets.ProtocolType;

namespace Letter.Platforms.Android.Services
{
    public class WiFiService : IWiFiService
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
        private WifiManager _wifiManager;
        public List<Mechanism> Receiver { get; set; }
        #endregion

        #region CONSTRUCTOR
        public WiFiService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"WiFi\" service failed!");
                else this.error_message = string.Empty;

                this.Receiver = new List<Mechanism>();
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
        public void SetUp()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation set up \"WiFi\" service failed!");

                WifiManager wifiManager = (WifiManager)Platform.AppContext.GetSystemService(Context.WifiService);
                this._wifiManager = wifiManager;

                if (this._wifiManager != null && !this._wifiManager.IsWifiEnabled)
                {
                    Intent intent = new Intent(Settings.ActionWifiSettings);
                    intent.SetFlags(ActivityFlags.NewTask);
                    Platform.AppContext.StartActivity(intent);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void Scan()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan \"WiFi\" service failed!");

                WiFiBroadcast receiver = new WiFiBroadcast();
                this.Receiver = receiver.Receiver;
                IntentFilter filter = new IntentFilter(WifiManager.ScanResultsAvailableAction);
                Platform.AppContext.RegisterReceiver(receiver, filter);
                this._wifiManager.StartScan();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<List<string>> Ping(string subnet)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation ping \"WiFi\" service failed!");

                List<string> server_active = new List<string>();
                string subnet_base = "192.168.0.";
                if (subnet != string.Empty) subnet_base = subnet;
                List<Task> tarefa_ping = new List<Task>();
                for (int i = 1; i < 255; i++)
                {
                    string ip_address = subnet_base + i;
                    tarefa_ping.Add(PingCheck(ip_address, server_active));
                }
                await Task.WhenAll(tarefa_ping);
                return server_active;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task PingCheck(string ip, List<string> active)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation ping check \"WiFi\" service failed!");

                using (Ping ping_sender = new Ping())
                {
                    PingReply reply = await ping_sender.SendPingAsync(ip, 20000);
                    if (reply != null && reply.Status == IPStatus.Success)
                    {
                        lock (active)
                        {
                            active.Add(ip);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public async Task<bool> IsPortOpenAsync(string host, int port, int timeoutMilliseconds = 2000)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation is port open async \"WiFi\" service failed!");

                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    try
                    {
                        Task result = socket.ConnectAsync(host, port);
                        if (await Task.WhenAny(result, Task.Delay(timeoutMilliseconds)) == result)
                        {
                            return socket.Connected;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
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
