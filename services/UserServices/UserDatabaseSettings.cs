namespace BlogWithMongo_BackEnd.UserServices
{
    public class UserDatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string UserCollectionName { get; set; } = null;
    }
}
