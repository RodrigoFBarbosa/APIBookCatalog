using APIBookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBookCatalog.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
}
