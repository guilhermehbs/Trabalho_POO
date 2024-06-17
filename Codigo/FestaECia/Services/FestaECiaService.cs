using FestaECia.Models;
using FestaECia.Repository;

namespace FestaECia.Services;

public class FestaECiaService
{
	private readonly FestaRepository _festaRepository;
	public CalendarioService Calendario;
	public EspacoService EspacoService;

	public FestaECiaService(FestaRepository festaRepository)
	{
		_festaRepository = festaRepository;
		Calendario = new CalendarioService();
		EspacoService = new EspacoService(new EspacoRepository());
	}

	public void MarcarFesta(Festa festa)
	{
		try
		{
			festa.Comidas = ComidaService.DefinirListaComidas(festa);
			festa.Items = ItemService.DefinirListaItems(festa);
			festa.ListaBebidas = BebidaService.DefinirListaBebidas(festa);

			List<Espaco> listaDeEspacosDisponiveis = EspacoService.ListaDeEspacosDisponiveis(festa.NumeroDeConvidados);
			DateTime data = Calendario.MarcarData();
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
						EspacoService.MarcarData(data.ToString("dd-MM-yyyy"), festa.SpaceId);

						marcou = true;
						break;
					}
				}

				data = Calendario.MarcarData(data);
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