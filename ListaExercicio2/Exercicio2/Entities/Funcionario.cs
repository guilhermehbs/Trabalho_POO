namespace Exercicio2.Entities
{
	internal class Funcionario
	{
		public static int MaximoHorasPorMes = 200;
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        public int Departamento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public static int HorasTrabalhadas { get; set; }
        public Queue<Tarefa> Fila_Tarefas { get; set; }

        public Funcionario(string nome, string cargo, int departamento, DateTime dataAdmissao)
		{
			Nome = nome;
			Cargo = cargo;
			Departamento = departamento;
			DataAdmissao = dataAdmissao;
			Fila_Tarefas = new Queue<Tarefa>(10);
		}

		public bool AdicionarTarefas(string nome)
		{
			Tarefa tarefa = new Tarefa(nome);
			Fila_Tarefas.Enqueue(tarefa);
			return true;
		}

		public bool ExecutarTarefas()
		{
			if (Fila_Tarefas.Count > 0)
			{
				Tarefa ultimaTarefa = Fila_Tarefas.Peek();

				if (HorasTrabalhadas == 0 || ultimaTarefa.HorasTrabalhadas > 0)
				{
					Fila_Tarefas.Dequeue();
					return true;
				}
			}
			return false;
		}

		public bool LancarHoras(Tarefa tarefa, int horasTrabalhadas)
		{
			int horasAposLancar = HorasTrabalhadas + horasTrabalhadas;
			if (horasAposLancar > MaximoHorasPorMes) { return false; }
			HorasTrabalhadas += horasTrabalhadas;
			tarefa.HorasTrabalhadas += horasTrabalhadas;
			return true;
		}
	}
}
