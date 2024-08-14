using APIBookCatalog.Context;
using System.Linq.Expressions;

namespace APIBookCatalog.Repository;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? Get(Expression<Func<T, bool>> predicate); //permite que eu utilize a expressão lambda
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}
