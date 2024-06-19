using FestaECia.Models;

public interface IComidaService
{
	static abstract double DefinirValorComidas(Festa festa);
	static abstract List<string> DefinirListaComidas(Festa festa);
}