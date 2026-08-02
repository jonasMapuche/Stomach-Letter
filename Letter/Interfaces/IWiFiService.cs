using Letter.Models;

namespace Letter.Interfaces
{
    public interface IWiFiService
    {
        List<Mechanism> Receiver { get; set; }
        void SetUp();
        void Scan();
        Task<List<Mechanism>> Ping(string subnet);
    }
}
