using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_POO.Entities.Enums;

namespace FestaECia.Services
{
	public class FoodService
	{ 
		public static double DefineFoodsValue(CategoryType typeWedding, int numberOfGuests)
		{

			if (numberOfGuests < 0)
			{
				throw new ArgumentException("The quantity of people must be upper than 0");
			}
			if (typeWedding.Equals(CategoryType.Premier))
			{
				return 240 * numberOfGuests;
			}
			else if (typeWedding.Equals(CategoryType.Luxo))
			{
				return 192 * numberOfGuests;
			}
			else if (typeWedding.Equals(CategoryType.Standard))
			{
				return 160 * numberOfGuests;
			}
			else
			{
				throw new ArgumentException("This type does not exist in our database");
			}
		}
	}
}
