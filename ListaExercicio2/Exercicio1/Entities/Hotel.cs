using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1.Entities
{
	internal class Hotel
	{
		public const int QUANTIDADE_DE_QUARTOS = 30;

		public Quarto[] Quartos = new Quarto[QUANTIDADE_DE_QUARTOS];

		public Hotel() { }

		public Chave CheckIn(string nome, string cpf, string endereco, string telefone, string tipoQuarto)
		{
			Hospede hospede = new Hospede(nome, cpf, endereco, telefone);

			Quarto quarto = new Quarto(tipoQuarto);

			if(quarto.Indicacao == "Ocupado")
			{
				return null;
			}

			Quartos.Append(quarto);

			quarto.Ocupar(hospede);

			return quarto.Chave;
		}

		public void CheckOut(int chaveQuarto)
		{
			Quarto quartoDesocupar = null;

			foreach (Quarto quarto in Quartos)
			{
				if(chaveQuarto == quarto.Chave.Numero) 
				{
					quartoDesocupar = quarto;
					break;
				}
			}

			if (quartoDesocupar != null && quartoDesocupar.Indicacao == "Ocupado")
			{
				quartoDesocupar.Desocupar();
				quartoDesocupar.LimparQuarto();
			}
			else
			{
				throw new Exception("O quarto não está cadastrado");
			}
		}
	}
}
