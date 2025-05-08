using BookApp.Domain;

namespace BookApp.Repository;

/// <summary>
/// Generic interface for a repository.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="ID"></typeparam>
public interface IRepository<T, ID> where T: Entity<ID>
{
    T FindOne(ID id);
    IEnumerable<T> FindAll();
    void Save(T entity);
    void Delete(ID id);
    void Update(T entity);
}