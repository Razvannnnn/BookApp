namespace BookApp.Domain;

public class Borrower: Entity<long>
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public long Id
    {
        get => GetId();
        set => SetId(value);
    }
    
    
    /// <summary>
    /// Constructor for Borrower
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="email"></param>
    public Borrower(long id, string name, string email)
    {
        SetId(id);
        this.Name = name;
        this.Email = email;
    }
    
    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        var borrower = (Borrower)obj;
        return Name.Equals(borrower.Name) && Email.Equals(borrower.Email);
    }
}