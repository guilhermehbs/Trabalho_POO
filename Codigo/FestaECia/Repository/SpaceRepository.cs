using FestaECia.Models;
using System.Data.SqlClient;

namespace FestaECia.Repository;

public class SpaceRepository : IGet<Space>
{
	private readonly Database _database;

	public SpaceRepository()
	{
		_database = new Database();
	}

	public List<Space> GetAll()
    {
		var spaces = new List<Space>();

		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("SELECT * FROM tb_space", connection);

			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					spaces.Add(RenderSpace(reader));
				}
			}
		}

		return spaces;
	}

    public Space GetById(int id)
    {
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand($"SELECT * FROM tb_space WHERE id = {id}", connection);

			using (var reader = command.ExecuteReader())
			{
				if (reader.Read())
				{
					return RenderSpace(reader);
				}
			}
		}

		return null;
	}

    private Space RenderSpace(SqlDataReader reader)
    {
	    Space space;

	    int id = (int)reader["id"];
	    string name = (string)reader["space_name"];
	    int capacity = (int)reader["capacity"];
	    string datasMarcadas;
	    try
	    {
		    datasMarcadas = (string)reader["dates_schedule"];
	    }
	    catch (Exception)
	    {
		    datasMarcadas = null;
	    }

	    List<DateTime> listaDeDatasMarcadas = new List<DateTime>();


		if (datasMarcadas != null)
	    {
		    string[] datas = datasMarcadas.Split(';');
		    foreach (var data in datas)
		    {
			    listaDeDatasMarcadas.Add(DateTime.Parse(data));
		    }
	    }

	    space = new Space(id, name, capacity, listaDeDatasMarcadas);

	    return space;
    }
}