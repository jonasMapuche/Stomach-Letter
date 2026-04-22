using SQLite;

namespace Letter.Models
{
    public class Sentencas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string impulse { get; set; }
        public string language { get; set; }
        public string rest { get; set; }
    }
}
