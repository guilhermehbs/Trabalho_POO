using System.Data.SqlClient;
using FestaECia.Models;
using FestaECia.Models.Enums;
using System;
using FestaECia.Repository.Interfaces;
namespace FestaECia.Repository;

public class FestaRepository : IGet<Festa>, IManipulavel<Festa>, IFestaRepository
{
	private readonly Database _database;

	public FestaRepository()
	{
		_database = new Database();
	}

	public List<Festa> ListarTodos()
	{
		try
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
		catch (SqlException ex)
		{
			throw new Exception("Erro ao fazer a consulta no banco de dados" + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro inesperado ao consultar as festas: " + ex.Message);
		}
	}

	public Festa PegarPorId(int id)
	{
		try
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
		}
		catch (InvalidOperationException ex)
		{
			throw new InvalidOperationException("Erro ao acessar um elemento da festa " + ex.Message);
		}
		catch (SqlException ex)
		{
			throw new Exception("Erro ao fazer a consulta no banco de dados " + ex.Message);
		}
		catch (ArgumentException)
		{
			throw new ArgumentException("Número de id informado não é inteiro");
		}
		catch (Exception ex)
		{
			throw new Exception("Erro inesperado ao consultar a festa " + ex.Message);
		}

		return null;
	}

	public void Inserir(Festa festa)
	{
		try
		{

            using (var conexao = _database.Conectar())
			{
                conexao.Open();
                var comando = new SqlCommand(
					$"INSERT INTO tb_party (date_party, number_of_guests, space_id, type_party, price, party_type, foods, drinks, itens) VALUES" +
					$"('{festa.Data.Date.ToString("dd-MM-yyyy")}', {festa.NumeroDeConvidados}, {festa.SpaceId}, '{festa.TipoServico}', {festa.Preco}, '{festa.RetornarTipo()}', '{festa.RetornarStringComida()}','{festa.RetornarStringBebidas()}','{festa.RetornarStringItems()}')",
					conexao);
           
				
                comando.ExecuteNonQuery();
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
		catch (ArgumentException)
		{
			throw new ArgumentException("Tipo informado não é uma festa");
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao inserir festa no banco de dados " + ex.Message);
		}
	}

	public void Deletar(int id)
	{
		try
		{
			using (var conexao = _database.Conectar())
			{
				conexao.Open();

				var comando = new SqlCommand($"DELETE FROM tb_party WHERE Id = {id}", conexao);
				
				int linhasAfetadas = comando.ExecuteNonQuery();
				if (linhasAfetadas == 0)
				{
					throw new Exception($"Nenhum registro encontrado com o ID {id}");
				}
			}
		}
		catch (SqlException ex)
		{
			// Erro de chave estrangeira
			if (ex.Number == 547)
			{
				throw new Exception("Impossível deletar a festa, pois existem eventos associados a ela");
			}
			else
			{
				throw new Exception("Erro ao deletar a festa " + ex.Message);
			}
		}
		catch (ArgumentException)
		{
			throw new ArgumentException("Número de id informado não é inteiro");
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao deletar a festa " + ex.Message);
		}
	}

	private Festa CriarFesta(SqlDataReader reader)
	{
		try
		{
			int id = (int)reader["id"];
            string dataString = (string)reader["date_party"];

            DateTime data = DateTime.Parse(dataString);

            int numeroDeConvidados = (int)reader["number_of_guests"];
			int spaceId = (int)reader["space_id"];
			string tipo= (string)reader["type_party"];
			TipoServico tipoServico;
			if (tipo.Equals("Standard"))
			{
				tipoServico = TipoServico.Standard;
			}
			else if (tipo.Equals("Luxo"))
			{
				tipoServico = TipoServico.Luxo;
			}
			else
			{
				tipoServico = TipoServico.Premier;

            }

			double preco = (double)(decimal)reader["Price"];
			string tipoFesta = (string)reader["party_type"];
			string comidas;
            try
            {
                comidas = (string)reader["foods"];
            }
            catch (Exception)
            {
                comidas = null;
            }

            List<string> listaDeComidas = new List<string>();


            if (comidas != null)
            {
                string[] vetorComidas = comidas.Split(';');
                foreach (var comida in vetorComidas)
                {
                    if (comida != "")
                    {
                        listaDeComidas.Add(comida);

                    }
                }
            }

            string itens;
            try
            {
                itens = (string)reader["itens"];
            }
            catch (Exception)
            {
                itens = null;
            }

            List<string> listaDeitens  = new List<string>();


            if (itens != null)
            {
                string[] vetorItens = itens.Split(';');
                foreach (var item in vetorItens)
                {
                    if (item != "")
                    {
                        listaDeitens.Add(item);

                    }
                }
            }

            string bebidas;
            try
            {
                bebidas = (string)reader["drinks"];
            }
            catch (Exception)
            {
                bebidas = null;
            }

            List<string> listaDeBebidas = new List<string>();


            if (bebidas != null)
            {
                string[] vetorBebidas = bebidas.Split(';');
                foreach (var bebida in vetorBebidas)
                {
                    if (bebida != "")
                    {
                        listaDeBebidas.Add(bebida);

                    }
                }
            }

            Festa festa;

			switch (tipoFesta)
			{
				case "Festa de aniversario":
					festa = new FestaDeAniversario(id, data, numeroDeConvidados, spaceId, tipoServico, preco,listaDeComidas, listaDeitens,listaDeBebidas);
					break;
				case "Festa da empresa":
					festa = new FestaDaEmpresa(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaDeComidas, listaDeitens, listaDeBebidas);
					break;
				case "Festa livre":
					festa = new FestaLivre(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaDeComidas, listaDeitens, listaDeBebidas);
					break;
				case "Festa de formatura":
					festa = new FestaDeFormatura(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaDeComidas, listaDeitens, listaDeBebidas);
					break;
				case "Casamento":
					festa = new Casamento(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaDeComidas, listaDeitens,listaDeBebidas);
					break;
				default:
					throw new InvalidOperationException($"Tipo de festa inválido: {tipoFesta}");
			}

			return festa;
		}
		catch (InvalidOperationException ex)
		{
			throw new InvalidOperationException("Erro ao acessar um elemento da festa: " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro inesperado ao criar festa: " + ex.Message);
		}
	}
}
