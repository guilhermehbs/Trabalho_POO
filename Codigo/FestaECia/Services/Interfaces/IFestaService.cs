using FestaECia.Models;

public interface IFestaService
{
	void MarcarFesta(Festa festa);
	void DeletarFesta(int id);
	List<Festa> ListarTodasFestas();
}