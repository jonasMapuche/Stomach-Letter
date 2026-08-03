using Android.Bluetooth;
using Android.Content;
using Java.Util;
using Letter.Interfaces;
using Letter.Models;
using Letter.Platforms.Android.Broadcasts;
using System.Text;

namespace Letter.Platforms.Android.Services
{
    public class BluetoothService : IBluetoothService
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
        #endregion

        #region VARIABLE
        private BluetoothAdapter? _bluetoothAdapter;
        public List<Mechanism> Receiver { get; set; }
        private BluetoothSocket? _socket;
        private static readonly UUID? MY_UUID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
        #endregion

        #region CONSTRUCTOR
        public BluetoothService()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Bluetooth\" service failed!");
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
                if (this._error_off) throw new InvalidOperationException("Operation set up \"Bluetooth\" service failed!");

                BluetoothManager bluetoothManager = (BluetoothManager)Platform.AppContext.GetSystemService(Context.BluetoothService);
                if (bluetoothManager == null) return;
                this._bluetoothAdapter = bluetoothManager.Adapter;
                if (this._bluetoothAdapter != null && !this._bluetoothAdapter.IsEnabled)
                {
                    Intent enableBtIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                    enableBtIntent.SetFlags(ActivityFlags.NewTask);
                    Platform.AppContext.StartActivity(enableBtIntent);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new NotImplementedException(ex.Message);
            }
        }

        public void Scan()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan \"Bluetooth\" service failed!");

                if (this._bluetoothAdapter == null) return;
                BluetoothBroadcast receiver = new BluetoothBroadcast();
                this.Receiver = receiver.Receiver;
                IntentFilter filter = new IntentFilter(BluetoothDevice.ActionFound);
                Platform.AppContext.RegisterReceiver(receiver, filter);
                this._bluetoothAdapter.StartDiscovery();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new NotImplementedException(ex.Message);
            }
        }

        public void Connect(string address, string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation scan \"Bluetooth\" service failed!");

                if (this._bluetoothAdapter == null) return;
                this._bluetoothAdapter.CancelDiscovery();
                BluetoothDevice? device = this._bluetoothAdapter.GetRemoteDevice(address);
                try
                {
                    this._socket = device?.CreateRfcommSocketToServiceRecord(MY_UUID);
                    if (this._socket == null) return;
                    this._socket.Connect();
                }
                catch (Java.IO.IOException e)
                {
                    try
                    {
                        Java.Lang.Reflect.Method createRfcommSocketMethod = device.Class.GetMethod("createRfcommSocket", new Java.Lang.Class[] { Java.Lang.Integer.Type });
                        Java.Lang.Object? resultSocket = createRfcommSocketMethod.Invoke(device, new Java.Lang.Object[] { int.Parse("1") });
                        if (resultSocket == null) return;
                        this._socket = (BluetoothSocket)resultSocket;
                        if (this._socket == null) return;
                        this._socket.Connect();
                        SendOne(file_path);
                        SendTwo(file_path);
                    }
                    catch (Exception ex)
                    {
                        if (this._socket == null) return;
                        this._socket.Close();
                        throw new NotImplementedException(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new NotImplementedException(ex.Message);
            }
        }

        private async void SendOne(string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send one \"Bluetooth\" service failed!");

                string file_name = Path.GetFileName(file_path);
                FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                MemoryStream ms = new MemoryStream();
                await fs.CopyToAsync(ms);
                ms.Position = 0;
                byte[] file_data = ms.ToArray();
                if (this._socket == null) return;
                Stream? outputStream = this._socket.OutputStream;
                UnicodeEncoding encoding = new UnicodeEncoding(true, false);
                byte[] encoded_name = encoding.GetBytes(file_name + "\0");
                int header_length = 3 + encoded_name.Length;
                byte[] name_header = new byte[header_length];
                name_header[0] = 0x01;
                name_header[1] = (byte)((encoded_name.Length + 3) >> 8);
                name_header[2] = (byte)(encoded_name.Length + 3);
                Array.Copy(encoded_name, 0, name_header, 3, encoded_name.Length);
                byte[] length_header = new byte[5];
                length_header[0] = 0xC3;
                byte[] size_bytes = BitConverter.GetBytes((uint)file_data.Length);
                if (BitConverter.IsLittleEndian) Array.Reverse(size_bytes);
                Array.Copy(size_bytes, 0, length_header, 1, 4);
                int packet_size = 3 + name_header.Length + length_header.Length;
                byte[] put_packet = new byte[packet_size];
                put_packet[0] = 0x82;
                put_packet[1] = (byte)(packet_size >> 8);
                put_packet[2] = (byte)packet_size;
                int offset = 3;
                Array.Copy(name_header, 0, put_packet, offset, name_header.Length);
                offset += name_header.Length;
                Array.Copy(length_header, 0, put_packet, offset, length_header.Length);
                outputStream?.Write(put_packet, 0, put_packet.Length);
                outputStream?.Flush();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new NotImplementedException(ex.Message);
            }
        }

        private async void SendTwo(string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation send two \"Bluetooth\" service failed!");

                byte[] connect_packet = new byte[7];
                connect_packet[0] = 0x80;
                connect_packet[1] = 0x00;
                connect_packet[2] = 0x07;
                connect_packet[3] = 0x10;
                connect_packet[4] = 0x00;
                connect_packet[5] = 0x20;
                connect_packet[6] = 0x00;
                if (this._socket == null) return;
                Stream? outputStream = this._socket.OutputStream;
                outputStream?.WriteAsync(connect_packet, 0, connect_packet.Length);
                outputStream?.FlushAsync();
                string file_name = Path.GetFileName(file_path);
                FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                MemoryStream memory_stream = new MemoryStream();
                await fs.CopyToAsync(memory_stream);
                memory_stream.Position = 0;
                byte[] file_data = memory_stream.ToArray();
                MemoryStream ms = new MemoryStream();
                ms.WriteByte(0x02);
                byte[] nameBytes = Encoding.BigEndianUnicode.GetBytes(file_name);
                ms.WriteByte(0x01);
                ushort nameLen = (ushort)(nameBytes.Length + 2 + 3);
                ms.WriteByte((byte)(nameLen >> 8));
                ms.WriteByte((byte)nameLen);
                ms.Write(nameBytes, 0, nameBytes.Length);
                ms.WriteByte(0x00);
                ms.WriteByte(0x00);
                byte[] typeBytes = Encoding.ASCII.GetBytes("image/jpeg");
                ms.WriteByte(0x42);
                ushort typeLen = (ushort)(typeBytes.Length + 1 + 3);
                ms.WriteByte((byte)(typeLen >> 8));
                ms.WriteByte((byte)typeLen);
                ms.Write(typeBytes, 0, typeBytes.Length);
                ms.WriteByte(0x00);
                ms.WriteByte(0xC3);
                byte[] fileLenBytes = BitConverter.GetBytes(file_data.Length);
                if (BitConverter.IsLittleEndian) Array.Reverse(fileLenBytes);
                ms.Write(fileLenBytes, 0, fileLenBytes.Length);
                ms.WriteByte(0x49);
                ushort bodyLen = (ushort)(file_data.Length + 3);
                ms.WriteByte((byte)(bodyLen >> 8));
                ms.WriteByte((byte)bodyLen);
                ms.Write(file_data, 0, file_data.Length);
                byte[] packetBytes = ms.ToArray();
                ushort totalSize = (ushort)(packetBytes.Length + 3);
                packetBytes[1] = (byte)(totalSize >> 8);
                packetBytes[2] = (byte)totalSize;
                outputStream?.WriteAsync(packetBytes, 0, packetBytes.Length);
                outputStream?.FlushAsync();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new NotImplementedException(ex.Message);
            }
        }

        /*
        public void Find()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation find \"Bluetooth\" service failed!");

                ICollection<BluetoothDevice> pairedDevices = _bluetoothAdapter.BondedDevices;
                if (pairedDevices.Count > 0)
                {
                    foreach (BluetoothDevice device in pairedDevices)
                    {
                        String deviceName = device.Name;
                        String deviceHardwareAddress = device.Address;
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError?.Invoke(this, this.error_message);
            }
        }
        */
        #endregion
    }
}
