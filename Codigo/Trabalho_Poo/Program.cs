using System.ComponentModel;
using Trabalho_POO.Entities;

namespace Trabalho_POO
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string,int> drinkQuantity = new Dictionary<string,int>();
            string[] auxVet = ["sparking water", "juice", "soda", "beer", "national sparkling wine", "draft beer", "imported sparkling wine"];
			int drinksLenght;
			Wedding wedding = new Wedding();
			NoivaECia noivaECia = new NoivaECia();
			string type = "standard";

		
			
			if (type.ToLower().Equals("luxo") || type.ToLower().Equals("premier")){
				drinksLenght = auxVet.Length;
			}
			else
			{
				drinksLenght = auxVet.Length -2;
			}

			for (int i = 0; i< drinksLenght; i++) {
				Console.Write($"How many {auxVet[i]} do you want: ");
				try
				{
					int quantity = int.Parse(Console.ReadLine());
					drinkQuantity.Add(auxVet[i], quantity);
				}
				catch (ArgumentException) { throw new ArgumentException("Invalid type"); }	
			}

			noivaECia.ScheduleWedding(100, "luxo", drinkQuantity);

			//noivaECia.CancelWedding(wedding);
		}


	}
}
