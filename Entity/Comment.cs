using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entity
{
    public class Comment:EntityBase
    {
        public string? Text { get; set; }
        [DataType(DataType.Date)] //saat olmadan yalnızca tarih bilgisini alır
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}")]
        public DateTime PublishedOn { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; } = null!;
        public int UserID { get; set; }
        public User User { get; set; } = null!;


    }
}
