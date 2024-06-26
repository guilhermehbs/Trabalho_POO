using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class ComidaService : IComidaService
{
    public static double DefinirValorComidas(Festa festa)
    {
	    try
	    {
		    if (festa.NumeroDeConvidados < 0)
		    {
			    throw new ArgumentException("The quantity of people must be upper than 0");
		    }

		    if (festa.TipoServico.Equals(TipoServico.Premier))
		    {
			    return 60 * festa.NumeroDeConvidados;
		    }
		    else if (festa.TipoServico.Equals(TipoServico.Luxo))
		    {
			    return 48 * festa.NumeroDeConvidados;
		    }
		    else if (festa.TipoServico.Equals(TipoServico.Standard))
		    {
			    return 40 * festa.NumeroDeConvidados;
		    }
		    else
		    {
			    throw new ArgumentException("This type does not exist in our database");
		    }
	    }
	    catch (Exception ex)
	    {
		    throw new Exception("Erro ao definir valor das comidas " + ex.Message);
	    }
    }

    public static List<string> DefinirListaComidas(Festa festa)
    {
	    try
	    {
		    if (festa.TipoServico.Equals(TipoServico.Premier))
		    {
			    return new List<string>
			    {
				    "Canape",
				    "Tartine",
				    "Bruschetta",
				    "Espetinho caprese"
			    };
		    }
		    else if (festa.TipoServico.Equals(TipoServico.Luxo))
		    {
			    return new List<string>
			    {
				    "Croquete carne seca",
				    "Barquetes legumes",
				    "Empadinha gourmet",
				    "Cestinha bacalhau"
			    };
		    }
		    else if (festa.TipoServico.Equals(TipoServico.Standard))
		    {
			    return new List<string>
			    {
				    "Coxinha",
				    "Kibe",
				    "Empadinha",
				    "P�o de queijo"
			    };
		    }
		    else
		    {
			    throw new ArgumentException("This type does not exist in our database");
		    }
	    }
	    catch (Exception ex)
	    {
		    throw new Exception("Erro ao definir lista de comidas " + ex.Message);
	    }
    }
}