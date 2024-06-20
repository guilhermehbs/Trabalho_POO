using FestaECia.Models;
using FestaECia.Services.Interfaces;

namespace FestaECia.Services;

public class CalendarioService : ICalendarioService
{
	public Calendario Calendario;

	public CalendarioService()
	{
		Calendario = new Calendario();
	}

	public DateTime MarcarData()
	{
		try
		{
			DateTime nextDate = DateTime.Now.Date.AddDays(30);
			while (DataNaoEValida(nextDate.Date) || !EhSabadoOuDomingo(nextDate.Date))
			{
				nextDate = nextDate.AddDays(1);
			}

			Calendario.Datas.Add(nextDate.Date);
			return nextDate.Date;
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao marcar a data " + ex.Message);
		}
	}
    
    public DateTime MarcarData(DateTime dataAtual)
    	{
		    try
		    {
			    while (DataNaoEValida(dataAtual.Date) || !EhSabadoOuDomingo(dataAtual.Date))
			    {
				    dataAtual = dataAtual.AddDays(1);
			    }

			    Calendario.Datas.Add(dataAtual.Date);
			    return dataAtual.Date;
		    }
			catch (Exception ex)
			{
				throw new Exception("Erro ao marcar a data " + ex.Message);
			}
	}


	public bool DataNaoEValida(DateTime date)
	{
		return Calendario.Datas.Any(d => d.Date == date.Date);
	}

	private bool EhSabadoOuDomingo(DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
	}

	public DateTime UltimaDataMarcada()
	{
		try
		{
			if (Calendario.Datas.Count == 0) { throw new IndexOutOfRangeException("Não existe datas marcadas"); }
			return Calendario.Datas[Calendario.Datas.Count - 1];
		}
		catch (Exception ex)
		{
			throw new Exception("Erro ao retornar ultima data marcada " + ex.Message);
		}
	}
}

