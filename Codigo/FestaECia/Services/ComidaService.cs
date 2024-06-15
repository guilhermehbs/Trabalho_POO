using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Services;

public class ComidaService
{
    public static double DefinirValorComidas(Festa festa)
    {

        if (festa.NumeroDeConvidados < 0)
        {
            throw new ArgumentException("The quantity of people must be upper than 0");
        }
        if (festa.TipoServico.Equals(TipoServico.Premier))
        {
            return 240 * festa.NumeroDeConvidados;
        }
        else if (festa.TipoServico.Equals(TipoServico.Luxo))
        {
            return 192 * festa.NumeroDeConvidados;
        }
        else if (festa.TipoServico.Equals(TipoServico.Standard))
        {
            return 160 * festa.NumeroDeConvidados;
        }
        else
        {
            throw new ArgumentException("This type does not exist in our database");
        }
    }
}