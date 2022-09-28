using API.Blog.BackEnd.ConfigExtensions;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using API.Blog.BackEnd.Infra.Integrations;
using API.Blog.BackEnd.Infra.Repositories;
using API.Blog.BackEnd.Service;
using Blog.Domain.Interfaces;
using Blog.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<ICommentRepo, CommentRepo>();

builder.Services.AddScoped<IRepliedCommentRepo, RepliedCommentRepo>();

builder.Services.AddScoped<IIntegrationApiImageUploader, IntegrationApiImageUploader>();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context2>(options =>
        options.UseSqlServer("Initial Catalog=CommentsDB; Data Source=localhost,1450; Persist Security Info=True;User ID=SA;PassWord= 2Secure*Password2", b => b.MigrationsAssembly("API.Blog.BackEnd")));

builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

DataBaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();