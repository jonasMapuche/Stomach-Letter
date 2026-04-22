using Letter.Services;
using Letter.Views;
using Letter.Models;
using System.Windows.Input;
using Letter.Services.Interfaces;

namespace Letter
{
    public partial class AppShell : Shell
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

        private async Task OnError(object sender, string error_message)
        {
            await DisplayAlertAsync("Error", error_message, "OK");
        }

        private async void OnError(string error_message)
        {
            await DisplayAlertAsync("Error", error_message, "OK");
            System.Environment.Exit(0);
        }
        #endregion

        #region VARIABLE
        public ICommand? BotCommand { get; set; }
        public ICommand? ExitCommand { get; set; }

        private Language? _language_portugues;
        private SettingService? _settingService;
        private IMessageService? _messageService;
        #endregion

        #region CONSTRUCTOR
        public AppShell(MessageService messageService)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation contructor \"App\" Shell failed!!");
                else this.error_message = string.Empty;

                InitializeComponent();

                Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
                Routing.RegisterRoute(nameof(BotView), typeof(BotView));
                Routing.RegisterRoute(nameof(SettingView), typeof(SettingView));
                Routing.RegisterRoute(nameof(ModalView), typeof(ModalView));

                this._messageService = messageService;
                this._settingService = SettingService.Instance;
                this._language_portugues = this._settingService.Portugues;

                this.BotCommand = new Command(async () => await OnBotCommand());
                this.ExitCommand = new Command(async () => await OnExitCommand());

                BindingContext = this;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError(this.error_message);
            }
        }
        #endregion

        #region COMMAND
        private async Task OnExitCommand()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation exit command \"App\" shell failed!!");
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError(this.error_message);
            }
        }

        private async Task OnBotCommand()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation bot command \"App\" shell failed!!");

                User user = new User();
                user = this._messageService.GetUser(this._language_portugues.Lowercase);
                Dictionary<string, object> navigationParameter = new Dictionary<string, object>
                    {
                        { "username", user }
                    };
                await Shell.Current.GoToAsync($"{nameof(BotView)}", true, navigationParameter);
                Shell.Current.FlyoutIsPresented = false;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                this.OnError(this.error_message);
            }
        }
        #endregion

        #region EVENT
        #endregion

        #region FUNCTION
        #endregion
    }
}
