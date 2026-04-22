using Letter.Models;
using MongoDB.Driver;

namespace Letter.Data
{
    public class AssistenteContext
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
        private readonly IMongoDatabase _database;
        private readonly string _collection;
        #endregion

        #region CONSTRUCTOR
        public AssistenteContext()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Assistente\" context failed!");
                else this._error_message = string.Empty;

                string connection = "mongodb://berthazatz:freedown@ac-grilrgv-shard-00-00.tohxtxd.mongodb.net:27017,ac-grilrgv-shard-00-01.tohxtxd.mongodb.net:27017,ac-grilrgv-shard-00-02.tohxtxd.mongodb.net:27017/?ssl=true&replicaSet=atlas-q1zd06-shard-0&authSource=admin&appName=auxiliary";
                string database = "stomach";
                this._collection = "auxiliary";

                MongoClient client = new MongoClient(connection);
                this._database = client.GetDatabase(database);
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
        public IMongoCollection<Assistente> GetCollection() => this._database.GetCollection<Assistente>(this._collection);
        #endregion
    }
}
