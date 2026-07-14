using Letter.Models;

namespace Letter.Interfaces
{
    public interface IBluetoothService
    {
        void SetUp();
        void Scan();
        List<Message> Receiver { get; set; }
        void Connect(string address, string file_path);
    }
}
