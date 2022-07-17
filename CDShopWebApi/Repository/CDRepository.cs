using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using CDShopApp.Domain;
namespace CDShopApp.Repositories;

public class CDRepository : ICDRepository
{
    private readonly string _connectionString;

    public CDRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<CD> GetAll()
    {
        var result = new List<CD>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_cd], " +
            "[name], " +
            "[artist], " +
            "[release_date], " +
            "[price] " +
            "from [CD]";

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new CD(
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["artist"]),
                Convert.ToString(reader["release_date"]),
                Convert.ToInt32(reader["price"])
                ));
        }
        return result;
    }

    public CD GetByName(string name)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_cd], " +
            "[name], " +
            "[artist], " +
            "[release_date], " +
            "[price] " +
            "from [CD] " +
            "where [name] = @name";
        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            return new CD(
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["artist"]),
                Convert.ToString(reader["release_date"]),
                Convert.ToInt32(reader["price"])
                );
        }
        else
        {
            return null;
        }
    }

    public List<CD> GetByArtist(string artist)
    {
        var result = new List<CD>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_cd], " +
            "[name], " +
            "[artist], " +
            "[release_date], " +
            "[price] " +
            "from [CD] " +
            "where [artist] = @artist";
        sqlCommand.Parameters.Add("@artist", SqlDbType.NVarChar, 50).Value = artist;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new CD(
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["artist"]),
                Convert.ToString(reader["release_date"]),
                Convert.ToInt32(reader["price"])
                ));
        }
        return result;
    }

    public CD GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_cd], " +
            "[name], " +
            "[artist], " +
            "[release_date], " +
            "[price] " +
            "from [CD] " +
            "where [id_cd] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int, 50).Value = id;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            return new CD(
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["artist"]),
                Convert.ToString(reader["release_date"]),
                Convert.ToInt32(reader["price"])
                );
        }
        else
        {
            return null;
        }
    }

    public List<CD> GetByReleaseDate(string releaseDate)
    {
        var result = new List<CD>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_cd], " +
            "[name], " +
            "[artist], " +
            "[release_date], " +
            "[price] " +
            "from [CD] " +
            "where [release_date] = @release_date";
        sqlCommand.Parameters.Add("@release_date", SqlDbType.NVarChar, 50).Value = releaseDate;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new CD(
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["artist"]),
                Convert.ToString(reader["release_date"]),
                Convert.ToInt32(reader["price"])
                ));
        }
        return result;
    }

    public List<CD> GetByPrice(int price)
    {
        var result = new List<CD>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_cd], " +
            "[name], " +
            "[artist], " +
            "[release_date], " +
            "[price] " +
            "from [CD] " +
            "where [price] = @price";
        sqlCommand.Parameters.Add("@price", SqlDbType.Money).Value = price;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new CD(
                Convert.ToInt32(reader["id_cd"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["artist"]),
                Convert.ToString(reader["release_date"]),
                Convert.ToInt32(reader["price"])
                ));
        }
        return result;
    }

    public List<CDPurchaseCount> GetPurchaseCount()
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
        while (reader.Read())
        {
            result.Add(new CDPurchaseCount(
                Convert.ToString(reader["name"]),
                Convert.ToInt32(reader[1])
                ));
        }

        return result;
    }

    public int Add(CD cD)
    {
        if (cD == null)
        {
            throw new ArgumentNullException(nameof(cD));
        }

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = 
            "insert into [CD] (name, artist, release_date, price)" +
            "values @name, @artist, @release_date, price";
        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = cD.Name;
        sqlCommand.Parameters.Add("@artist", SqlDbType.NVarChar, 50).Value = cD.Artist;
        sqlCommand.Parameters.Add("@release_date", SqlDbType.NVarChar, 50).Value = cD.ReleaseDate;
        sqlCommand.Parameters.Add("@price", SqlDbType.Int).Value = cD.Price;
        sqlCommand.ExecuteNonQuery();

        return Convert.ToInt32(sqlCommand.ExecuteScalar());
    }

    public void Update(CD cD)
    {
        if (cD == null)
        {
            throw new ArgumentNullException(nameof(cD));
        }

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = "update [CD] set [price] = @price where [id_cd] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = cD.Id;
        sqlCommand.Parameters.Add("@price", SqlDbType.Money).Value = cD.Price;
        sqlCommand.ExecuteNonQuery();
    }

    public void Delete(CD cD)
    {
        if (cD == null)
        {
            throw new ArgumentNullException(nameof(cD));
        }

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = "delete [CD] where [id_cd] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = cD.Id;
        sqlCommand.ExecuteNonQuery();
    }
}