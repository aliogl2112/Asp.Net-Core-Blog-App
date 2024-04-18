namespace BlogApp.Entity
{
    public class Tag:EntityBase
    {
        public string? Text { get; set; }
        public string? URL { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
