using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDaEmpresa : Festa
{
	public FestaDaEmpresa(int numeroDeConvidados, TipoServico tipoServico, List<Comida> comidas, Dictionary<string, int> bebidas) :
		base(numeroDeConvidados, tipoServico, comidas, bebidas)
	{
	}
	public FestaDaEmpresa(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco)
    {
    }

    public override string RetornarTipo()
    {
        return "Festa da empresa";
    }
}