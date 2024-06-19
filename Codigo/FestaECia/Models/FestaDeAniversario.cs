using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDeAniversario : Festa 
{
	public FestaDeAniversario(int numeroDeConvidados, TipoServico tipoServico, Dictionary<string, int> bebidas) :
		base(numeroDeConvidados, tipoServico, bebidas)
	{
	}

	public FestaDeAniversario(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco, List<string> listaComidas, List<string> itens, List<string> bebidas) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco, listaComidas, itens, bebidas)
    {
    }

	public override string RetornarTipo()
	{
		return "Festa de aniversario";
	}
}