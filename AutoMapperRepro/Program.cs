using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperRepro.Models;
using MapperConfiguration = AutoMapperRepro.Config.MapperConfiguration;

namespace AutoMapperRepro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());

            var context = new ReproContext();

            var user = new User();
            context.Users.Add(user);
            context.SaveChanges();

            var post = new Post()
            {
                UserId = user.Id
            };
            context.Posts.Add(post);
            context.SaveChanges();

            var comment = new Comment()
            {
                PostId = post.Id
            };
            context.Comments.Add(comment);
            context.SaveChanges();

            context.Dispose();

            context = new ReproContext();

            var getUser = context.Users.ProjectTo<User.ViewDto>().FirstOrDefault(x => x.Id == user.Id);
        }
    }
}
