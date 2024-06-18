using FestaECia.Models;

public interface IEspacoRepository
{
	List<Espaco> ListarTodos();
	Espaco PegarPorId(int id);
	string PegarDatasPorId(int id);
	bool MarcarData(string data, int id);
}