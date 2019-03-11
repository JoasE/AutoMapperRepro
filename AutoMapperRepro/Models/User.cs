using System;
using System.Collections.Generic;

namespace AutoMapperRepro.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public class ViewDto
        {
            public Guid Id { get; set; }
            public ICollection<Post.ViewDto> Posts { get; set; }
        }
    }
}
