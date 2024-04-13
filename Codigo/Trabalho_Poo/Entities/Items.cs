using Trabalho_POO.Entities.Enums;

namespace Trabalho_POO.Entities
{
	static class Items
	{
		public static double DefineItemsValue(Types typeWedding, int numberOfGuests)
		{

			if (numberOfGuests < 0) 
			{ 
				throw new ArgumentException("The quantity of people must be upper than 0"); 
			}
			if (typeWedding.Equals(Types.Premier))
			{
				return  250 * numberOfGuests;
			}
			else if (typeWedding.Equals(Types.Luxo)) 
			{ 
				return  190 * numberOfGuests; 
			}
			else if (typeWedding.Equals(Types.Standard)) 
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
