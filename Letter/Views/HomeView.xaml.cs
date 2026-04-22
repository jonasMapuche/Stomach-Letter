using Letter.Services;
using Letter.ViewModels;

namespace Letter.Views;

public partial class HomeView : ContentPage
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
        System.Environment.Exit(0);
    }
    #endregion

    #region VARIABLE
    private HomeViewModel? _viewModel;
    #endregion

    #region CONSTRUCTOR
    public HomeView(SQLiteService sQLiteService, MongoDBService mongoDBService, TextToSpeakService textToSpeakService, GrammarService grammarService, MessageService messageService)
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation contructor \"Home\" view failed!!");
            else this.error_message = string.Empty;

            HomeViewModel ViewModel = new HomeViewModel(sQLiteService, mongoDBService, textToSpeakService, grammarService, messageService);
            InitializeComponent();
            BindingContext = ViewModel;
            this._viewModel = ViewModel;
            this._viewModel.OnError += OnError;
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            this.OnError(this.error_message);
        }
    }
    #endregion

    #region COMMAND
    private async void OnSettingClicked(object sender, EventArgs e)
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation setting clicked \"Home\" view failed!!");

            await Shell.Current.GoToAsync(nameof(SettingView));
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            this.OnError(this.error_message);
        }
    }
    #endregion

    #region EVENT
    protected override async void OnAppearing()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation appearing \"Home\" view failed!!");

            base.OnAppearing();

            if (this._error_message == string.Empty)
                await this._viewModel.LoadCommand.ExecuteAsync(this);
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