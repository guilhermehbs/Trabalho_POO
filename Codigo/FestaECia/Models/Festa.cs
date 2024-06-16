using FestaECia.Models.Enums;

namespace FestaECia.Models;

public abstract class Festa : IFesta
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int NumeroDeConvidados { get;  set; }
    public int SpaceId { get;  set; }
    public TipoServico TipoServico { get;  set; }
    public TipoFesta TipoFesta { get;  set; }
    public double Preco { get;  set; }
    public List<Comida> Comidas { get; set; }
    public Dictionary<string, int> Bebidas { get; set; }

	public Festa(int numeroDeConvidados, TipoServico tipoServico, List<Comida> comidas, Dictionary<string, int> bebidas)
	{
		NumeroDeConvidados = numeroDeConvidados;
		TipoServico = tipoServico;
		Comidas = comidas;
		Bebidas = bebidas;
	}

    //construtor usado pelo banco
	public Festa(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco)
    {
        Id = id;
        Data = data;
        NumeroDeConvidados = numeroDeConvidados;
        SpaceId = spaceId;
        TipoServico = tipoServico;
        Preco = preco;
        Comidas = new List<Comida>();
        Bebidas = new Dictionary<string, int>();
    }

    public abstract string RetornarTipo();
}