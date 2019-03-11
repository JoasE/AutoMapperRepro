using System;
using System.Collections.Generic;

namespace AutoMapperRepro.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public class ViewDto
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public string Text { get; set; }
            public Comment.ViewDto LastComment { get; set; }
        }
    }
}
