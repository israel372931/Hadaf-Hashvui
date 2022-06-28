using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;


namespace ClassLibrary
{
    public class links
    {
        private int count;
        private string link;
        private mongoConection mongoConection;
        //תכונות

        public links() { }
        //בונה
        public async Task<List<BsonDocument>> GetAllLinks()
        {
            mongoConection mongoConection = new mongoConection("HadafHashvui");
            var page = mongoConection.getCollectionByName("links").Result;
            List<BsonDocument> pagesList = page.Find(_ => true).ToList();

            return await Task<List<BsonDocument>>.FromResult(pagesList);
        }
        //שליפת רשימה של כל הקישורים

        public async Task<int> getLastLink()
        {

            mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("links");
            BsonDocument b = await user.Aggregate().SortByDescending((a) => a["count"]).FirstAsync();

            return int.Parse(b.GetValue("count").ToString());
        }
        //שליפת המספר של הקישור האחרון

        public async Task setNewLink(int count, string link, string name)
        {
            var doc = new BsonDocument
            {
                {"count",count + 1},
                {"link", link},
                {"name", name }
            };
            mongoConection mongo = new mongoConection("HadafHashvui");
            await mongo.addNewDoctoCollection("links", doc);
        }
        //יצירת link

        public async void removeLink(string link)
        {
            mongoConection mongo = new mongoConection("HadafHashvui");
            var user = await mongo.getCollectionByName("links");
            var filter = Builders<BsonDocument>.Filter.Eq("link", link);
            await user.DeleteOneAsync(filter);
        }
        //מחיקת קישור


    }
}
