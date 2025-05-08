namespace BookApp.Domain;

public class BorrowRecord: Entity<long>
{
    public long IdBook { get; set; }
    public long IdBorrower { get; set; }
    public DateTime BorrowedAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    
    public long Id
    {
        get => GetId();
        set => SetId(value);
    }
    
    /// <summary>
    /// Constructor for BorrowRecord
    /// </summary>
    /// <param name="id"></param>
    /// <param name="idBorrower"></param>
    /// <param name="idBook"></param>
    /// <param name="borrowedAt"></param>
    /// <param name="returnedAt"></param>
    public BorrowRecord(long id, long idBorrower, long idBook, DateTime borrowedAt, DateTime? returnedAt)
    {
        SetId(id);
        this.IdBorrower = idBorrower;
        this.IdBook = idBook;
        this.BorrowedAt = borrowedAt;
        this.ReturnedAt = returnedAt;
    }
    
    public override string ToString()
    {
        return $"Borrower ID: {IdBorrower}, Book ID: {IdBook}, Borrowed At: {BorrowedAt}, Returned At: {ReturnedAt}";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        var borrowRecord = (BorrowRecord)obj;
        return IdBorrower.Equals(borrowRecord.IdBorrower) && IdBook.Equals(borrowRecord.IdBook) && BorrowedAt.Equals(borrowRecord.BorrowedAt) && ReturnedAt.Equals(borrowRecord.ReturnedAt);
    }
    
}