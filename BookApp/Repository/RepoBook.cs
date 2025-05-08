using System.Data.SQLite;
using BookApp.Domain;
using BookApp.Utils;

namespace BookApp.Repository;

public class RepoBook : IRepoBook
{
    private readonly SQLiteConnection _connection = DBUtils.GetConnection();
    
    /// <summary>
    /// Finds a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Book FindOne(long id)
    {
        String select = "SELECT * FROM books WHERE id_book = @id";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        command.Parameters.AddWithValue("@id", id);
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            var book = new Book(
                (long)reader["id_book"],
                (string)reader["title"],
                (string)reader["author"],
                (long)reader["quantity"],
                (long)reader["available"]
            );
            return book;
        }
        return null;
    }

    /// <summary>
    /// Finds all books in the database.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Book> FindAll()
    {
        String select = "SELECT * FROM books";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        SQLiteDataReader reader = command.ExecuteReader();
        List<Book> books = new List<Book>();
        while (reader.Read())
        {
            var book = new Book(
                (long)reader["id_book"],
                (string)reader["title"],
                (string)reader["author"],
                (long)reader["quantity"],
                (long)reader["available"]
            );
            books.Add(book);
        }
        return books;
    }

    /// <summary>
    /// Saves a book to the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Save(Book entity)
    {
        String insert = "INSERT INTO books (title, author, quantity, available) VALUES (@title, @author, @quantity, @available)";
        SQLiteCommand command = new SQLiteCommand(insert, _connection);
        command.Parameters.AddWithValue("@title", entity.Title);
        command.Parameters.AddWithValue("@author", entity.Author);
        command.Parameters.AddWithValue("@quantity", entity.Quantity);
        command.Parameters.AddWithValue("@available", entity.Available);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Deletes a book from the database.
    /// </summary>
    /// <param name="id"></param>
    public void Delete(long id)
    {
        String delete = "DELETE FROM books WHERE id_book = @id";
        SQLiteCommand command = new SQLiteCommand(delete, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Updates a book in the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(Book entity)
    {
        String update = "UPDATE books SET title = @title, author = @author, quantity = @quantity, available = @available WHERE id_book = @id";
        SQLiteCommand command = new SQLiteCommand(update, _connection);
        command.Parameters.AddWithValue("@title", entity.Title);
        command.Parameters.AddWithValue("@author", entity.Author);
        command.Parameters.AddWithValue("@quantity", entity.Quantity);
        command.Parameters.AddWithValue("@available", entity.Available);
        command.Parameters.AddWithValue("@id", entity.Id);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Borrows a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void BorrowBook(long id)
    {
        String update = "UPDATE books SET available = available - 1 WHERE id_book = @id";
        SQLiteCommand command = new SQLiteCommand(update, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }
    
    /// <summary>
    /// Returns a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void ReturnBook(long id)
    {
        String update = "UPDATE books SET available = available + 1 where id_book = @id";
        SQLiteCommand command = new SQLiteCommand(update, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }
}