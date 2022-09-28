namespace Blog.Utils
{
    public static class ApplicationSettings
    {
        public static string GetMongoDBConnectionString()
        {
            var configuration = new Configuration();
            return configuration.ConfiguracaoDoArquivoAppSettings["Database:ConnectionString"];
        }
        public static string GetConnectionStringEntity()
        {
            Configuration configuration = new Configuration();
            return configuration.ConfiguracaoDoArquivoAppSettings["Database2:ConnectionString2"];
        }
        public static string GetForeingApi()
        {
            Configuration configuration = new Configuration();
            return configuration.ConfiguracaoDoArquivoAppSettings["ApiImageUploader"];
        }
    }
}