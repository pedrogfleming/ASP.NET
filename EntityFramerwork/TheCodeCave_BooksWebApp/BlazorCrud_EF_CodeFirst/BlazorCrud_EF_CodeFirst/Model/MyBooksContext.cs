using Microsoft.EntityFrameworkCore;

namespace BlazorCrud_EF_CodeFirst.Model
{
    public class MyBooksContext : DbContext
    {
        public DbSet<Book> Books { get;set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BlazorCRUD_EF_CodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
