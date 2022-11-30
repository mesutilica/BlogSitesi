using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // OnConfiguring metodu entity framework core içerisinden gelir ve veritabanı ayarlarını yapabilmemizi sağlar.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=BlogSitesi; integrated security=true"); // Burada uygulamamızda sql server kullanacağımızı entity framework core a  belirttik. UseSqlServer metoduna () içerisinde connection string ile veritabanı bilgilerimizi parametre olarak gönderebiliyoruz.
            base.OnConfiguring(optionsBuilder);
        }
    }
}
