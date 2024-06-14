using Microsoft.Data.SqlClient;

namespace FestaECia.Repository;

public class IdRepository
{
    private static readonly Database _database;

    public IdRepository()
    {
        _database = new Database();
    }
    
    public static int GetNextId()
    {
        int nextId = 1;

        using (var connection = _database.GetConnection())
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT MAX(id) FROM tb_party", connection))
            {
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    nextId = (int)result + 1; 
                }
            }
        }
        return nextId;
    }
}