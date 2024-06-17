using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class BebidaService
{
    public static double DefinirValorBebidas(Festa festa)
    {
	    Dictionary<string, double> valorBebidas = RetornarDicionarioPrecoDeBebidas(festa);

        double valorTotal = 0;

        foreach (var chave in festa.Bebidas)
        {
            valorTotal += (valorBebidas[chave.Key] * festa.Bebidas[chave.Key]);
        }
        return valorTotal;
    }

    private static Dictionary<string, double> RetornarDicionarioPrecoDeBebidas(Festa festa)
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
		else
		{
			valorBebidas = new Dictionary<string, double>()
			{
				{"agua sem gas", 5.00},
				{"suco", 7.00},
				{"refrigerante", 8.00},
				{"cerveja comum", 20.00},
				{"espumante nacional", 80.00},
			};
		}

        return valorBebidas;
    }

    public static List<string> DefinirListaBebidas(Festa festa)
	{
		Dictionary<string, int> dicbebidas = festa.Bebidas;
		List< string> retorno = new List< string>();
		foreach(KeyValuePair<string,int> keyValuePair in dicbebidas)
		{
			retorno.Add($"{keyValuePair.Key}:{keyValuePair.Value}");
		}
		return retorno;
    }
}