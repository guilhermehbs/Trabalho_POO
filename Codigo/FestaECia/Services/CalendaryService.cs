using FestaECia.Models;

namespace FestaECia.Services;

public class CalendaryService
{
	public Calendary calendary;

	public CalendaryService()
	{
		calendary = new Calendary();
	}

	public DateTime ScheduleDate()
	{
		DateTime nextDate = DateTime.Now.Date.AddDays(30);
		while (IsNotValidateDate(nextDate.Date) || !IsFridayOrSaturday(nextDate.Date))
		{
			nextDate = nextDate.AddDays(1);
		}

		calendary.Dates.Add(nextDate.Date);
		return nextDate.Date;
	}



	public bool IsNotValidateDate(DateTime date)
	{
		return calendary.Dates.Any(d => d.Date == date.Date);
	}

	private bool IsFridayOrSaturday(DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
	}

	public DateTime lastScheduledDay()
	{
		if (calendary.Dates.Count == 0) { throw new IndexOutOfRangeException("There are no scheduled dates"); }
		return calendary.Dates[calendary.Dates.Count - 1];
	}
}

