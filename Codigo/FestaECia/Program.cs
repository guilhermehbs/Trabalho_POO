using FestaECia.Models;
using FestaECia.Models.Enums;
using FestaECia.Repository;
using FestaECia.Repository.Interfaces;
using FestaECia.Services;
using FestaECia.Services.Interfaces;

namespace FestaECia;

class Program
{
	static void Main(string[] args)
	{
		IFestaRepository festaRepository = new FestaRepository();
		IEspacoRepository espacoRepository = new EspacoRepository();
		IEspacoService espacoService = new EspacoService(espacoRepository);
		ICalendarioService calendarioService = new CalendarioService();
		IFestaService festaService = new FestaECiaService(festaRepository, espacoService, calendarioService);

		int escolha = 0;

		while (escolha != 5)
		{
			Console.Clear();
			Console.WriteLine("1. Mostrar todas as festas");
			Console.WriteLine("2. Adicionar uma nova festa");
			Console.WriteLine("3. Deletar uma festa");
			Console.WriteLine("4. Sair");
			Console.Write("Digite a opção desejada: ");
			try
			{
				escolha = int.Parse(Console.ReadLine());
			}
			catch (FormatException ex)
			{
				throw new FormatException("Tipo digitado não suportado " + ex.Message);
			}

			switch (escolha)
			{
				case 1:
					MostrarTodasAsFestas(festaService);
					break;
				case 2:
					AdicionarNovaFesta(festaService);
					break;
				case 3:
					DeletarFesta(festaService);
					break;
				case 4:
					return;
			}
		}
	}


	static void MostrarTodasAsFestas(IFestaService festaService)
	{
        Console.Clear();

        Console.WriteLine("Carregando...");

        try
        {
			var festas = festaService.ListarTodasFestas();
            Console.Clear();
            if (festas.Count > 0)
			{
				foreach (var festa in festas)
				{
					Console.WriteLine(festa);
				}
			}
			else
			{
				Console.WriteLine("Nenhuma festa cadsatrada ainda");
			}

			Console.WriteLine("Digite qualquer tecla para sair");
			Console.ReadKey();
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao mostar todas as festas " + ex.Message);
		}
	}

	static void AdicionarNovaFesta(IFestaService festaService)
	{
		Console.Clear();
		try
		{
			int numeroConvidados;

			do
			{
                Console.Write("Digite o número de convidados: ");

                numeroConvidados = int.Parse(Console.ReadLine());

			} while (numeroConvidados > 500 || numeroConvidados < 1);


            TipoServico tipoServico = RetornarTipoServico();

			Dictionary<string, int> bebidas = RetornarDicionarioDeBebidas(tipoServico);

			Festa festa = null;
			while (festa == null)
			{
				festa = RetornarTipoDaFesta(numeroConvidados, tipoServico, bebidas);
			}


			Console.WriteLine("Marcando...");

			festaService.MarcarFesta(festa);
			
			Console.WriteLine("Festa cadastrada com sucesso");
			Console.WriteLine("Valor Total da festa: " + festa.Preco);
			Thread.Sleep(4000);
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao adicionar nova festa " + ex.Message);
		}
	}

