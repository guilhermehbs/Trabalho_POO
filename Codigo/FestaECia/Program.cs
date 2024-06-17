using FestaECia.Models;
using FestaECia.Models.Enums;
using FestaECia.Repository;
using FestaECia.Services;

namespace FestaECia;

class Program
{
	static void Main(string[] args)
	{

		var festaRepository = new FestaRepository();
		var festaService = new FestaECiaService(festaRepository);

		int escolha = 0;

		while (escolha != 5)
		{
			Console.WriteLine("1. Mostrar todas as festas");
			Console.WriteLine("2. Mostrar festa por if");
			Console.WriteLine("3. Adicionar uma nova festa");
			Console.WriteLine("4. Deletar uma festa");
			Console.WriteLine("5. Sair");

			escolha = int.Parse(Console.ReadLine());
			switch (escolha)
			{
				case 1:
					MostrarTodasAsFestas(festaService);
					break;
				case 2:
					MostrarFestaPorId(festaService);
					break;
				case 3:
					AdicionarNovaFesta(festaService);
					break;
				case 4:
					DeletarFesta(festaService);
					break;
				case 5:
					return;
			}
		}
	}


	static void MostrarTodasAsFestas(FestaECiaService festaService)
	{
		var festas = festaService.ListarTodasFestas();
		foreach (var festa in festas)
		{
			Console.WriteLine(festa);
		}
	}

		static void MostrarFestaPorId(FestaECiaService festaService)
		{
			Console.Write("Digite o id da festa: ");
			int id = int.Parse(Console.ReadLine());

			festaService.PegarFestaPorId(id);
		}

		static void AdicionarNovaFesta(FestaECiaService festaService)
		{
			Console.Write("Digite o número de convidados: ");
			int numeroConvidados = int.Parse(Console.ReadLine());

			TipoServico tipoServico = RetornarTipoServico();

			Dictionary<string, int> bebidas = RetornarDicionarioDeBebidas(tipoServico);
			
			Festa festa = null;
			while (festa == null)
			{
				festa = RetornarTipoDaFesta(numeroConvidados, tipoServico, bebidas);
			}
			festaService.MarcarFesta(festa);
		}

	static void DeletarFesta(FestaECiaService festaService)
	{
		Console.Write("Digite o id da festa para deletar: ");
		int id = int.Parse(Console.ReadLine());

		festaService.DeletarFesta(id);
	}

	static Festa RetornarTipoDaFesta(int numeroConvidados, TipoServico tipoServico,
		Dictionary<string, int> bebidas)
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

	static TipoServico RetornarTipoServico()
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

	static Dictionary<string, int> RetornarDicionarioDeBebidas(TipoServico tipoServico)
	{
		Dictionary<string, int > bebidas = new Dictionary<string, int>();
		if (tipoServico == TipoServico.Standard)
		{
			Console.WriteLine("Digite a quantidade de água");
			int quantidadeAgua = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de suco");
			int quantidadeSuco = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de refrigerante");
			int quantidadeRefrigerante = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de cerveja comum");
			int quantidadeCervejaComum = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de espumante nacional");
			int quantidadeEspumanteNacional = int.Parse(Console.ReadLine());
			bebidas["agua sem gas"] = quantidadeAgua;
			bebidas["suco"] = quantidadeSuco;
			bebidas["refrigerante"] = quantidadeRefrigerante;
			bebidas["cerveja comum"] = quantidadeCervejaComum;
			bebidas["espumante nacional"] = quantidadeEspumanteNacional;

		}
		else
		{
			Console.WriteLine("Digite a quantidade de água");
			int quantidadeAgua = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de suco");
			int quantidadeSuco = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de refrigerante");
			int quantidadeRefrigerante = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de cerveja comum");
			int quantidadeCervejaComum = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de cerveja artesanal");
			int quantidadeCervejaArtesanal = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de espumante nacional");
			int quantidadeEspumanteNacional = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite a quantidade de espumante importado");
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
}