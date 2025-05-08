using System.Data.SQLite;
using BookApp.Domain;
using BookApp.Utils;

namespace BookApp.Repository;

public class RepoBorrowRecord: IRepoBorrowRecord
{
    private readonly SQLiteConnection _connection = DBUtils.GetConnection();

    /// <summary>
    /// Finds a borrow record by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BorrowRecord FindOne(long id)
    {
        string select = "SELECT * FROM borrowRecord WHERE id_borrowRecord = @id";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        command.Parameters.AddWithValue("@id", id);
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            var borrowRecord = new BorrowRecord(
                (long)reader["id_borrowRecord"],
                (long)reader["id_borrower"],
                (long)reader["id_book"],
                (DateTime)reader["borrowed_at"],
                (DateTime)reader["returned_at"]
            );
            return borrowRecord;
        }
        return null;
    }

    /// <summary>
    /// Finds all borrow records in the database.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<BorrowRecord> FindAll()
    {
        string select = "SELECT * FROM borrowRecord";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        SQLiteDataReader reader = command.ExecuteReader();
        List<BorrowRecord> borrowRecords = new List<BorrowRecord>();
        while (reader.Read())
        {
            var borrowRecord = new BorrowRecord(
                (long)reader["id_borrowRecord"],
                (long)reader["id_borrower"],
                (long)reader["id_book"],
                (DateTime)reader["borrowed_at"],
                (DateTime)reader["returned_at"]
            );
            borrowRecords.Add(borrowRecord);
        }
        return borrowRecords;
    }

    /// <summary>
    /// Saves a new borrow record to the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Save(BorrowRecord entity)
    {
        string insert = "INSERT INTO borrowRecord (id_book, id_borrower, borrowed_at, returned_at) VALUES (@id_book, @id_borrower, @borrowed_at, @returned_at)";
        SQLiteCommand command = new SQLiteCommand(insert, _connection);
        command.Parameters.AddWithValue("@id_book", entity.IdBook);
        command.Parameters.AddWithValue("@id_borrower", entity.IdBorrower);
        command.Parameters.AddWithValue("@borrowed_at", entity.BorrowedAt);
        command.Parameters.AddWithValue("@returned_at", entity.ReturnedAt);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Deletes a borrow record from the database.
    /// </summary>
    /// <param name="id"></param>
    public void Delete(long id)
    {
        string delete = "DELETE FROM borrowRecord WHERE id_borrowRecord = @id";
        SQLiteCommand command = new SQLiteCommand(delete, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Updates a borrow record in the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(BorrowRecord entity)
    {
        string update = "UPDATE borrowRecord SET id_book = @id_book, id_borrower = @id_borrower, borrowed_at = @borrowed_at, returned_at = @returned_at WHERE id_borrowRecord = @id";
        SQLiteCommand command = new SQLiteCommand(update, _connection);
        command.Parameters.AddWithValue("@id_book", entity.IdBook);
        command.Parameters.AddWithValue("@id_borrower", entity.IdBorrower);
        command.Parameters.AddWithValue("@borrowed_at", entity.BorrowedAt);
        command.Parameters.AddWithValue("@returned_at", entity.ReturnedAt);
        command.Parameters.AddWithValue("@id", entity.Id);
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Finds all borrow records for a specific borrower.
    /// </summary>
    /// <param name="idBorrower"></param>
    /// <returns</returns>
    public IEnumerable<BorrowRecord> GetAllBorrowRecordsForBorrower(long idBorrower)
    {
        string select = "SELECT * FROM borrowRecord WHERE id_borrower = @id_borrower";
        SQLiteCommand command = new SQLiteCommand(select, _connection);
        command.Parameters.AddWithValue("@id_borrower", idBorrower);
        SQLiteDataReader reader = command.ExecuteReader();
        List<BorrowRecord> borrowRecords = new List<BorrowRecord>();
        while (reader.Read())
        {
            var returnedAtValue = reader["returned_at"] == DBNull.Value
                ? (DateTime?)null
                : (DateTime)reader["returned_at"];

            var borrowRecord = new BorrowRecord(
                (long)reader["id_borrowRecord"],
                (long)reader["id_borrower"],
                (long)reader["id_book"],
                (DateTime)reader["borrowed_at"],
                returnedAtValue
            );

            borrowRecords.Add(borrowRecord);
        }
        return borrowRecords;
    }

    /// <summary>
    /// Marks a book as returned by updating the returned_at field in the database.
    /// </summary>
    /// <param name="idBorrowRecord"></param>
    public void ReturnBook(long idBorrowRecord)
    {
        string update = "UPDATE borrowRecord SET returned_at = @returned_at WHERE id_borrowRecord = @id";
        SQLiteCommand command = new SQLiteCommand(update, _connection);
        command.Parameters.AddWithValue("@returned_at", DateTime.Now);
        command.Parameters.AddWithValue("@id", idBorrowRecord);
        command.ExecuteNonQuery();
    }
}