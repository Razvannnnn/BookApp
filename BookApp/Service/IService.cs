using BookApp.Domain;

namespace BookApp.Service;

public interface IService
{
    IEnumerable<Book> GetAllBooks();
    void BorrowBook(long id);
    void ReturnBook(long id_book, long id_borrowRecord);
    void DeleteBook(long id);
    void AddBook(Book book);
    Book FindBook(long id);
    IEnumerable<Borrower> GetAllBorrowers();
    void AddBorrower(Borrower borrower);
    Borrower FindBorrower(long id);
    void DeleteBorrower(long id);
    void UpdateBorrower(Borrower borrower);
    void AddBorrowRecord(BorrowRecord borrowRecord);
    IEnumerable<BorrowRecord> GetAllBorrowRecords();
    void DeleteBorrowRecord(long id);
    BorrowRecord FindBorrowRecord(long id);
    IEnumerable<Object> GetAllBorrowRecordsForBorrower(long id);
}