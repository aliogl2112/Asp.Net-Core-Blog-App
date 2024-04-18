using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        //IQueryable, verilerin filtreleme yapılarak alınabilmesini sağlar. Eğer IEnumerable tanımlasaydık önce tüm veriler getirilir, daha sonra filtreleme yapılırdı.

        void CreatePost(Post post);
    }
}
