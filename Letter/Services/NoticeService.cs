using CommunityToolkit.Mvvm.Messaging.Messages;
using Letter.Services.Interfaces;

namespace Letter.Services
{
    public class NoticeService : ValueChangedMessage<string>, INoticeService
    {
        public NoticeService(string mensagem) : base(mensagem)
        {
        }
    }
}
