using System.ComponentModel.DataAnnotations;

namespace BlogSitesi.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "İçerik Adı")]
        public string Name { get; set; }
        [Display(Name = "İçerik Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }
        [StringLength(150), Display(Name = "İçerik Resmi")]
        public string? Image { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public virtual Category? Category { get; set; } // Burada Post sınıfı ile Category sınıfı arasında 1 e 1 (1 post un 1 tane category si olmalıdır) ilişki kurduk. Bu ilişki veritabanı oluştuğunda oraya da yansır ve entity framework de bu ilişkileri dikkate alır.
    }
}
