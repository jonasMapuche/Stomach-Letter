using Letter.Models;

namespace Letter.Interfaces
{
    public interface IPhoneService
    {
        void Call(string number);
        void Call(string numero, string caminhoAudio);
        void Scan();
        List<Mechanism> Receiver { get; set; }
    }
}
