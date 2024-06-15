using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class ItemService
{
    public static double DefinirValorItens(Festa festa)
    {
        Dictionary<string, double> itens = RetornarDicionarioValores(festa);

        if (festa is FestaDeFormatura)
        {
            itens.Remove("bolo");
        }
        else if (festa is FestaDaEmpresa)
        {
            itens.Remove("item de mesa");
            itens.Remove("decoracao");
            itens.Remove("bolo");
        }

        if (festa.NumeroDeConvidados < 0)
        {
            throw new ArgumentException("A quantidade de pessoas deve ser maior que 0");
        }
        if (festa.TipoServico.Equals(TipoServico.Premier))
        {
            return 250 * festa.NumeroDeConvidados;
        }
        else if (festa.TipoServico.Equals(TipoServico.Luxo))
        {
            return 190 * festa.NumeroDeConvidados;
        }
        else if (festa.TipoServico.Equals(TipoServico.Standard))
        {
            return 130 * festa.NumeroDeConvidados;
        }
        else
        {
            throw new ArgumentException("Tipo não existe");
        }
    }

    private static Dictionary<string, double> RetornarDicionarioValores(Festa festa)
    {
        Dictionary<string, double> itens;
        
        if (festa.TipoServico == TipoServico.Standard)
        {
            itens = new Dictionary<string, double>()
            {
                { "item de mesa", 50.00 },
                { "decoracao", 50.00 },
                { "bolo", 10.00 },
                { "musica", 20.00 },
            };
        }
        else if (festa.TipoServico == TipoServico.Luxo)
        {
            itens = new Dictionary<string, double>()
            {
                { "item de mesa", 75.00 },
                { "decoracao", 75.00 },
                { "bolo", 15.00 },
                { "musica", 25.00 },
            };
        }
        else if (festa.TipoServico == TipoServico.Premier)
        {
            itens = new Dictionary<string, double>()
            {
                { "item de mesa", 100.00 },
                { "decoracao", 100.00 },
                { "bolo", 20.00 },
                { "musica", 30.00 },
            };
        }
        else
        {
            throw new ArgumentException("Tipo não existe");
        }

        return itens;
    }
}