namespace Letter.Views;

public partial class ModalView : ContentPage
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

    #region VARIABLE
    #endregion

    #region CONSTRUCTOR
    public ModalView()
	{
        try
        { 
            if (this._error_off) throw new InvalidOperationException("Operation contructor \"Modal\" view failed!!");
            else this.error_message = string.Empty;

            InitializeComponent();
            Application.Current.ModalPushed += OnModalPushed;
            Application.Current.ModalPopping += OnModalPopping;
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }
    #endregion

    #region COMMAND
    #endregion

    #region EVENT
    private void OnModalPushed(object sender, ModalPushedEventArgs e)
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation modal pushed \"Modal\" view failed!!");

            this.BackgroundColor = Color.FromArgb("#80000000");
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }

    private void OnModalPopping(object sender, ModalPoppingEventArgs e)
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation modal popping \"Modal\" view failed!!");

            this.BackgroundColor = Color.FromArgb("#00000000");
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }

    protected override void OnDisappearing()
    {
        try
        {
            if (this._error_off) throw new InvalidOperationException("Operation disappearing \"Modal\" view failed!!");

            base.OnDisappearing();
        }
        catch (Exception ex)
        {
            this.error_message = ex.Message;
            throw new InvalidOperationException(this.error_message);
        }
    }
    #endregion

    #region FUNCTION
    #endregion
}