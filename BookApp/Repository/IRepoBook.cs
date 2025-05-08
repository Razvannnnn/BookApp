using BookApp.Domain;

namespace BookApp.Repository;

/// <summary>
/// Interface for the Book repository.
/// </summary>
public interface IRepoBook : IRepository<Book, long>
{
    void BorrowBook(long id);
    void ReturnBook(long id);
}