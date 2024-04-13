using Trabalho_POO.Entities.Enums;
namespace Trabalho_POO.Entities
{
	public class Wedding
	{
        public DateTime Date { get; private set; }
		public int NumberOfGuests {  get; private set; }
        public Space Space { get; private set; }
		public Types TypeWedding { get; private set; }
		public double PriceWedding { get; private set; }

		public Wedding() { }

		public Wedding(DateTime date, int guestNumber, Space space, string typeWedding)
		{
			Date = date;
			NumberOfGuests = guestNumber;
			Space = space;
			TypeWedding = DefineTypeWedding(typeWedding);
			PriceWedding = Items.DefineItemsValue(TypeWedding, NumberOfGuests);

		}

		private Types DefineTypeWedding(string type)
		{
			if (type.ToLower().Equals("premier"))
			{
				return Types.Premier;
			}
			else if (type.ToLower().Equals("luxo")) 
			{ 
				return Types.Luxo; 
			}
			else if (type.ToLower().Equals("standard"))
			{ 
				return Types.Standard; 
			}
			else
			{
				throw new ArgumentException("This type does not exist in our database");
			}
		}
	}
}
