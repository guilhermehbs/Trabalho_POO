﻿using FestaECia.Models;

namespace FestaECia.Services;

public class CalendarioService
{
	public Calendario Calendario;

	public CalendarioService()
	{
		Calendario = new Calendario();
	}

	public DateTime MarcarData()
	{
		DateTime nextDate = DateTime.Now.Date.AddDays(30);
		while (DataNaoEValida(nextDate.Date) || !EhSabadoOuDomingo(nextDate.Date))
		{
			nextDate = nextDate.AddDays(1);
		}

		Calendario.Datas.Add(nextDate.Date);
		return nextDate.Date;
	}
    
    public DateTime MarcarData(DateTime dataAtual)
    	{
    		while (DataNaoEValida(dataAtual.Date) || !EhSabadoOuDomingo(dataAtual.Date))
    		{
			    dataAtual = dataAtual.AddDays(1);
    		}
    
    		Calendario.Datas.Add(dataAtual.Date);
    		return dataAtual.Date;
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
		if (Calendario.Datas.Count == 0) { throw new IndexOutOfRangeException("There are no scheduled dates"); }
		return Calendario.Datas[Calendario.Datas.Count - 1];
	}
}

