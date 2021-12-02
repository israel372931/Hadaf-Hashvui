using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClassLibrary
{
    class mongoConection
    {
        private MongoClient dbClient = new MongoClient("mongodb + srv://student1:student1234@cluster0.mzxtq.mongodb.net/HadafHashvui?retryWrites=true&w=majority");
        private IMongoDatabase db;
        private string dbName;

        public mongoConection(string dbName)
        {
            this.dbName = dbName;
            db = dbClient.GetDatabase(dbName);
        }

        public IMongoCollection<BsonDocument> getCollectionByName(string nameColl)
        {
            return db.GetCollection<BsonDocument>(nameColl);

        }
    }
}
