using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_POO.Entities.Enums;

namespace FestaECia.Services
{
	public class ItemsService
	{
		public static double DefineItemsValue(CategoryType typeWedding, int numberOfGuests)
		{

			if (numberOfGuests < 0)
			{
				throw new ArgumentException("The quantity of people must be upper than 0");
			}
			if (typeWedding.Equals(CategoryType.Premier))
			{
				return 250 * numberOfGuests;
			}
			else if (typeWedding.Equals(CategoryType.Luxo))
			{
				return 190 * numberOfGuests;
			}
			else if (typeWedding.Equals(CategoryType.Standard))
			{
				return 130 * numberOfGuests;
			}
			else
			{
				throw new ArgumentException("This type does not exist in our database");
			}
		}
	}
}
