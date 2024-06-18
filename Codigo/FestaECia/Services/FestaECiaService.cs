using FestaECia.Models;
using FestaECia.Repository;
using FestaECia.Repository.Interfaces;
using FestaECia.Services.Interfaces;

namespace FestaECia.Services;

public class FestaECiaService : IFestaService
{
	public ICalendarioService _calendario;
	private readonly IFestaRepository _festaRepository;
	public IEspacoService _espacoService;

	public FestaECiaService(IFestaRepository festaRepository, IEspacoService espacoService, ICalendarioService calendarioService)
	{
		_calendario = calendarioService;
		_espacoService = new EspacoService(new EspacoRepository());
		_festaRepository = festaRepository;
		_espacoService = espacoService;
	}

	public void MarcarFesta(Festa festa)
	{
		try
		{
			festa.Comidas = ComidaService.DefinirListaComidas(festa);
			festa.Items = ItemService.DefinirListaItems(festa);
			festa.ListaBebidas = BebidaService.DefinirListaBebidas(festa);

			List<Espaco> listaDeEspacosDisponiveis = _espacoService.ListaDeEspacosDisponiveis(festa.NumeroDeConvidados);
			DateTime data = _calendario.MarcarData();
			double preco = 0.0;
			int capacidadeEspaco = 0;
			bool marcou = false;
			while (!marcou)
			{
				foreach (Espaco espaco in listaDeEspacosDisponiveis)
				{
					if (!espaco.DatasMarcadas.Contains(data))
					{
						festa.SpaceId = espaco.Id;
						preco += espaco.Preco;
						capacidadeEspaco += espaco.Capacidade;
						festa.Data = data;
						_espacoService.MarcarData(data.ToString("dd-MM-yyyy"), festa.SpaceId);

						marcou = true;
						break;
					}
				}

				data = _calendario.MarcarData(data);
			}

			preco += ComidaService.DefinirValorComidas(festa);
			preco += ItemService.DefinirValorItens(festa, capacidadeEspaco);
			preco += BebidaService.DefinirValorBebidas(festa);

			festa.Preco = preco;

			_festaRepository.Inserir(festa);
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao marcar festa " + ex.Message);
		}
	}

	public void DeletarFesta(int id)
	{
		_festaRepository.Deletar(id);
	}

	public List<Festa> ListarTodasFestas()
	{
		return _festaRepository.ListarTodos();
	}

	public Festa PegarFestaPorId(int id)
	{
		return _festaRepository.PegarPorId(id);
	}
}