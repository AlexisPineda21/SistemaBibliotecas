using Microsoft.EntityFrameworkCore;

namespace SistemaBibliotecas.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasIndex(c => c.Email).IsUnique();
            //modelBuilder.Entity<Room>().HasIndex("Number", "HotelId").IsUnique();
        }
        //public DbSet<Book> Books { get; set; }

        //public DbSet<Client> Clients { get; set; }

        //public DbSet<Borrowing> Borrowings { get; set; }
    }
}
