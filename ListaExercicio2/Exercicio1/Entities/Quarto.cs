namespace Exercicio1.Entities
{
	internal class Quarto
	{
        public double Preco { get; private set; }
        public string Indicacao { get; private set; }
        public Chave Chave { get;}
        public string StatusLimpeza { get; set; }
        public string Tipo { get; set; }
        public Hospede Hospede { get; private set; }

        public Quarto(string tipo)
		{
			Preco = 100;
			Indicacao = "Livre";
			StatusLimpeza = "Limpo";
			Tipo = tipo;
			Chave = new Chave();
		}

		public void Ocupar(Hospede hospede)
		{
			Hospede = hospede;
			Indicacao = "Ocupado";
		}

		public void Desocupar()
		{
			Indicacao = "Livre";
		}

		public void LimparQuarto()
		{
			StatusLimpeza = "Limpo";
		}
	}
}
