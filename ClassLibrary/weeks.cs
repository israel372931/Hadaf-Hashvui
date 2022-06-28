using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;

namespace ClassLibrary
{
    public class weeks
    {
        private int weekNum;
        private bool isActive;
        private string book;
        private int sheet;
        private List<int> links;
        private mongoConection mongoConection;
        //תכונות

        public weeks() { }

        public void setWeekNum(int num)
        {
            this.weekNum = num;
        }

        public void setActive()
        {
            this.isActive = true;
        }

        public void setUnactive()
        {
            this.isActive = false;
        }

        public void setBook(string book)
        {
            this.book = book;
        }

        public void setSheet()
        {
            this.sheet = sheet;
        }

        public int GetWeekNum()
        {
            return this.weekNum;
        }

        public bool GetIsActive()
        {
            return this.isActive;
        }

        public string GetBook()
        {
            return this.book;
        }

        public int GetSheet()
        {
            return this.sheet;
        }
        //פעולות get set

        public async Task<int> getLastWeek()
        {

            mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("weeks");

           // var filter = Builders<BsonDocument>.Filter.Eq("username", this.username);
           // if (pas)
           // {
           //     filter = filter & Builders<BsonDocument>.Filter.Eq("password", this.password);
           // }
            BsonDocument b = await user.Aggregate().SortByDescending((a) => a["count"]).FirstAsync();

             return   int.Parse(b.GetValue("count").ToString());

        }

        public async Task<int> getLastSheet()
        {

            mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("weeks");
            BsonDocument b = await user.Aggregate().SortByDescending((a) => a["count"]).FirstAsync();

            return int.Parse(b.GetValue("sheet").ToString());
        }

        public async Task<string> getLastBook()
        {

            mongoConection = new mongoConection("HadafHashvui");
            var user = await mongoConection.getCollectionByName("weeks");
            BsonDocument b = await user.Aggregate().SortByDescending((a) => a["count"]).FirstAsync();

            return b.GetValue("book").ToString();
        }
        //שלוש הפעולות ששולפותאת הנתונים מהדוקיומנט האחרון
        public async Task<List<int>> getIndexes(int weekNum)
        {
            mongoConection = new mongoConection("HadafHashvui");
            var weeks = await mongoConection.getCollectionByName("weeks");
            var filter = Builders<BsonDocument>.Filter.Eq("count", weekNum);
            List<int> indexes = new List<int>();
            BsonDocument week = await  weeks.Find(filter).FirstOrDefaultAsync();
            var indexesArray = week.GetValue("links").AsBsonArray;
            foreach( int element in indexesArray)
            {
                indexes.Add(element);
            }
            //indexes = (List<int>)( indexesArray);//.ToList<int>();
            return indexes;
            
        }
        //שליפת רשימה מתוך week

        public async Task<List<BsonDocument>> getLinksByNumbers(List<int> indexes)
        {
            mongoConection = new mongoConection("HadafHashvui");
            var link = await mongoConection.getCollectionByName("links");
            List<BsonDocument> list = new List<BsonDocument>();
            if (indexes.Count > 0)
            {
                FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("count", indexes[0]); ;
                foreach (int index in indexes.Skip(1))
                {
                    filter = filter | Builders<BsonDocument>.Filter.Eq("count", index);
                }
                list = link.Find(filter).ToList<BsonDocument>();
            }

            return list;
        }
        //שליפת לינקים לפי הרשימה

        public async Task setNewWeek(int count, string book, int sheet)
        {

            var doc = new BsonDocument
            {
                {"count",count + 1},
                {"isActive", false},
                {"book", book},
                {"sheet", sheet + 1},
                {"links", new BsonArray()}

               
            };
            mongoConection mongo = new mongoConection("HadafHashvui");
            await mongo.addNewDoctoCollection("weeks", doc);
        }
        //יצירת week

        public async Task<UpdateResult> setIsActive(int count)
        {
            mongoConection = new mongoConection("HadafHashvui");
            var week = await mongoConection.getCollectionByName("weeks");
            var filter = Builders<BsonDocument>.Filter.Eq("isActive", true);
            var update = Builders<BsonDocument>.Update.Set("isActive", false);
            var result = await week.UpdateOneAsync(filter, update);
            filter = Builders<BsonDocument>.Filter.Eq("count", count);
            update = Builders<BsonDocument>.Update.Set("isActive", true);
            return await week.UpdateOneAsync(filter, update);
        }
        //הפיכת שבוע מסוים לפעיל

        public async Task<List<BsonDocument>> GetAllWeeks()
        {
            mongoConection mongoConection = new mongoConection("HadafHashvui");
            var page = mongoConection.getCollectionByName("weeks").Result;
            List<BsonDocument> weeksList = page.Find(_ => true).ToList();

            return await Task<List<BsonDocument>>.FromResult(weeksList);
        }
        //שליפת רשימה של כל השבועות

        public async void editWeek(int count, string book, int sheet)
        {
            mongoConection = new mongoConection("HadafHashvui");
            var week = await mongoConection.getCollectionByName("weeks");
            var filter = Builders<BsonDocument>.Filter.Eq("count", count);
            var update = Builders<BsonDocument>.Update.Set("book", book);
            var result = await week.UpdateOneAsync(filter, update);
            var update1 = Builders<BsonDocument>.Update.Set("sheet", sheet);
            var result1 = await week.UpdateOneAsync(filter, update1);

        }

        public async Task<bool> addLinkToWeek (int weekNum, int LinkNum)
        {
            mongoConection = new mongoConection("HadafHashvui");
            var week = await mongoConection.getCollectionByName("weeks");
            var filter = Builders<BsonDocument>.Filter.Eq("count", weekNum);
            var add = Builders<BsonDocument>.Update.Push<int>("links", LinkNum);
            var result = await week.UpdateOneAsync(filter, add);
            return await Task<bool>.FromResult(true);
        }

        public async Task<bool> removeLinkFromWeek(int weekNum, int LinkNum)
        {
            mongoConection = new mongoConection("HadafHashvui");
            var week = await mongoConection.getCollectionByName("weeks");
            var filter = Builders<BsonDocument>.Filter.Eq("count", weekNum);
            var add = Builders<BsonDocument>.Update.Pull<int>("links", LinkNum);
            var result = await week.UpdateOneAsync(filter, add);
            return await Task<bool>.FromResult(true);
        }
        //עריכת week

        //public async Task<BsonDocument> findTheActive()
        // {

        //     mongoConection = new mongoConection("HadafHashvui");
        //     var user = await mongoConection.getCollectionByName("weeks");

        //     var filter = Builders<BsonDocument>.Filter.Eq("isActive", true);

        //     return await user.Find(filter).FirstOrDefaultAsync();

        // }

    }
}
