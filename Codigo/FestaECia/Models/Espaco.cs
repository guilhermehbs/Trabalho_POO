﻿using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace FestaECia.Models
{
	public class Espaco
	{
		public int Id { get; }
		public string Nome { get; }
		public int Capacidade { get; }
		public double Preco { get; private set; }

		public List<DateTime> DatasMarcadas;

		public Espaco(int id, string nome, int capacidade, List<DateTime> datasMarcadas, double preco)
		{
			Id = id;
			Nome = nome;
			Capacidade = capacidade;
			Preco = preco;
			DatasMarcadas = datasMarcadas;
		}

		public Espaco()
		{
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Id: {Id}, Nome: {Nome}, Capacidade: {Capacidade}");
			sb.AppendLine("Datas Marcadas:");
			foreach (DateTime data in DatasMarcadas)
			{
				sb.AppendLine(data.ToString("yyyy MMMM dd"));
			}

			return sb.ToString();
		}
	}
}
