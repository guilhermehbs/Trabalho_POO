using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class BebidaService
{
    public static double DefinirValorBebidas(Festa festa)
    {
        Dictionary<string, double> drinksValue = new Dictionary<string, double>()
        {
            {"agua sem gas", 5.00},
            {"suco", 7.00},
            {"refrigerante", 8.00},
            {"cerveja comum", 20.00},
            {"cerveja artesanal", 30.00},
            {"espumante nacional", 80.00},
            {"espumante importado", 140.00}
        };

        double valorTotal = 0;

        foreach (var chave in festa.Bebidas)
        {
            valorTotal += (drinksValue[chave.Key] * festa.NumeroDeConvidados);
        }
        return valorTotal;
    }
}