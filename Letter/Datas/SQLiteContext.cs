using SQLite;

namespace Letter.Data
{
    public class SQLiteContext
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
        private SQLiteAsyncConnection _connection;
        private string _file_sqlite = "letter.db";
        private string _path;
        #endregion

        #region CONSTRUCTOR
        public SQLiteContext()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"SQLite\" context failed!!");
                else this.error_message = string.Empty;

                string file_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), this._file_sqlite);
                this._path = file_path;
                this._connection = new SQLiteAsyncConnection(file_path);
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

        #region EVENTO
        #endregion

        #region FUNCTION
        public SQLiteAsyncConnection GetConnection() => this._connection;
        public string GetFilePath() => this._path;
        #endregion
    }
}
