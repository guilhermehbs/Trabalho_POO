namespace Trabalho_POO.Entities
{
	public class NoivaECia
	{
        static public List<Espaco> Espacos { get; private set; }
		static public List<Casamento> CasamentosAgendados { get; private set; }

		public NoivaECia()
		{
			Espacos = new List<Espaco>();
			Espacos.Add(new Espaco("A", 100));
			Espacos.Add(new Espaco("B", 100));
			Espacos.Add(new Espaco("C", 100));
			Espacos.Add(new Espaco("D", 100));
			Espacos.Add(new Espaco("E", 200));
			Espacos.Add(new Espaco("F", 200));
			Espacos.Add(new Espaco("G", 50));
			Espacos.Add(new Espaco("H", 500));

			CasamentosAgendados = new List<Casamento>();
		}

		public Casamento AgendarCasamento(int numeroConvidados)
		{
			Espaco melhorEspaco;
			DateTime data;
			Casamento casamento;

			try
			{
				melhorEspaco = MelhorEspacoParaCasamento(numeroConvidados);
				data = ProximaDataDisponivel();

				if (melhorEspaco == null)
				{
					throw new ArgumentNullException("Nenhum espaço disponível com essa quantidade de convidados");
				}
				if(data == DateTime.MinValue)
				{
					throw new Exception("Não existem datas disponíveis");
				}

				casamento = new Casamento(data, numeroConvidados, melhorEspaco);
			}
			catch (ArgumentNullException ex)
			{
				throw new ArgumentNullException("Argument Null Exception: " + ex.Message);
			}
			catch (Exception ex)
			{
				throw new Exception("Exception: " + ex.Message);
			}

			CasamentosAgendados.Add(casamento);
			melhorEspaco.Disponivel = false;
			return casamento;
		}


		public DateTime ProximaDataDisponivel()
		{
			DateTime dataAtual = DateTime.Now;
			DateTime dataMinima = dataAtual.AddDays(30);

			DateTime proximaDataDisponivel = dataMinima;

			if(DataEstaAgendada(proximaDataDisponivel) || !EhSextaOuSabado(proximaDataDisponivel))
			{
				while(DataEstaAgendada(proximaDataDisponivel) || !EhSextaOuSabado(proximaDataDisponivel))
				{
					proximaDataDisponivel.AddDays(1);
				}
			}

			return proximaDataDisponivel;
		}

		public Espaco MelhorEspacoParaCasamento(int numeroConvidados)
		{
			Espacos.OrderBy(e => e.Capacidade).ToList();

			foreach(Espaco espaco in Espacos)
			{
				if(espaco.Capacidade >= numeroConvidados && espaco.Disponivel)
				{
					return espaco;
				}
			}

			return null;
		}

		private bool EhSextaOuSabado(DateTime data)
		{
			return data.DayOfWeek == DayOfWeek.Friday || data.DayOfWeek == DayOfWeek.Saturday;
		}
		private bool DataEstaAgendada(DateTime data)
		{
			bool resultado = false;
			try
			{
				resultado = CasamentosAgendados.Any(c => c.Data == data);
			}

			catch (ArgumentNullException)
			{
				resultado = false;
			}

			return resultado;
		}
	}
}
