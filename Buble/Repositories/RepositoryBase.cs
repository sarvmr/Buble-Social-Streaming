using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buble.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _SqlConnectionString;
        private readonly string _mongoConnectionString;
        private MongoClientSettings _settings;

        public RepositoryBase()
        {
            _SqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            _mongoConnectionString = "mongodb+srv://rai-sahil:Tkdcrc987@cluster0.dibrkuh.mongodb.net/?retryWrites=true&w=majority";

            _settings = MongoClientSettings.FromConnectionString(_mongoConnectionString);
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_SqlConnectionString);
        }

        public MongoClient GetMongoClient()
        {
            return new MongoClient(_settings);
        }
    }
}
