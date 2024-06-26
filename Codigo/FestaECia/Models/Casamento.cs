using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class Casamento : Festa
{
    public Casamento(){}
	public Casamento(int numeroDeConvidados, TipoServico tipoServico, Dictionary<string, int> bebidas) :
		base(numeroDeConvidados, tipoServico, bebidas)
	{
	}
	public Casamento(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco, List<string> listaComidas, List<string> itens, List<string> bebidas) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaComidas, itens, bebidas)
    {
    }

    public override string RetornarTipo()
    {
        return "Casamento";
    }
}