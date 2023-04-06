using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buble.Objects
{
    public class BsonVideoObject
    {

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("channel")]
        public string Channel { get; set; }

        [BsonElement("likes")]
        public int Likes { get; set; }

        [BsonElement("dislikes")]
        public int Dislikes { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("comments")]
        public ArrayList Comments { get; set; }

        [BsonElement("thumbnail_image")]
        public byte[] ThumbnailImage { get; set; }

    }
}
