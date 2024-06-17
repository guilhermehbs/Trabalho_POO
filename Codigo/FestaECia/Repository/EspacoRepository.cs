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
	    double preco = (double)(decimal)reader["space_price"];
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
				if(data != "")
				{
                    listaDeDatasMarcadas.Add(DateTime.Parse(data));

                }
            }
	    }

	    espaco = new Espaco(id, nome, capacidade, listaDeDatasMarcadas, preco);

	    return espaco;
    }

    public string PegarDatasPorId(int id)
    {
		try
		{
			using (var conexao = _database.Conectar())
			{
				conexao.Open();
				var comando = new SqlCommand($"SELECT dates_schedule FROM tb_space WHERE id = {id}", conexao);

				using (var leitor = comando.ExecuteReader())
				{

					leitor.Read();
					if (leitor.IsDBNull(0))
					{
						return "";   
                    }

                    string data = (string)leitor["dates_schedule"];
                    return data; 

                }
			}
		}

        catch (Exception ex) { throw new Exception(ex.Message); }

    }

    public bool MarcarData(string data, int id)
    {
        try
        {
			string datasMarcadas = PegarDatasPorId(id);
			datasMarcadas += $"{data};";
            using (var conexao = _database.Conectar())
            {
                conexao.Open();

                var comando = new SqlCommand(
                    $"UPDATE tb_space set dates_schedule = '{datasMarcadas}' WHERE id = {id}",
                    conexao);


                comando.ExecuteNonQuery();
				return true;
            }
        }
        catch (SqlException ex)
        {
            // Erro de chave estrangeira
            if (ex.Number == 547)
            {
                throw new Exception("Impossível deletar a festa, pois existem eventos associados a ela");
            }

            throw new Exception("Erro ao inserir a festa" + ex.Message);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Tipo informado não é uma festa");
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao inserir festa no banco de dados" + ex.Message);
        }
    }

}