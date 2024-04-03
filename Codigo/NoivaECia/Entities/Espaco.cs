namespace Trabalho_POO.Entities
{
	public class Espaco
	{
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }
        public bool Disponivel { get; set; }

        public Espaco(string nome, int capacidade)
        {
            Nome = nome;
            Capacidade = capacidade;
            Disponivel = true;
        }
    }
}
