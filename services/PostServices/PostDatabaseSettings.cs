using BlogWithMongo_BackEnd.Database;

namespace BlogWithMongo_BackEnd.PostServices
{
    public class PostDatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
