using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Letter.Models
{
    public class Assistente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string nome { get; set; }
        public string linguagem { get; set; }
        public List<Tematica> tematica { get; set; }
    }
}
