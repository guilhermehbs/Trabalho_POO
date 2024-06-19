using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDaEmpresa : Festa
{
	public FestaDaEmpresa(int numeroDeConvidados, TipoServico tipoServico, Dictionary<string, int> bebidas) :
		base(numeroDeConvidados, tipoServico, bebidas)
	{
	}
	public FestaDaEmpresa(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco, List<string> listaComidas, List<string> itens, List<string> bebidas) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaComidas, itens,bebidas)
    {
    }

    public override string RetornarTipo()
    {
        return "Festa da empresa";
    }
}