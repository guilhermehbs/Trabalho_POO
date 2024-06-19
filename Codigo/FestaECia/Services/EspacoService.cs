using FestaECia.Models;
using FestaECia.Repository;

namespace FestaECia.Services;

public class EspacoService : IEspacoService
{
	private readonly IEspacoRepository _espacoRepository;

	public EspacoService(IEspacoRepository espacoRepository)
	{
		_espacoRepository = espacoRepository;
	}

	public EspacoService()
	{
	}

	public List<Espaco> ListaDeEspacosDisponiveis(int quantidadeDePessoas)
	{
		try
		{
			List<Espaco> spaceList = ListarTodosEspacos();
			spaceList = spaceList.Where(espaco => espaco.Capacidade >= quantidadeDePessoas).ToList();
			spaceList = spaceList.OrderBy(espaco => espaco.Capacidade).ToList();

			return spaceList;
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao criar lista de espaços " + ex.Message);
		}
	}

	public List<Espaco> ListarTodosEspacos()
	{
		return _espacoRepository.ListarTodos();
	}

	public Espaco PegarEspacoPorId(int id)
	{
		return _espacoRepository.PegarPorId(id);
	}
   
	public bool MarcarData(string data, int id)
	{
		return _espacoRepository.MarcarData(data, id);
	}
}