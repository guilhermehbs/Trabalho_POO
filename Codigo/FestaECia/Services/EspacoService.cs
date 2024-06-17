using FestaECia.Models;
using FestaECia.Repository;

namespace FestaECia.Services;

public class EspacoService
{
	private readonly EspacoRepository _espacoRepository;

	public EspacoService(EspacoRepository espacoRepository)
	{
		_espacoRepository = espacoRepository;
	}

	public EspacoService()
	{
		
	}

	public List<Espaco> ListaDeEspacosDisponiveis(int quantidadeDePessoas)
	{
		List<Espaco> spaceList = ListarTodosEspacos();
		spaceList = spaceList.Where(espaco => espaco.Capacidade >= quantidadeDePessoas).ToList();
		spaceList = spaceList.OrderBy(espaco => espaco.Capacidade).ToList();

		return spaceList;
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