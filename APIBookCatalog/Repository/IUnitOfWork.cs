namespace APIBookCatalog.Repository;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IBookRepository BookRepository { get; }
    void Commit();
}
