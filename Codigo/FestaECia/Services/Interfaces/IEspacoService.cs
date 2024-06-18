using FestaECia.Models;

public interface IEspacoService
{
	List<Espaco> ListaDeEspacosDisponiveis(int quantidadeDePessoas);
	List<Espaco> ListarTodosEspacos();
	Espaco PegarEspacoPorId(int id);
	bool MarcarData(string data, int id);
}