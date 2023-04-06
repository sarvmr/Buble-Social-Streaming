using Buble.Models;
using Buble.Objects;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Buble.Repositories
{
    public class VideoRepository : RepositoryBase, IVideosRepository
    {
        public List<VideosModel> GetAll()
        {
            // Connect to the MongoDB server
            MongoClient client = new MongoClient("mongodb+srv://rai-sahil:Tkdcrc987@cluster0.dibrkuh.mongodb.net/?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("Video");

            // Get a reference to the "Videos" collection
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Videos");

            // Retrieve all documents in the collection
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();

            // Convert the documents to VideosModel objects
            List<VideosModel> videos = new List<VideosModel>();
            foreach (BsonDocument document in documents)
            {
                VideosModel data = new VideosModel
                {
                    ID = document["_id"].ToString(),
                    likes = document["likes"].ToInt32(),
                    dislikes = document["dislikes"].ToInt32(),
                    channel = document["channel"].ToString(),
                    title = document["title"].ToString(),
                    Thumbnail = document["url"].ToString()
                };
                videos.Add(data);
            }

            return videos;
        }

        public VideosModel GetByVideoId(string videoId)
        {
            VideosModel video = null;
            var client = new MongoClient("mongodb+srv://rai-sahil:Tkdcrc987@cluster0.dibrkuh.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("Video");
            var collection = database.GetCollection<BsonDocument>("Videos");

            if (videoId != null)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(videoId));
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    video = new VideosModel()
                    {
                        ID = result.GetValue("_id").ToString(),
                        Thumbnail = result.GetValue("url").ToString(),
                        likes = result.GetValue("likes").ToInt32(),
                        dislikes = result.GetValue("dislikes").ToInt32(),
                        channel = result.GetValue("channel").ToString(),
                        title = result.GetValue("title").ToString()
                    };
                }
            }

            return video;
        }

        public void AddVideoInformationToMongoDB(string title, string channel)
        {
            MongoClient client = GetMongoClient();
            // Get the database object
            IMongoDatabase database = client.GetDatabase("Video");
            // Get the collection object
            IMongoCollection<BsonVideoObject> collection
                = database.GetCollection<BsonVideoObject>("Videos");

            // Create a new document to insert into the collection
            BsonVideoObject document = new BsonVideoObject
            {
                Title = title,
                Channel = channel,
                Likes = 0,
                Dislikes = 0,
                Url = "https://d1m5sbyhb726tv.cloudfront.net/" + title + ".mp4",
                Comments = new ArrayList()
            };

            // Insert the document into the collection
            collection.InsertOne(document);

            Console.WriteLine("Document inserted successfully.");

        }
    }
}
