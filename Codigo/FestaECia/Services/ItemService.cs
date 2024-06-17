using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class ItemService
{
    public static double DefinirValorItens(Festa festa, int capacidade)
    {
        Dictionary<string, double> itens = RetornarDicionarioValores(festa);

        if (festa.NumeroDeConvidados < 0)
        {
            throw new ArgumentException("A quantidade de pessoas deve ser maior que 0");
        }

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
        else if (festa is FestaLivre)
        {
            itens.Remove("item de mesa");
            itens.Remove("decoracao");
            itens.Remove("bolo");
            itens.Remove("musica");
            return 0;
        }
        double preco = 0.0;

        foreach(KeyValuePair<string, double> chaveEvalor in itens)
        {
            preco += chaveEvalor.Value;
        }

        preco *= capacidade;
        return preco;
    }

    private static Dictionary<string, double> RetornarDicionarioValores(Festa festa)
    {
        Dictionary<string, double> itens;
        if (festa is  FestaDeAniversario) {
            itens = new Dictionary<string, double>()
            {
                { "item de mesa", 50.00 },
                { "decoracao", 50.00 },
                { "bolo", 10.00 },
                { "musica", 20.00 },
            };
        }
        else if (festa.TipoServico == TipoServico.Standard)
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