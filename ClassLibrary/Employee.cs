using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //public class resposeModel
    //{
    //    public bool IsSuccessfull { get; set; }
    //    public string Password { get; set; }
    //}
    public class Employee : Person
    {
        private string username;
        private string password;
        private mongoConection mongoConection;
        //תכונות

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

        public Employee()
        {
        }
        //פעולות בונות

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
        //פעולות get set
        public async Task<BsonDocument> getEmployeeDetailsDocByName(bool pas)
        {

            mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("user");

            var filter = Builders<BsonDocument>.Filter.Eq("username", this.username);
            if (pas)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("password", this.password);
            }
            //BsonDocument b = await user.Find(filter).FirstOrDefaultAsync();

            return await user.Find(filter).FirstOrDefaultAsync();

        }
        //פעולה לשליפת שם משתמש וסיסמה

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
        //יצירת employee

        public async Task<BsonDocument> forgotPassword()
        {
            mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("user");

            var filter = Builders<BsonDocument>.Filter.Eq("id", this.GetId());
            return await user.Find(filter).FirstOrDefaultAsync();
        }
        //שליפת סיסמה לפי מספר זהות
    }
}
