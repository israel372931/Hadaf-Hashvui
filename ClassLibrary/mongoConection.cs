using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClassLibrary
{
    public class mongoConection
    {
        private MongoClient dbClient = new MongoClient("mongodb+srv://user:user1234@cluster0.mzxtq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        private IMongoDatabase db;
        private String dbName;
        //תכונות

        public mongoConection(String dbName)
        {
            this.dbName = dbName;
            db = dbClient.GetDatabase(dbName);
        }
        //שינוי שם

        public async Task<IMongoCollection<BsonDocument>> getCollectionByName(String nameColl)
        {
            return await Task.FromResult(db.GetCollection<BsonDocument>(nameColl));
        }
        //כניסה לדאטה בייס

        public async Task<Task> addNewDoctoCollection(String nameColl, BsonDocument docToAdd)
        {
            var coll = db.GetCollection<BsonDocument>(nameColl);
            return coll.InsertOneAsync(docToAdd);
        }
        //הוספה לדאטה בייס
    }
}
