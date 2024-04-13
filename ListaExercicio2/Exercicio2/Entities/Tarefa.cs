namespace Exercicio2.Entities
{
	internal class Tarefa
	{
        public string Nome { get; set; }
        public int HorasTrabalhadas { get; set; }

		public Tarefa(string nome)
		{
			Nome = nome;
		}

		public void LancarHoras(int horasTrabalhadas)
		{
			HorasTrabalhadas = horasTrabalhadas;
		}
	}
}
