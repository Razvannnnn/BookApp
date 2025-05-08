namespace BookApp.Domain;

public class Book: Entity<long>
{
    public string Title { get; }
    public string Author { get; }
    public long Quantity { get; }
    public long Available { get; set; }
    
    public long Id
    {
        get => GetId();
        set => SetId(value);
    }
    
    /// <summary>
    /// Constructor for Book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="quantity"></param>
    /// <param name="available"></param>
    public Book(long id, string title, string author, long quantity, long available)
    {
        SetId(id);
        this.Title = title;
        this.Author = author;
        this.Quantity = quantity;
        this.Available = available;
    }
    
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Quantity: {Quantity}, Available: {Available}";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        var book = (Book)obj;
        return Title.Equals(book.Title) && Author.Equals(book.Author) && Quantity == book.Quantity && Available == book.Available;
    }

    protected bool Equals(Book other)
    {
        return Title == other.Title && Author == other.Author && Quantity == other.Quantity && Available == other.Available;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Author, Quantity, Available);
    }
}