using apicsharp.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace apicsharp.Repo
{
    public class Repo : IRepo
    {
        public string ObterPorId(string id)
        {
            const string connectionUri = "mongodb://localhost:27017";
            var client = new MongoClient(connectionUri);
            var db = client.GetDatabase("mydatabase");
            var collection = db.GetCollection<BsonDocument>("produto");
            var fil = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var tes = collection.Find(fil).FirstOrDefault();

            var json = tes.ToString();

            return json;
        }

        public void Criar(Produto prod)
        {
            const string connectionUri = "mongodb://localhost:27017";
            var client = new MongoClient(connectionUri);
            var db = client.GetDatabase("mydatabase");
            var collection = db.GetCollection<BsonDocument>("produto");
            var document = new BsonDocument
            {
                { "Nome" , prod.Nome },
                { "Marca" , prod.Marca },
                { "Quantidade" , prod.Quantidade }
            };
            collection.InsertOne(document);
        }

        public string ObterNomeBanco()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto prod)
        {
            const string connectionUri = "mongodb://localhost:27017";
            var client = new MongoClient(connectionUri);
            var db = client.GetDatabase("mydatabase");
            var collection = db.GetCollection<Produto>("produto");
            var document = new BsonDocument
            {
                { "ID", prod.ID },
                { "Nome" , prod.Nome },
                { "Marca" , prod.Marca },
                { "Quantidade" , prod.Quantidade }  
            };

            var fil = Builders<Produto>.Filter.Eq("_id", ObjectId.Parse(prod.ID));
 
            var update = Builders<Produto>.Update
                .Set(person => person, prod);

            var personUpdateResult = collection.UpdateOne(fil, update);
 
        }
    }
}
