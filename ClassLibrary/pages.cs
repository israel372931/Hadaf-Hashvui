using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace ClassLibrary
{
    public class pages
    {
        private string book;
        private int sheet;
        private int page;
        ArrayList myAL = new ArrayList();

        public pages() {}

        public async Task<List<BsonDocument>> GetAllPages()
        {
            mongoConection mongoConection = new mongoConection("HadafHashvui");
            var page = mongoConection.getCollectionByName("pages").Result;
            List<BsonDocument> pagesList = page.Find(_ => true).ToList();

            return await Task<List<BsonDocument>>.FromResult(pagesList);
        }
    }
}
