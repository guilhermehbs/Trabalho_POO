using System.Text;
using FestaECia.Models.Enums;

namespace FestaECia.Models;

public abstract class Festa
{
    public int Id { get; private set; }
    public DateTime Data { get; set; }
    public int NumeroDeConvidados { get; set; }
    public int SpaceId { get; set; }
    public TipoServico TipoServico { get;  set; }
    public double Preco { get;  set; }
    public List<string> Comidas { get; set; }
    public List<string> Items { get; set; }
    public Dictionary<string, int> Bebidas { get; set; }
	public List<string> ListaBebidas { get; set; }

    public Festa(){}

	public Festa(int numeroDeConvidados, TipoServico tipoServico, Dictionary<string, int> bebidas)
	{
		NumeroDeConvidados = numeroDeConvidados;
		TipoServico = tipoServico;
		Bebidas = bebidas;
 
	}

    //construtor usado pelo banco
	public Festa(int id, DateTime data, int numeroDeConvidados, int spaceId, TipoServico tipoServico, 
		double preco, List<string> listaComidas, List<string> itens, List<string> bebidas)
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
        StringBuilder sb = new StringBuilder();
		sb.AppendLine("------------------------------------------------------------------------------------------------------------------------");
		sb.AppendLine(
	        $"Id: {Id}, Data: {Data.ToString("yy-MMM-dd ddd")}, N�mero de convidados: {NumeroDeConvidados}, Id do espa�o: {SpaceId}, " +
	        $"Tipo do servi�o:{TipoServico}, Tipo da festa: {RetornarTipo()}, Pre�o total: {Preco}");

        sb.AppendLine("Comidas:");
		foreach (string comida in Comidas)
		{
			sb.Append(comida);
			if (comida != Comidas.Last())
			{
				sb.Append(",");
			}
		}

		sb.AppendLine();

		sb.AppendLine("Bebidas:");
        foreach (string bebida in ListaBebidas)
        {
            sb.Append(bebida);
            if (bebida != ListaBebidas.Last())
            {
                sb.Append(",");
            }
        }
        sb.AppendLine();

		sb.AppendLine("Itens:");
		foreach (string item in Items)
		{
			sb.Append(item);
			if (item != Items.Last())
			{
				sb.Append(",");
			}
		}

		sb.AppendLine();
		sb.AppendLine("------------------------------------------------------------------------------------------------------------------------");

		return sb.ToString();
	}
}