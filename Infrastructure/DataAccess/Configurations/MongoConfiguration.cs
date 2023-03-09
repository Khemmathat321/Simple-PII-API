namespace Infrastructure.DataAccess.Configurations;

public class MongoConfiguration
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
