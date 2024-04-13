namespace Exercicio1.Entities
{
	internal class Hospede
	{
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }

		public Hospede(string nome, string cpf, string endereco, string telefone)
		{
			Nome = nome;
			Cpf = cpf;
			Endereco = endereco;
			Telefone = telefone;
		}
	}
}
