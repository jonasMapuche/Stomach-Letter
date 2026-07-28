using CommunityToolkit.Mvvm.Messaging;
using Letter.Controls;
using Letter.Models;
using Letter.Services;
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

    private async void OnError(object? sender, string? error_message)
    {
        await DisplayAlertAsync("Error", error_message, "OK");
    }

    private async void OnError(string? error_message)
    {
        await DisplayAlertAsync("Error", error_message, "OK");
        await Shell.Current.GoToAsync("..");
    }
    #endregion

    #region VARIABLE
    private BotViewModel? _botViewModel;

    private CameraPreview? _cameraPreview;

    private int _line = 0;
    private int _column = 0;
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
            WeakReferenceMessenger.Default.Register<NoticeService>(this, (recipient, message) =>
            {
                string value = message.Value;
                if (value == "scroll") ScrollLastPosition();
                if (value == "preview") StartCameraPreview(this._line, this._column);
                if (value == "stop") StopCameraPreview();
            });
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
            WeakReferenceMessenger.Default.Unregister<NoticeService>(this);
            StopCameraPreview();
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
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
    private void ScrollLastPosition()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation scroll last position \"Bot\" view failed!!");

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Message? last = this._botViewModel?.Messages?.LastOrDefault();
                if (last != null)
                {
                    colViewBot.ScrollTo(last, position: ScrollToPosition.End, animate: false);
                }
            });
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            this.OnError(this.error_message);
        }
    }

    private async void StartCameraPreview(int line, int column)
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation start camera preview \"Bot\" view failed!!");

            if (this._cameraPreview != null) return;
            CameraPreview cameraPreview = new CameraPreview
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };
            this._cameraPreview = cameraPreview;
            this._botViewModel?.CameraPreview = this._cameraPreview;
            Grid.SetRow(cameraPreview, line);
            Grid.SetColumn(cameraPreview, column);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                gridCamera.Children.Add(this._cameraPreview);
            });
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }

    private async void StopCameraPreview()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation stop camera preview \"Bot\" view failed!!");

            MainThread.BeginInvokeOnMainThread(() =>
            {
                gridCamera.Children.Remove(this._cameraPreview);
                this._cameraPreview = null;
            });
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }
    #endregion
}