using Letter.Models;

namespace Letter.Interfaces
{
    public interface ISMSService
    {
        List<Mechanism> Receiver { get; set; }
        void Send(string destino, string text);
        List<Mechanism> NetworkActive();
        Mechanism NetworkCurrent();
        void Scan();
    }
}
