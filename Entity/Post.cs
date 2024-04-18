namespace BlogApp.Entity
{
    public class Post:EntityBase
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? URL { get; set; }
        public string? Image { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } = null!;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
