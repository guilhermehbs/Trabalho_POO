using Microsoft.Data.SqlClient;

namespace FestaECia.Connection
{
	public class DBConnection
	{
		public DBConnection() 
		{
			string connectionString = "Server=trabalhopoo2024.database.windows.net;Database=FestaECia;Uid=AzureSA;Pwd=senha";
			var connection = new SqlConnection(connectionString);
		}
	}
}
