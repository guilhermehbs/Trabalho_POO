using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDaEmpresa : Festa
{
    public FestaDaEmpresa(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco)
    {
    }

    public override string RetornarTipo()
    {
        return "Festa da empresa";
    }
}