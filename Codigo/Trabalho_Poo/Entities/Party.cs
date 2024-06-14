using FestaECia.Services;
using Trabalho_POO.Entities;
using Trabalho_POO.Entities.Enums;

namespace FestaECia.Entities
{
    public class Party
    {
		public DateTime Date { get; private set; }
        public int NumberOfGuests { get; private set; }
        public Space Space { get; private set; }
        public CategoryType Type { get; private set; }
        public double Price { get; private set; }

		public Party()
		{
		}

		public Party(DateTime date, int numberOfGuests, Space space, string type)
		{
			Date = date;
			NumberOfGuests = numberOfGuests;
			Space = space;
			Type = PartyService.DefineType(type);
		}
	}
}
