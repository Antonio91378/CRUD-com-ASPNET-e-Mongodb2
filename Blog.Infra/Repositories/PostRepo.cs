using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace Blog.Infra.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly IContext _context;

        public PostRepo()
        {
            _context = new Context();
        }

        public async Task CreatePostAsync(Post Post)
        {
            await _context.Posts.InsertOneAsync(Post);
        }

        public async Task<List<Post>> DisplayAllPostsAsync()
        {
            var options = new AggregateOptions()
            {
                AllowDiskUse = true
            };

            PipelineDefinition<Post, BsonDocument> pipeline = new BsonDocument[]{
                new BsonDocument("$project", new BsonDocument()
                        .Add("_id", 0)
                        .Add("Posts", "$$ROOT")),
                new BsonDocument("$lookup", new BsonDocument()
                        .Add("localField", "Posts.codigoPost")
                        .Add("from", "Users")
                        .Add("foreignField", "codigoUser")
                        .Add("as", "Users")),
                new BsonDocument("$unwind", new BsonDocument()
                        .Add("path", "$User")
                        .Add("preserveNullAndEmptyArrays", new BsonBoolean(false))),
                new BsonDocument("$project", new BsonDocument()
                        .Add("Posts._id", "$Posts._id")
                        .Add("Posts.PostAutor", "$User.nome")
                        .Add("Posts.PostAutorEmail", "$User.email")
                        .Add("Posts.title","$Posts.title")
                        .Add("Posts.content","$Posts.content")
                        .Add("Posts.tags","$Posts.tags")
                        .Add("_id", 0))
            };

            List<Post> listPosts = new List<Post>();
            using (var cursor = await _context.Posts.AggregateAsync(pipeline, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        JObject jObject = JObject.Parse(document.ToJson().Replace("_id", "id").Replace("ObjectId(", "").Replace(")", ""));
                        var somenteOfertas = jObject["Posts"].ToString();
                        var adicionando = JsonConvert.DeserializeObject<Post>(somenteOfertas);
                        listPosts.Add(adicionando);
                    }
                }
            }
            return listPosts;
            // var Posts = await _context.Posts.FindAsync(_ => true);
            // return Posts.ToList();
        }

        public async Task<Post> DisplayPostByIdAsync(string id)
        {
            var Post = await _context.Posts.Find(_ => _.Id == id).FirstOrDefaultAsync();
            return Post;
        }

        public async Task DeletePostByIdAsync(string id)
        {
            await _context.Posts.DeleteOneAsync(_ => _.Id == id);
        }
    }
}
