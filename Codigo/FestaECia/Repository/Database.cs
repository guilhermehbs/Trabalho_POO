using System.Data.SqlClient;

namespace FestaECia.Repository;
public class Database
{
	private readonly string _connectionString;

	public Database()
	{
		_connectionString = "Server = trabalhopoo2024.database.windows.net; Database = FestaECia; Uid = AzureSA; Pwd = Trabalhopoo2024";
	}

	public SqlConnection GetConnection()
	{
		return new SqlConnection(_connectionString);
	}
}
