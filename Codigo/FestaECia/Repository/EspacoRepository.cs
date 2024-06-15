using FestaECia.Models;
using System.Data.SqlClient;

namespace FestaECia.Repository;

public class EspacoRepository : IGet<Espaco>
{
	private readonly Database _database;

	public EspacoRepository()
	{
		_database = new Database();
	}

	public List<Espaco> ListarTodos()
    {
		var espacos = new List<Espaco>();

		using (var conexao = _database.Conectar())
		{
			conexao.Open();
			var comando = new SqlCommand("SELECT * FROM tb_space", conexao);

			using (var leitor= comando.ExecuteReader())
			{
				while (leitor.Read())
				{
					espacos.Add(CriarEspaco(leitor));
				}
			}
		}

		return espacos;
	}

    public Espaco PegarPorId(int id)
    {
		using (var conexao = _database.Conectar())
		{
			conexao.Open();
			var comando = new SqlCommand($"SELECT * FROM tb_space WHERE id = {id}", conexao);

			using (var leitor = comando.ExecuteReader())
			{
				if (leitor.Read())
				{
					return CriarEspaco(leitor);
				}
			}
		}

		return null;
	}

    private Espaco CriarEspaco(SqlDataReader reader)
    {
	    Espaco espaco;

	    int id = (int)reader["id"];
	    string nome = (string)reader["space_name"];
	    int capacidade = (int)reader["capacity"];
	    double preco = (double)reader["space_price"];
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

	    espaco = new Espaco(id, nome, capacidade, listaDeDatasMarcadas, preco);

	    return espaco;
    }
}