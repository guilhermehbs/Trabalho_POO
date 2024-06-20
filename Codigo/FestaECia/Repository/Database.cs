using System.Data.SqlClient;

namespace FestaECia.Repository;
public class Database
{
	private readonly string _connectionString;

	public Database()
	{
		_connectionString = "Server = trabalhofestaecia.database.windows.net; Database = TrabalhoPoo; Uid = AzureSA; Pwd = Trabalhopoo2024";
	}

	public SqlConnection Conectar()
	{
		return new SqlConnection(_connectionString);
	}
}
