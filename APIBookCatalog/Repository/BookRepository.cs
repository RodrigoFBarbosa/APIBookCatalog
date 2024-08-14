using APIBookCatalog.Context;
using APIBookCatalog.Models;

namespace APIBookCatalog.Repository;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {

    }
}
