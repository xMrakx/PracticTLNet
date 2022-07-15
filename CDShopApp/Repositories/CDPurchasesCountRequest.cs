using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using CDShopApp.Models;
namespace CDShopApp.Repositories;

public class CDPurchaseCountRequest : ICDPurchaseCountRequest
{
    private readonly string _connectionString;

    public CDPurchaseCountRequest(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IReadOnlyList<CDPurchaseCount> GetAll()
    {
        var result = new List<CDPurchaseCount>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select " +
            "[name], " +
            "count(Purchase.id_purchase) " +
            "from [CD] " +
            "right join [Purchase] on [Purchase].id_cd = [CD].id_cd " +
            "group by name";

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while(reader.Read())
        {
            result.Add(new CDPurchaseCount(
                Convert.ToString(reader["name"]),
                Convert.ToInt32(reader[1])
                ));
        }
        
        return result;
    }
}