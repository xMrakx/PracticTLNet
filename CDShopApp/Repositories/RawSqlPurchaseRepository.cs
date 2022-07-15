using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using CDShopApp.Models;
namespace CDShopApp.Repositories;

public class RawSqlPurchaseRepository : IPurchaseRepository
{
    private readonly string _connectionString;

    public RawSqlPurchaseRepository(string connectonString)
    {
        _connectionString = connectonString;
    }
    public IReadOnlyList<Purchase> GetAll()
    {
        var result = new List<Purchase>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_purchase], " +
            "[id_cd], " +
            "[id_worker], " +
            "[date] from [Purchase]";

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Purchase(
                Convert.ToInt32(reader["id_purchase"]),
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["date"])
                ));
        }
        return result;
    }
    
    public Purchase GetById(int id)
    {
        var result = new List<Purchase>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_purchase], " +
            "[id_cd], " +
            "[id_worker], " +
            "[date] " +
            "from [Purchase] " +
            "where [id_puechase] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int, 50).Value = id;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            return new Purchase(
                Convert.ToInt32(reader["id_purchase"]),
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["date"])
                );
        }
        else
        {
            return null;
        }

    }

    public IReadOnlyList<Purchase> GetByDate(string date)
    {
        var result = new List<Purchase>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_purchase], " +
            "[id_cd], " +
            "[id_worker], " +
            "[date] from [Purchase] " +
            "where [date] = @date";
        sqlCommand.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = date;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Purchase(
                Convert.ToInt32(reader["id_purchase"]),
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["date"])
                ));
        }
        return result;
    }

    public void Delete(Purchase purchase)
    {
        if (purchase == null)
        {
            throw new ArgumentNullException(nameof(purchase));
        }

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = "delete [purchase] where [id_purchase] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = purchase.Id;
        sqlCommand.ExecuteNonQuery();
    }
}