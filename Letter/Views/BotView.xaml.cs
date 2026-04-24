using CommunityToolkit.Maui.Core;
using Letter.ViewModels;

namespace Letter.Views;

public partial class BotView : ContentPage
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

    private async void OnError(object sender, string error_message)
    {
        await DisplayAlertAsync("Error", error_message, "OK");
    }

    private async void OnError(string error_message)
    {
        await DisplayAlertAsync("Error", error_message, "OK");
        await Shell.Current.GoToAsync("..");
    }
    #endregion

    #region VARIABLE
    private BotViewModel? _botViewModel;
    #endregion

    #region CONSTRUCTOR
    public BotView(BotViewModel ViewModel)
	{
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation constructor \"Bot\" view failed!!");
            else this.error_message = string.Empty;

            InitializeComponent();
            ViewModel.OnError += OnError;
            BindingContext = ViewModel;
            this._botViewModel = ViewModel;
            this._botViewModel.ViewCamera = Camera;
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            this.OnError(this.error_message);
        }
    }
    #endregion

    #region COMMAND
    #endregion

    #region EVENT
    protected override void OnDisappearing()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation disappearing \"Bot\" view failed!!");

            base.OnDisappearing();
            this.Handler?.DisconnectHandler();
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }

    private void OnMediaCaptured(object sender, MediaCapturedEventArgs e)
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation media captured \"Bot\" view failed!");

            MemoryStream? memoryStream = new MemoryStream();
            e.Media.CopyTo(memoryStream);
            this._botViewModel.Bytes = memoryStream.ToArray();
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            this.OnError(this.error_message);
        }
    }

    protected override async void OnAppearing()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation appearing \"Bot\" view failed!!");

            base.OnAppearing();
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            this.OnError(this.error_message);
        }
    }
    #endregion

    #region FUNCTION
    #endregion
}