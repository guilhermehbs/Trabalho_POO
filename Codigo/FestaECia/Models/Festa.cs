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
    public List<string> Comidas { get; set; }
    public List<string> Items { get; set; }
    public List<string> ListaBebidas { get; set; }
    public Dictionary<string, int> Bebidas { get; set; }

	public Festa(int numeroDeConvidados, TipoServico tipoServico, Dictionary<string, int> bebidas)
	{
		NumeroDeConvidados = numeroDeConvidados;
		TipoServico = tipoServico;
		Bebidas = bebidas;
 
	}

    //construtor usado pelo banco
	public Festa(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, double preco, List<string> listaComidas, List<string> itens, List<string> bebidas)
    {
        Id = id;
        Data = data;
        NumeroDeConvidados = numeroDeConvidados;
        SpaceId = spaceId;
        TipoServico = tipoServico;
        Preco = preco;
        Comidas = listaComidas;
        Items = itens;
        ListaBebidas = bebidas;
        Bebidas = new Dictionary<string, int>();
    }

    public abstract string RetornarTipo();

    public string RetornarStringComida()
    {
        string retorno = "";
        foreach(var comida in Comidas)
        {
            retorno += $"{comida};";
        }
        return retorno;
    }

    public string RetornarStringItems()
    {
        string retorno = "";
        foreach (var item in Items)
        {
            retorno += $"{item};";
        }
        return retorno;
    }


    public string RetornarStringBebidas()
    {
        string retorno = "";
        foreach (var bebida in ListaBebidas)
        {
            retorno += $"{bebida};";
        }
        return retorno;
    }

    public override string ToString()
    {
        // lembrar de mudar
        string comidasStr = Comidas != null ? string.Join(", ", Comidas) : "Nenhuma";
        string bebidasStr = Bebidas != null ? string.Join(", ", ListaBebidas) : "Nenhuma";

        return $"Evento Id: {Id}\n" +
               $"Data: {Data}\n" +
               $"Número de Convidados: {NumeroDeConvidados}\n" +
               $"Space Id: {SpaceId}\n" +
               $"Tipo de Serviço: {TipoServico}\n" +
               $"Tipo de Festa: {RetornarTipo()}\n" +
               $"Preço: {Preco:C}\n" +
               $"Comidas: {comidasStr}\n" +
               $"Bebidas: {bebidasStr}";
    }
}