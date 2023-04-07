using Buble.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Windows.Networking;

namespace Buble.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Username", credential.UserName),
                Builders<BsonDocument>.Filter.Eq("Password", credential.Password)
            );

            var results = collection.Find(filter).ToList();

            if (results.Count > 0)
            {
                // username and password found
                return true;
            }
            else
            {
                // username and/or password not found
                return false;
            }
        }

        public bool AddUser(string firstname, string username, string email, string password)
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");
            // Check if username already exists
            BsonDocument existingUser = collection.Find(new BsonDocument("username", username)).FirstOrDefault();
            if (existingUser != null)
            {
                Console.WriteLine("Username already exists!");
                return false; // Exit the method or show an error message as appropriate
            }

            // If username doesn't exist, add the new user document
            BsonDocument newUser = new BsonDocument
            {
                { "Firstname", firstname },
                { "Lastname", "" },
                { "Username", username },
                { "Email", email },
                { "Password", password },
                { "Followers", new BsonArray() }, // initialize empty followers array
                { "Followings", new BsonArray() }  // initialize empty following array
            };

            collection.InsertOne(newUser);
            Console.WriteLine("User added successfully.");
            return true;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetByAll()
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<UserModel>("User");

            var filter = Builders<UserModel>.Filter.Empty;
            var projection = Builders<UserModel>.Projection
                .Include(u => u.Firstname)
                .Include(u => u.Username)
                .Include(u => u.ProfilePicture)
                .Include(u => u.Id);
            var users = collection.Find(filter)
                .Project<UserModel>(projection).ToList();

            return users;
        }

        public void UpdatetById(string id, string name, string username, string email)
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");

            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
                // Set up the update fields
                var update = Builders<BsonDocument>.Update
                    .Set("Firstname", name)
                    .Set("Username", username)
                    .Set("email", email);
                // Update the document
                var result = collection.UpdateOneAsync(filter, update);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\nIndex is Out Of Bound For ID\n");
            }

        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;

            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
            var reader = collection.Find(filter).FirstOrDefault();

            if (reader != null)
            {
                user = new UserModel()
                {
                    Id = reader["_id"].ToString(),
                    Username = reader["Username"].ToString(),
                    Password = string.Empty,
                    Firstname = reader["Firstname"].ToString(),
                    LastName = reader["Lastname"].ToString(),
                    Email = reader["Email"].ToString(),

                };

                // use the variable values as needed
            }
            return user;

        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserPassword(string username, string password)
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
            var update = Builders<BsonDocument>.Update.Set("Password", password);

            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount > 0)
            {
                Console.WriteLine("Changed");
            }
            else
            {
                Console.WriteLine("not");
            }
        }

        public void addFollowing(string username, string Uid)
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("Username", username);
            BsonDocument userDocument = collection.Find(filter).FirstOrDefault();

            BsonArray myArray = userDocument.GetValue("Followings").AsBsonArray;

            bool exists = myArray.Any(x => x.AsString == Uid);

            if (!exists)
            {
                myArray.Add(Uid);
            }

            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("Followings", myArray);
            collection.UpdateOne(filter, update);

        }

        public void addFollower(string username, string Uid)
        {
            var client = GetMongoClient();
            var database = client.GetDatabase("User-Auth");

            var collection = database.GetCollection<BsonDocument>("User");

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("Username", username);
            BsonDocument userDocument = collection.Find(filter).FirstOrDefault();

            BsonArray myArray = userDocument.GetValue("Followers").AsBsonArray;
            bool exists = myArray.Any(x => x.AsString == Uid);

            if (!exists)
            {
                myArray.Add(Uid);
            }

            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("Followers", myArray);
            collection.UpdateOne(filter, update);

        }
    }
}
