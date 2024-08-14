using APIBookCatalog.Context;

namespace APIBookCatalog.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IBookRepository? _bookRep;
    private ICategoryRepository? _categoryRep;
    public AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            return _categoryRep = _categoryRep ?? new CategoryRepository(_context);
        }
    }

    public IBookRepository BookRepository
    {
        get
        {
            return _bookRep = _bookRep ?? new BookRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
        
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
