using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        { }
        public DbSet<Book> Books { get; set; }
    }
}
