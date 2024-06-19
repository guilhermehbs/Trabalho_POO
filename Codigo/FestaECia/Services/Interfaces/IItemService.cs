using FestaECia.Models;

public interface IItemService
{
	static abstract double DefinirValorItens(Festa festa, int capacidade);
	static abstract List<string> DefinirListaItems(Festa festa);
}