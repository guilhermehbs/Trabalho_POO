﻿using FestaECia.Models;
using FestaECia.Models.Enums;
using FestaECia.Repository;
using FestaECia.Services;

namespace FestaECia;

class Program
{
	static void Main(string[] args)
	{
		FestaRepository festaRepository = new FestaRepository();
		FestaECiaService festaService = new FestaECiaService(festaRepository);

		int escolha = 0;

		while (escolha != 5)
		{
			Console.WriteLine("1. Mostrar todas as festas");
			Console.WriteLine("2. Mostrar festa por if");
			Console.WriteLine("3. Adicionar uma nova festa");
			Console.WriteLine("4. Deletar uma festa");
			Console.WriteLine("5. Sair");

			try
			{
				escolha = int.Parse(Console.ReadLine());
			}
			catch (ArgumentException ex)
			{
				throw new Exception("Tipo digitado não suportado " + ex.Message);
			}

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
		try
		{
			var festas = festaService.ListarTodasFestas();
			foreach (var festa in festas)
			{
				Console.WriteLine(festa);
			}
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

	static void MostrarFestaPorId(FestaECiaService festaService)
	{
		try
		{
			Console.Write("Digite o id da festa: ");
			int id = int.Parse(Console.ReadLine());

			festaService.PegarFestaPorId(id);
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao mostrar festa por id " + ex.Message);
		}
	}

	static void AdicionarNovaFesta(FestaECiaService festaService)
	{
		try
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
		catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao adicionar nova festa " + ex.Message);
		}
	}

	static void DeletarFesta(FestaECiaService festaService)
	{
		try
		{
			Console.Write("Digite o id da festa para deletar: ");
			int id = int.Parse(Console.ReadLine());

			festaService.DeletarFesta(id);
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
		catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
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
		catch (ArgumentException ex)
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
		catch (ArgumentException ex)
		{
			throw new ArgumentException("Tipo digitado não é suportado " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao retornar dicionário de bebidas " + ex.Message);
		}
	}
}