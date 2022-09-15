using API.Blog.BackEnd.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<User> Users { get; }
        public IMongoCollection<Post> Posts { get; }
    }
}
