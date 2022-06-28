using MongoDB.Bson;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class converter
    {
        public static string ToJson(List<BsonDocument> bsonDocument)
        {
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };

            return bsonDocument.ToJson(jsonWriterSettings);
        }
    }
    //תרגום
}
