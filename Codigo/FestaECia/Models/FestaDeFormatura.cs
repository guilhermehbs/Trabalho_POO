using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDeFormatura : Festa
{
    public FestaDeFormatura(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco)
    {
    }

    public override string RetornarTipo()
    {
        return "Festa de formatura";
    }
}