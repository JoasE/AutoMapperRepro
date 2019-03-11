using System;

namespace AutoMapperRepro.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public string Text { get; set; }

        public class ViewDto
        {
            public Guid Id { get; set; }
            public Guid PostId { get; set; }
            public string Text { get; set; }
        }
    }
}
