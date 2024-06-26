using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaLivre : Festa
{
    public FestaLivre(){}
	public FestaLivre(int numeroDeConvidados, TipoServico tipoServico, Dictionary<string, int> bebidas) :
		base(numeroDeConvidados, tipoServico, bebidas)
	{
	}
	public FestaLivre(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco, List<string> listaComidas, List<string> itens,List<string> bebidas) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaComidas, itens,bebidas)
    {
    }

    public override string RetornarTipo()
    {
        return "Festa livre";
    }
}