using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        //IQueryable, verilerin filtreleme yapılarak alınabilmesini sağlar. Eğer IEnumerable tanımlasaydık önce tüm veriler getirilir, daha sonra filtreleme yapılırdı.
        void CreateComment(Comment comment);
    }
}
