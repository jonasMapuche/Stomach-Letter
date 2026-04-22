namespace Letter.Views.Templates;

public partial class ReceiverBotItemTemplate : ContentView
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

    public event EventHandler<string>? OnError;
    #endregion

    public ReceiverBotItemTemplate()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation contructor \"Receiver Bot Item\" template failed!");
            else this.error_message = string.Empty;

            InitializeComponent();
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }

    }
}