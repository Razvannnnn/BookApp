using BookApp.Domain;

namespace BookApp.Repository;

/// <summary>
/// Interface for the BorrowRecord repository.
/// </summary>
public interface IRepoBorrowRecord: IRepository<BorrowRecord, long>
{
    IEnumerable<BorrowRecord> GetAllBorrowRecordsForBorrower(long idBorrower);
    void ReturnBook(long idBorrowRecord);
}