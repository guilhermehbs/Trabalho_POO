namespace Exercicio1.Entities
{
	internal class Chave
	{
		public static int NumeroProximaChave = 0;
		public int Numero = ++NumeroProximaChave;
    }
}
