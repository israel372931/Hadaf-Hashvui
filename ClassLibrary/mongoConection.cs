using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
namespace ClassLibrary
{
    class mongoConection
    {
        private MongoClient dbClient = new MongoClient("mongodb+srv://student1:student1234@cluster0.mzxtq.mongodb.net/HadafHashvui?retryWrites=true&w=majority");
        private IMongoDatabase db;
        private string dbName;

        public mongoConection(string dbName)
        {
            this.dbName = dbName;
            db = dbClient.GetDatabase(dbName);
        }

        public async Task<IMongoCollection<BsonDocument>>  getCollectionByName(string nameColl)
        {
            return await Task.FromResult(db.GetCollection<BsonDocument>(nameColl));

        }

        public async Task addDoc(BsonDocument doc, string nameColl)
        {
            var coll =await getCollectionByName(nameColl);
            coll.InsertOneAsync(doc);
        }
    }
}
