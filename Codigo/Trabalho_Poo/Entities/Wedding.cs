namespace Trabalho_POO.Entities
{
	public class Wedding
	{
        public DateTime Date { get; private set; }
		public int NumberOfGuests {  get; private set; }
        public Space Space { get; private set; }

		public Wedding() { }

		public Wedding(DateTime date, int guestNumber, Space space)
		{
			Date = date;
			NumberOfGuests = guestNumber;
			Space = space;
		}
	}
}
