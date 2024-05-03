using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_POO.Entities.Enums;

namespace Trabalho_POO.Entities
{
	static class Drinks
	{

		public static double DefineDrinksValue(Types typeWedding, int numberOfGuests, Dictionary<string,int> totalDrinks)
		{
			 Dictionary<string, double> drinksValue = new Dictionary<string, double>()
			{
				{"sparking water", 5.00},
				{"juice", 7.00},
				{"soda", 8.00},
				{"beer", 20.00},
				{"national sparkling wine", 30.00},
				{"draft beer", 80.00},
				{"imported sparkling wine", 140.00}
			};

			double valueTotal = 0;

			foreach(var keyValuePair in totalDrinks)
			{
				valueTotal += (drinksValue[keyValuePair.Key] * numberOfGuests);
			}

			return valueTotal;
		}

		
	}
}
