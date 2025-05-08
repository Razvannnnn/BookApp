using BookApp.Domain;
using BookApp.Observer;
using BookApp.Repository;

namespace BookApp.Service;

public class Service: IService, IObservable
{
    private IRepoBook _repoBook;
    private IRepoBorrower _repoBorrower;
    private IRepoBorrowRecord _repoBorrowRecord;
    private List<IObserver> _observers = new();
    
    public Service(IRepoBook repoBook, IRepoBorrower repoBorrower, IRepoBorrowRecord repoBorrowRecord)
    {
        _repoBook = repoBook;
        _repoBorrower = repoBorrower;
        _repoBorrowRecord = repoBorrowRecord;
    }

    /// <summary>
    /// Returns all books from the repository.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Book> GetAllBooks()
    {
        return _repoBook.FindAll();
    }

    /// <summary>
    /// Borrows a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void BorrowBook(long id)
    {
        _repoBook.BorrowBook(id);
        NotifyObservers();
    }

    /// <summary>
    /// Returns a book by its ID and the borrow record ID.
    /// </summary>
    /// <param name="id_book"></param>
    /// <param name="id_borrowRecord"></param>
    public void ReturnBook(long id_book, long id_borrowRecord)
    {
        _repoBook.ReturnBook(id_book);
        _repoBorrowRecord.ReturnBook(id_borrowRecord);
        NotifyObservers();
    }

    /// <summary>
    /// Deletes a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void DeleteBook(long id)
    {
        _repoBook.Delete(id);
        NotifyObservers();
    }

    /// <summary>
    /// Adds a new book to the repository.
    /// </summary>
    /// <param name="book"></param>
    public void AddBook(Book book)
    {
        _repoBook.Save(book);
        NotifyObservers();
    }
    
    /// <summary>
    /// Finds a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Book FindBook(long id)
    {
        return _repoBook.FindOne(id);
    }
    
    /// <summary>
    /// Returns all borrowers from the repository.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Borrower> GetAllBorrowers()
    {
        return _repoBorrower.FindAll();
    }
    
    /// <summary>
    /// Adds a new borrower to the repository.
    /// </summary>
    /// <param name="borrower"></param>
    public void AddBorrower(Borrower borrower)
    {
        _repoBorrower.Save(borrower);
        NotifyObservers();
    }
    
    /// <summary>
    /// Deletes a borrower by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void DeleteBorrower(long id)
    {
        _repoBorrower.Delete(id);
        NotifyObservers();
    }
    
    /// <summary>
    /// Updates a borrower's information.
    /// </summary>
    /// <param name="borrower"></param>
    public void UpdateBorrower(Borrower borrower)
    {
        _repoBorrower.Update(borrower);
        NotifyObservers();
    }
    
    /// <summary>
    /// Finds a borrower by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Borrower FindBorrower(long id)
    {
        return _repoBorrower.FindOne(id);
    }
    
    /// <summary>
    /// Returns all borrow records from the repository.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<BorrowRecord> GetAllBorrowRecords()
    {
        return _repoBorrowRecord.FindAll();
    }
    
    /// <summary>
    /// Adds a new borrow record to the repository and updates the book's status.
    /// </summary>
    /// <param name="borrowRecord"></param>
    public void AddBorrowRecord(BorrowRecord borrowRecord)
    {
        _repoBorrowRecord.Save(borrowRecord);
        _repoBook.BorrowBook(borrowRecord.IdBook);
        NotifyObservers();
    }
    
    /// <summary>
    /// Deletes a borrow record by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void DeleteBorrowRecord(long id)
    {
        _repoBorrowRecord.Delete(id);
        NotifyObservers();
    }
    
    /// <summary>
    /// Finds a borrow record by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BorrowRecord FindBorrowRecord(long id)
    {
        return _repoBorrowRecord.FindOne(id);
    }

    /// <summary>
    /// Returns all borrow records for a specific borrower.
    /// </summary>
    /// <param name="id_borrower"></param>
    /// <returns></returns>
    public IEnumerable<object> GetAllBorrowRecordsForBorrower(long id_borrower)
    {
        var borrowRecords = _repoBorrowRecord.GetAllBorrowRecordsForBorrower(id_borrower);
        var books = _repoBook.FindAll();
        var result = from borrowRecord in borrowRecords
                     join book in books on borrowRecord.IdBook equals book.Id
                     select new
                     {
                         TitleN = book.Title,
                         AuthorN = book.Author,
                         BorrowDate = borrowRecord.BorrowedAt,
                         ReturnDate = borrowRecord.ReturnedAt,
                         IdBook = book.Id,
                         IdBorrowRecord = borrowRecord.Id
                     };
        
        return result.ToList();
    }
    
    /// <summary>
    /// Registers an observer to be notified of changes.
    /// </summary>
    /// <param name="observer"></param>
    public void RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }
    
    /// <summary>
    /// Removes an observer from the list of observers.
    /// </summary>
    /// <param name="observer"></param>
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /// <summary>
    /// Notifies all registered observers of changes.
    /// </summary>
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.updateView();
        }
    }
}