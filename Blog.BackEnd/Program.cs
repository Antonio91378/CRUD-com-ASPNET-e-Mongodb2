using API.Blog.BackEnd.ConfigExtensions;
using API.Blog.BackEnd.Infra.Contexts;
using Blog.Domain.Interfaces;
using Blog.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context2>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("API.Blog.BackEnd")));
var app = builder.Build();

DataBaseManagementService.MigrationInitialisation(app);

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();