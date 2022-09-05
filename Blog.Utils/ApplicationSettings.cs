namespace Blog.Utils
{
    public static class ApplicationSettings
    {
        public static string GetMongoDBConnectionString()
        {
            var configuration = new Configuration();
            return configuration.ConfiguracaoDoArquivoAppSettings["UsersDatabase:ConnectionString"];
        }
    }
}