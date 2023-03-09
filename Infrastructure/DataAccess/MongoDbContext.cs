using Core.Entities;
using Infrastructure.DataAccess.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infrastructure.DataAccess;

public class MongoDbContext
{
    public MongoDbContext(IOptions<MongoConfiguration> configurations)
    {
        var client = new MongoClient(configurations.Value.ConnectionString);
        var database = client.GetDatabase(configurations.Value.DatabaseName);


        BsonClassMap.RegisterClassMap<User>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty(c => c.Id);
        });


        User = database.GetCollection<User>("users");
    }

    public IMongoCollection<User> User { get; set; }
}
