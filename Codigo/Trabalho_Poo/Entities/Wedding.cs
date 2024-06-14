using FestaECia.Entities;

namespace Trabalho_POO.Entities
{
	public class Wedding : Party
	{
		public Wedding() { }

		public Wedding(DateTime date, int guestNumber, Space space, string type, Dictionary<string, int> drinkQuantity) 
			: base(date, guestNumber, space, type)
		{
		}
	}
}
