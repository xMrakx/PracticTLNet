using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using CDShopApp.Models;
namespace CDShopApp.Repositories;

public class RawSqlWorkerRepository : IWorkerRepository
{
    private readonly string _connectionString;

    public RawSqlWorkerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IReadOnlyList<Worker> GetAll()
    {
        var result = new List<Worker>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_worker], " +
            "[name], " +
            "[surname], " +
            "[birthday], " +
            "[phone_number] " +
            "from [Worker]";

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Worker(
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["surname"]),
                Convert.ToString(reader["birthday"]),
                Convert.ToString(reader["phone_number"])
                ));
        }
        return result;
    }

    public Worker GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_worker], " +
            "[name], " +
            "[surname], " +
            "[birthday], " +
            "[phone_number] " +
            "from [Worker] " +
            "where [id_worker] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int, 50).Value = id;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            return new Worker(
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["surname"]),
                Convert.ToString(reader["birthday"]),
                Convert.ToString(reader["phone_number"])
                );
        }
        else
        {
            return null;
        }
    }
    public IReadOnlyList<Worker> GetByName(string name)
    {
        var result = new List<Worker>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_worker], " +
            "[name], " +
            "[surname], " +
            "[birthday], " +
            "[phone_number] " +
            "from [Worker] " +
            "where [name] = @name";
        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Worker(
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["surname"]),
                Convert.ToString(reader["birthday"]),
                Convert.ToString(reader["phone_number"])
                ));
        }
        return result;
    }

    public IReadOnlyList<Worker> GetBySurname(string surname)
    {
        var result = new List<Worker>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_worker], " +
            "[name], " +
            "[surname], " +
            "[birthday], " +
            "[phone_number] " +
            "from [Worker] " +
            "where [surname] = @surname";
        sqlCommand.Parameters.Add("@surname", SqlDbType.NVarChar, 50).Value = surname;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Worker(
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["surname"]),
                Convert.ToString(reader["birthday"]),
                Convert.ToString(reader["phone_number"])
                ));
        }
        return result;
    }

    public IReadOnlyList<Worker> GetByBirthday(string birthday)
    {
        var result = new List<Worker>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_worker], " +
            "[name], " +
            "[surname], " +
            "[birthday], " +
            "[phone_number] " +
            "from [Worker] " +
            "where [birthday] = @birthday";
        sqlCommand.Parameters.Add("@birthday", SqlDbType.NVarChar, 50).Value = birthday;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Worker(
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["surname"]),
                Convert.ToString(reader["birthday"]),
                Convert.ToString(reader["phone_number"])
                ));
        }
        return result;
    }

    public Worker GetByPhoneNumber(string number)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText =
            "select [id_worker], " +
            "[name], " +
            "[surname], " +
            "[birthday], " +
            "[phone_number] " +
            "from [Worker] " +
            "where [phone_number] = @number";
        sqlCommand.Parameters.Add("@number", SqlDbType.NVarChar, 50).Value = number;

        using SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            return new Worker(
                Convert.ToInt32(reader["id_worker"]),
                Convert.ToString(reader["name"]),
                Convert.ToString(reader["surname"]),
                Convert.ToString(reader["birthday"]),
                Convert.ToString(reader["phone_number"])
                );
        }
        else
        {
            return null;
        }
    }

    public void Update(Worker worker)
    {
        if (worker == null)
        {
            throw new ArgumentNullException(nameof(worker));
        }

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = 
            "update [Worker] set " +
            "[name] = @name, " +
            "[surname] = @surname, " +
            "[phone_number] = @phoneNumber " +
            "where [id_worker] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = worker.Id;
        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = worker.Name;
        sqlCommand.Parameters.Add("@surname", SqlDbType.NVarChar, 50).Value = worker.Name;
        sqlCommand.Parameters.Add("@phone_number", SqlDbType.NVarChar, 50).Value = worker.Name;
        sqlCommand.ExecuteNonQuery();
    }

    public void Delete(Worker worker)
    {
        if (worker == null)
        {
            throw new ArgumentNullException(nameof(worker));
        }

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = "delete [Worker] where [id_worker] = @id";
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = worker.Id;
        sqlCommand.ExecuteNonQuery();
    }
}

