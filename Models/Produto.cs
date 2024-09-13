using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace apicsharp.Models
{
    public class Produto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [Required]

        public string Nome { get; set; }
        [Required]

        public string Marca { get; set; }
        [Required]

        public int Quantidade { get; set; }
    }
}
