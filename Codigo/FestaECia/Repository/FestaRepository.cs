using System.Data.SqlClient;
using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Repository;

public class FestaRepository : IGet<Festa>, ISet<Festa>
{
	private readonly Database _database;

	public FestaRepository()
	{
		_database = new Database();
	}

	public List<Festa> ListarTodos()
	{
		var festas = new List<Festa>();

		using (var conexao = _database.Conectar())
		{
			conexao.Open();
			var comando = new SqlCommand("SELECT * FROM tb_party", conexao);

			using (var leitor = comando.ExecuteReader())
			{
				while (leitor.Read())
				{
					festas.Add(CriarFesta(leitor));
				}
			}
		}

		return festas;
	}

	public Festa PegarPorId(int id)
	{
		using (var conexao = _database.Conectar())
		{
			conexao.Open();
			var comando = new SqlCommand($"SELECT * FROM tb_space WHERE Id = {id}", conexao);

			using (var leitor = comando.ExecuteReader())
			{
				if (leitor.Read())
				{
					return CriarFesta(leitor);
				}
			}
		}

		return null;
	}

	public void Inserir(Festa festa)
	{
		using (var conexao = _database.Conectar())
		{
			conexao.Open();
			var comando = new SqlCommand($"INSERT INTO tb_party (date, number_of_guests, space_id, type_party, price, partyType) VALUES" +
			                             $"('{festa.Data}', {festa.NumeroDeConvidados}, {festa.SpaceId}, '{festa.TipoServico}', {festa.Preco}, '{festa.RetornarTipo()}'", conexao);
			comando.ExecuteNonQuery();
		}
	}

	public void Deletar(int id)
	{
		using (var conexao = _database.Conectar())
		{
			conexao.Open();
			var comando = new SqlCommand($"DELETE FROM tb_party WHERE Id = {id}", conexao);

			comando.ExecuteNonQuery();
		}
	}

	private Festa CriarFesta(SqlDataReader reader)
	{
		int id = (int)reader["id"];
		DateTime data = (DateTime)reader["date"];
		int numeroDeConvidados = (int)reader["number_of_people"];
		int spaceId = (int)reader["space_id"];
		TipoServico tipoServico = (TipoServico)reader["space_id"];
		double preco = (double)reader["Price"];
		string tipoFesta = (string)reader["party_type"];
		
		Festa festa;

		switch (tipoFesta)
		{
			case "Festa de aniversario":
				festa = new FestaDeAniversario(id, data, numeroDeConvidados, spaceId, tipoServico, preco);
				break;
			case "Festa da empresa":
				festa = new FestaDaEmpresa(id, data, numeroDeConvidados, spaceId, tipoServico, preco);
				break;
			case "Festa livre":
				festa = new FestaLivre(id, data, numeroDeConvidados, spaceId, tipoServico, preco);
				break;
			case "Festa de formatura":
				festa = new FestaDeFormatura(id, data, numeroDeConvidados, spaceId, tipoServico, preco);
				break;
			case "Casamento":
				festa = new Casamento(id, data, numeroDeConvidados, spaceId, tipoServico, preco);
				break;
			default:
				throw new InvalidOperationException("Unknown party type");
				break;
		}
		return festa;
	}
}