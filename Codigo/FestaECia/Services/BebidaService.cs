using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class BebidaService
{
    public static double DefinirValorBebidas(Festa festa)
    {
	    Dictionary<string, double> valorBebidas = RetornarDicionarioDeBebidas(festa);

        double valorTotal = 0;

        foreach (var chave in festa.Bebidas)
        {
            valorTotal += (valorBebidas[chave.Key] * festa.NumeroDeConvidados);
        }
        return valorTotal;
    }

    private static Dictionary<string, double> RetornarDicionarioDeBebidas(Festa festa)
    {
	    Dictionary<string, double> valorBebidas;

		if (festa.TipoServico == TipoServico.Luxo || festa.TipoServico == TipoServico.Premier)
	    {
			valorBebidas = new Dictionary<string, double>()
			{
				{"agua sem gas", 5.00},
				{"suco", 7.00},
				{"refrigerante", 8.00},
				{"cerveja comum", 20.00},
				{"cerveja artesanal", 30.00},
				{"espumante nacional", 80.00},
				{"espumante importado", 140.00}
			};
		}
        valorBebidas = new Dictionary<string, double>()
        {
	        {"agua sem gas", 5.00},
	        {"suco", 7.00},
	        {"refrigerante", 8.00},
	        {"cerveja comum", 20.00},
	        {"espumante nacional", 80.00},
        };

        return valorBebidas;
    }
}