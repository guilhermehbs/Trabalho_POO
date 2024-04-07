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

		public Wedding ScheduleWedding(int numberOfGuests)
		{
			Space betterSpace;
			DateTime date;
			Wedding wedding;

			try
			{
				betterSpace = BestWeddingSpace(numberOfGuests);
				date = NextDateAvailable();

				if (betterSpace == null)
				{
					throw new ArgumentNullException("No space available with this number of guests");
				}
				if(date == DateTime.MinValue)
				{
					throw new Exception("There are no dates available");
				}

				wedding = new Wedding(date, numberOfGuests, betterSpace);
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
			betterSpace.Available = false;
			return wedding;
		}

		public bool CancelWedding(Wedding wedding)
		{
			try
			{
				if (wedding == null)
				{
					throw new ArgumentNullException();
				}

				if (!ListScheduledWeddings.Contains(wedding))
				{
					throw new InvalidOperationException();
				}

				ListScheduledWeddings.Remove(wedding);
				return true;
			}
			catch (ArgumentNullException)
			{
				throw new ArgumentNullException("Wedding cannot be null");
			}
			catch (InvalidOperationException)
			{
				throw new InvalidOperationException("The wedding was not found in the list");
			}
		}


		public DateTime NextDateAvailable()
		{
			DateTime actualDate = DateTime.Today;
			DateTime minimumDate = actualDate.AddDays(30);

			DateTime nextDateAvailable = minimumDate;

			while (DateIsBusy(nextDateAvailable) || !IsFridayOrSaturday(nextDateAvailable))
			{
				nextDateAvailable = nextDateAvailable.AddDays(1);
			}

			return nextDateAvailable;
		}

		public Space BestWeddingSpace(int numberOfGuests)
		{
			ListSpaces.OrderBy(e => e.Capacity).ToList();

			foreach(Space space in ListSpaces)
			{
				if(space.Capacity >= numberOfGuests && space.Available)
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