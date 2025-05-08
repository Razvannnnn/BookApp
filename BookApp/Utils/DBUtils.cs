using System.Configuration;
using System.Data.SQLite;

namespace BookApp.Utils;

public class DBUtils
{
    private static readonly string _connectionString;
    private static SQLiteConnection instance = null;

    static DBUtils()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["Concurs"].ConnectionString;
    }
    
    /// <summary>
    /// Creates a new SQLite connection.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private static SQLiteConnection GetNewConnection()
    {

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Missing connection string in App.config");
        }
        try
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
        catch (SQLiteException ex)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the SQLite connection.
    /// </summary>
    /// <returns></returns>
    public static SQLiteConnection GetConnection()
    {
        if (instance == null || instance.State != System.Data.ConnectionState.Open)
        {
            instance = GetNewConnection();
        }

        return instance;
    }
}