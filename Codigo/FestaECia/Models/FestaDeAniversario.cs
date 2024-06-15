using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class FestaDeAniversario : Festa 
{
	public FestaDeAniversario(DateTime data, int numeroDeConvidados, TipoServico tipoServico) :
		base(data, numeroDeConvidados, tipoServico)
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