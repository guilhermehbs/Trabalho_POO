using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDeAniversario : Festa 
{
	public FestaDeAniversario(int numeroDeConvidados, TipoServico tipoServico, List<Comida> comidas, Dictionary<string, int> bebidas) :
		base(numeroDeConvidados, tipoServico, comidas, bebidas)
	{
	}

	public FestaDeAniversario(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco) : 
        base(id, data, numeroDeConvidados, spaceId, tipoServico, preco)
    {
    }

	public override string RetornarTipo()
	{
		return "Festa de aniversario";
	}
}