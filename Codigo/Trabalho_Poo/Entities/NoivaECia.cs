namespace Trabalho_POO.Entities
{
	public class NoivaECia
	{
        public List<Space> ListSpaces { get; private set; }
		public List<Wedding> ListScheduledWeddings { get; private set; }

		public NoivaECia()
		{
			ListSpaces = new List<Space>();
			ListSpaces.Add(new Space("A", 100));
			ListSpaces.Add(new Space("B", 100));
			ListSpaces.Add(new Space("C", 100));
			ListSpaces.Add(new Space("D", 100));
			ListSpaces.Add(new Space("E", 200));
			ListSpaces.Add(new Space("F", 200));
			ListSpaces.Add(new Space("G", 50));
			ListSpaces.Add(new Space("H", 500));

			ListScheduledWeddings = new List<Wedding>();
		}

		public Wedding ScheduleWedding(int NumberOfGuests)
		{
			Space betterSpace;
			DateTime date;
			Wedding wedding;

			try
			{
				betterSpace = BestWeddingSpace(NumberOfGuests);
				date = NextDateAvailabe();

				if (betterSpace == null)
				{
					throw new ArgumentNullException("No space available with this number of guests");
				}
				if(date == DateTime.MinValue)
				{
					throw new Exception("There are no dates available");
				}

				wedding = new Wedding(date, NumberOfGuests, betterSpace);
			}
			catch (ArgumentNullException ex)
			{
				throw new ArgumentNullException("Argument Null Exception: " + ex.Message);
			}
			catch (Exception ex)
			{
				throw new Exception("Exception: " + ex.Message);
			}

			ListScheduledWeddings.Add(wedding);
			betterSpace.Availabe = false;
			return wedding;
		}


		public DateTime NextDateAvailabe()
		{
			DateTime actualDate = DateTime.Now;
			DateTime minimumDate = actualDate.AddDays(30);

			DateTime nextDateAvailabe = minimumDate;

			if(DateIsBusy(nextDateAvailabe) || !IsFridayOrSaturday(nextDateAvailabe))
			{
				while(DateIsBusy(nextDateAvailabe) || !IsFridayOrSaturday(nextDateAvailabe))
				{
					nextDateAvailabe.AddDays(1);
				}
			}

			return nextDateAvailabe;
		}

		public Space BestWeddingSpace(int NumberOfGuests)
		{
			ListSpaces.OrderBy(e => e.Capacity).ToList();

			foreach(Space space in ListSpaces)
			{
				if(space.Capacity >= NumberOfGuests && space.Availabe)
				{
					return space;
				}
			}

			return null;
		}

		private bool IsFridayOrSaturday(DateTime date)
		{
			return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
		}
		private bool DateIsBusy(DateTime date)
		{
			bool result = false;
			try
			{
				result = ListScheduledWeddings.Any(c => c.Date == date);
			}

			catch (ArgumentNullException)
			{
				result = false;
			}

			return result;
		}
	}
}