	static void DeletarFesta(IFestaService festaService)
	{
		Console.Clear();
		try
		{
			Console.WriteLine("Festas cadastradas:");
			MostrarTodasAsFestas(festaService);
			Console.Write("Digite o id da festa para deletar (0 para cancelar): ");
			int id = int.Parse(Console.ReadLine());
			if(0 == id)
			{
                Console.WriteLine("Cancelado, Tamo junto!");
            }
			else
			{
                festaService.DeletarFesta(id);
                Console.WriteLine("Festa deletada com sucesso");
            }
                Thread.Sleep(4000);
        }
        catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao deletar festa " + ex.Message);
		}
	}

	static Festa RetornarTipoDaFesta(int numeroConvidados, TipoServico tipoServico,
		Dictionary<string, int> bebidas)
	{
		try
		{
			Console.WriteLine("Selecione o tipo da festa: ");
			Console.WriteLine("1 - Aniversário");
			Console.WriteLine("2 - Casamento");
			Console.WriteLine("3 - Formatura");
			Console.WriteLine("4 - Festa da empresa");
			Console.WriteLine("5 - Apenas aluguel do espaço");
			int escolha = int.Parse(Console.ReadLine());
			switch (escolha)
			{
				case 1:
					return new FestaDeAniversario(numeroConvidados, tipoServico, bebidas);
				case 2:
					return new Casamento(numeroConvidados, tipoServico, bebidas);
				case 3:
					return new FestaDeFormatura(numeroConvidados, tipoServico, bebidas);
				case 4:
					return new FestaDaEmpresa(numeroConvidados, tipoServico, bebidas);
				case 5:
					return new FestaLivre(numeroConvidados, tipoServico, bebidas);
				default:
					return null;
			}
		}
		catch (FormatException ex)
		{
			throw new FormatException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao retornar tipo da festa " + ex.Message);
		}

	}

	static TipoServico RetornarTipoServico()
	{
		try
		{
			Console.WriteLine("Selecione o tipo do serviço desejado:");
			Console.WriteLine("1 - Standard");
			Console.WriteLine("2 - Luxo");
			Console.WriteLine("3 - Premiere");
			Console.WriteLine("Outro número: Tipo default (Standard)");
			int escolha = int.Parse(Console.ReadLine());

			TipoServico tipoServico;
			switch (escolha)
			{
				case 1:
					tipoServico = TipoServico.Standard;
					break;
				case 2:
					tipoServico = TipoServico.Luxo;
					break;
				case 3:
					tipoServico = TipoServico.Premier;
					break;
				default:
					tipoServico = TipoServico.Standard;
					break;
			}

			return tipoServico;
		}
		catch (FormatException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao retornar tipo do serviço " + ex.Message);
		}
	}

	static Dictionary<string, int> RetornarDicionarioDeBebidas(TipoServico tipoServico)
	{
		try
		{
			Dictionary<string, int> bebidas = new Dictionary<string, int>();
			if (tipoServico == TipoServico.Standard)
			{
				Console.Write("Digite a quantidade garrafas de água: ");
				int quantidadeAgua = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade jarras de suco: ");
				int quantidadeSuco = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade latas de refrigerante: ");
				int quantidadeRefrigerante = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade de cervejas comum: ");
				int quantidadeCervejaComum = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade de espumantes nacional: ");
				int quantidadeEspumanteNacional = int.Parse(Console.ReadLine());
				bebidas["agua sem gas"] = quantidadeAgua;
				bebidas["suco"] = quantidadeSuco;
				bebidas["refrigerante"] = quantidadeRefrigerante;
				bebidas["cerveja comum"] = quantidadeCervejaComum;
				bebidas["espumante nacional"] = quantidadeEspumanteNacional;

			}
			else
			{
				Console.Write("Digite a quantidade garrafas de água: ");
				int quantidadeAgua = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade jarras de suco: ");
				int quantidadeSuco = int.Parse(Console.ReadLine());
				Console.Write	("Digite a quantidade latas de refrigerante: ");
				int quantidadeRefrigerante = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade de cervejas comum: ");
				int quantidadeCervejaComum = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade de cervejas artesanal: ");
				int quantidadeCervejaArtesanal = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade de espumantes nacional: ");
				int quantidadeEspumanteNacional = int.Parse(Console.ReadLine());
				Console.Write("Digite a quantidade de espumantes importado: ");
				int quantidadeEspumanteImportado = int.Parse(Console.ReadLine());
				bebidas["agua sem gas"] = quantidadeAgua;
				bebidas["suco"] = quantidadeSuco;
				bebidas["refrigerante"] = quantidadeRefrigerante;
				bebidas["cerveja comum"] = quantidadeCervejaComum;
				bebidas["cerveja artesanal"] = quantidadeCervejaArtesanal;
				bebidas["espumante nacional"] = quantidadeEspumanteNacional;
				bebidas["espumante importado"] = quantidadeEspumanteImportado;
			}

			return bebidas;
		}
		catch (FormatException ex)
		{
			throw new FormatException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao retornar dicionário de bebidas " + ex.Message);
		}
	}
}