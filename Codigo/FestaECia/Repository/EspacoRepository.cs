using FestaECia.Models;
using FestaECia.Repository.Interfaces;
using System.Data.SqlClient;

namespace FestaECia.Repository;

public class EspacoRepository : IEspacoRepository
{
	private readonly Database _database;

	public EspacoRepository()
	{
		_database = new Database();
	}

	public List<Espaco> ListarTodos()
    {
	    try
	    {
		    var espacos = new List<Espaco>();

		    using (var conexao = _database.Conectar())
		    {
			    conexao.Open();
			    var comando = new SqlCommand("SELECT * FROM tb_space", conexao);

			    using (var leitor = comando.ExecuteReader())
			    {
				    while (leitor.Read())
				    {
					    espacos.Add(CriarEspaco(leitor));
				    }
			    }
		    }

		    return espacos;
	    }
	    catch (SqlException ex)
	    {
		    throw new Exception("Erro ao buscar no banco de dados " + ex.Message);
	    }
	    catch (Exception ex)
	    {
		    throw new Exception("Erro ao listar " + ex.Message);
	    }
    }

	public Espaco PegarPorId(int id)
	{
		try
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
		}
		catch (SqlException ex)
		{
			throw new Exception("Erro ao buscar no banco de dados " + ex.Message);
		}
		catch (FormatException)
		{
			throw new FormatException("Tipo informado não é número inteiro");
		}
		catch (Exception ex)
		{
			throw new Exception($"Erro ao buscar Espaco por ID: {ex.Message}");
		}

		return null;
	}

	private Espaco CriarEspaco(SqlDataReader reader)
    {
	    try
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
				    if (data != "")
				    {
					    listaDeDatasMarcadas.Add(DateTime.Parse(data));

				    }
			    }
		    }

		    espaco = new Espaco(id, nome, capacidade, listaDeDatasMarcadas, preco);

		    return espaco;
	    }
	    catch (InvalidOperationException ex)
	    {
		    throw new InvalidOperationException("Erro ao acessar um elemento da festa: " + ex.Message);
	    }
		catch (Exception ex)
	    {
		    throw new Exception("Erro ao criar espaço" + ex.Message);
	    }
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
	    catch (SqlException ex)
	    {
		    throw new Exception("Erro ao buscar no banco de dados " + ex.Message);
	    }
	    catch (FormatException)
	    {
		    throw new FormatException("Tipo informado não é número inteiro");
	    }
		catch (Exception ex)
	    {
		    throw new Exception("Erro ao buscar data por id " + ex.Message);
	    }

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

            throw new Exception("Erro ao inserir a festa " + ex.Message);
        }
        catch (FormatException ex)
        {
            throw new FormatException("Tipo informado está errado " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao inserir festa no banco de dados " + ex.Message);
        }
    }

}