using Letter.Services;
using Letter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Letter
{
    public partial class App : Application
    {
        private MessageService _messageService;

        public App(MessageService messageService)
        {
            this._messageService = messageService;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell(this._messageService));
        }
    }
}