namespace Trabalho_POO.Entities
{
	public class Casamento
	{
        public DateTime Data { get; private set; }
		public int NumeroConvidados {  get; private set; }
        public Espaco Espaco { get; private set; }

		public Casamento(DateTime data, int numeroConvidados, Espaco espaco)
		{
			Data = data;
			NumeroConvidados = numeroConvidados;
			Espaco = espaco;
		}
	}
}
