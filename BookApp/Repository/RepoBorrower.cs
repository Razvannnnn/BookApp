using System.Data.SQLite;
using BookApp.Domain;
using BookApp.Utils;

namespace BookApp.Repository;

public class RepoBorrower: IRepoBorrower
{
    private readonly SQLiteConnection _connection = DBUtils.GetConnection();

    /// <summary>
    /// Finds a borrower by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Borrower FindOne(long id)
    {
        string select = "SELECT * FROM borrower WHERE id_borrower = @id";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        command.Parameters.AddWithValue("@id", id);
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            var borrower = new Borrower(
                (long)reader["id_borrower"],
                (string)reader["name"],
                (string)reader["email"]
            );
            return borrower;
        }
        return null;
    }

    /// <summary>
    /// Finds all borrowers in the database.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Borrower> FindAll()
    {
        string select = "SELECT * FROM borrower";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        SQLiteDataReader reader = command.ExecuteReader();
        List<Borrower> borrowers = new List<Borrower>();
        while (reader.Read())
        {
            var borrower = new Borrower(
                (long)reader["id_borrower"],
                (string)reader["name"],
                (string)reader["email"]
            );
            borrowers.Add(borrower);
        }
        return borrowers;
    }
    
    /// <summary>
    /// Saves a new borrower to the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Save(Borrower entity)
    {
        string insert = "INSERT INTO borrower (name, email) VALUES (@name, @email)";
        SQLiteCommand command = new SQLiteCommand(insert, _connection);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@email", entity.Email);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Deletes a borrower from the database by its ID.
    /// </summary>
    /// <param name="id"></param>
    public void Delete(long id)
    {
        string delete = "DELETE FROM borrower WHERE id_borrower = @id";
        SQLiteCommand command = new SQLiteCommand(delete, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Updates an existing borrower in the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(Borrower entity)
    {
        string update = "UPDATE borrower SET name = @name, email = @email WHERE id_borrower = @id";
        SQLiteCommand command = new SQLiteCommand(update, _connection);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@email", entity.Email);
        command.Parameters.AddWithValue("@id", entity.Id);
        command.ExecuteNonQuery();
    }
}