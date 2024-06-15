using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaLivre : Festa
{
    public FestaLivre(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco)
    {
    }

    public override string RetornarTipo()
    {
        return "Festa livre";
    }
}