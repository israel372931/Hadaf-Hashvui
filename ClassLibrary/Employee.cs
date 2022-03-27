using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Employee : Person
    {
        private string username;
        private string password;
        private mongoConection mongoConection;

        public Employee(string name, string id, string username, string password) : base(id, name)
        {
            this.username = username;
            this.password = password;
        }

        public Employee(string userName, string password)
        {
            this.username = userName;
            this.password = password;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public void SetUsername(string newUsername)
        {
            this.username = newUsername;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public void SetPassword(string newPassword)
        {
            this.password = newPassword;
        }

        public async Task<BsonDocument> getEmployeeDetailsDocByName()
        {
       
              mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("user");
            var filter = Builders<BsonDocument>.Filter.Eq("username", this.username) & Builders<BsonDocument>.Filter.Eq("password", this.password);


             return await user.Find(filter).FirstOrDefaultAsync();

        }

        public async Task setNewDocument()
        {
            var doc = new BsonDocument
            {
                {"name", this.GetName()},
                {"id", this.GetId()},
                {"username", this.GetUsername()},
                {"password", this.GetPassword()}
            };
            mongoConection mongo = new mongoConection("HadafHashvui");
            await mongo.addNewDoctoCollection("user", doc);
        }

    }
}
