﻿namespace BlogApp.Entity
{
    public class User:EntityBase
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
