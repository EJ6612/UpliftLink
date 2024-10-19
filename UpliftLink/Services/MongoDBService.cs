using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UpliftLink.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoDBService(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _usersCollection = database.GetCollection<User>(collectionName);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("DeviceId", id);
            return await _usersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            var filter = Builders<User>.Filter.Eq("DeviceId", id);
            await _usersCollection.ReplaceOneAsync(filter, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("DeviceId", id);
            await _usersCollection.DeleteOneAsync(filter);
        }
    }

    public class User
    {
        public ObjectId Id { get; set; }
        public string DeviceId { get; set; }
        public string Name { get; set; }
    }
}
