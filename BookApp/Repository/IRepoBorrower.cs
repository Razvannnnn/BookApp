using BookApp.Domain;

namespace BookApp.Repository;

/// <summary>
/// Interface for the Borrower repository.
/// </summary>
public interface IRepoBorrower: IRepository<Borrower, long>
{
    
}