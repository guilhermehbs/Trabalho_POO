namespace Trabalho_POO.Entities
{
	public class Mariage
	{
        public DateTime Date { get; private set; }
		public int GuestNumber {  get; private set; }
        public Space Space { get; private set; }

		public Mariage(DateTime date, int guestNumber, Space space)
		{
			Date = date;
			GuestNumber = guestNumber;
			Space = space;
		}
	}
}
