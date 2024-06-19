using FestaECia.Models;

public interface IBebidaService
{
	static abstract double DefinirValorBebidas(Festa festa);
	static abstract List<string> DefinirListaBebidas(Festa festa);
}