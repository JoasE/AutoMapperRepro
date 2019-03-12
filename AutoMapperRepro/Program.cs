using System;
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

            // Copied from var expression declared below.
            var manualQuery = context.Users.Select(dtoUser => new User.ViewDto
            {
                Id = dtoUser.Id,
                Posts = dtoUser.Posts
                    .Select(
                        dtoPost => new Object_205617611___LastComment_Id_Text_UserId
                        {
                            __LastComment = dtoPost.Comments.LastOrDefault(),
                            Id = dtoPost.Id,
                            Text = dtoPost.Text,
                            UserId = dtoPost.UserId
                        })
                    .Select(
                        dtoLet => new Post.ViewDto
                        {
                            Id = dtoLet.Id,
                            LastComment = (dtoLet.__LastComment == null)
                                ? null
                                : new Comment.ViewDto
                                {
                                    Id = dtoLet.__LastComment.Id,
                                    PostId = dtoLet.__LastComment.PostId,
                                    Text = dtoLet.__LastComment.Text
                                },
                            Text = dtoLet.Text,
                            UserId = dtoLet.UserId
                        })
                    .ToList()
            }).FirstOrDefault(x => x.Id == user.Id);

            var projection = context.Users.ProjectTo<User.ViewDto>();
            var expression = projection.Expression;
            var getUser = projection.FirstOrDefault(x => x.Id == user.Id);
        }
    }

    public class Object_205617611___LastComment_Id_Text_UserId
    {
        public Comment __LastComment { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}
