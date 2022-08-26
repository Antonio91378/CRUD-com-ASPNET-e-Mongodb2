

using BlogWithMongo_BackEnd.Database;
using BlogWithMongo_BackEnd.PostServices;
using BlogWithMongo_BackEnd.UserServices;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Service to connect the UsersCollection to the mongo
builder.Services.Configure<UserDatabaseSettings>
    (builder.Configuration.GetSection("UsersDatabase"));
builder.Services.AddSingleton<UserService>(); // ==========> importante kkkk
// Service to connect the PostsCollection to the mongo
builder.Services.Configure<PostDatabaseSettings>
    (builder.Configuration.GetSection("PostsDatabase"));
builder.Services.AddSingleton<PostService>(); // ==========> importante kkkk

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
