using APIBookCatalog.Context;
using APIBookCatalog.Models;
using System.Linq.Expressions;

namespace APIBookCatalog.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
