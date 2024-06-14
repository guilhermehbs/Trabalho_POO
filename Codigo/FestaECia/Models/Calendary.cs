using System.Runtime.InteropServices.JavaScript;

namespace FestaECia.Models;

public class Calendary
{
    public List<DateTime> Dates { get; private set; }

    public Calendary()
    {
        Dates = new List<DateTime>();
    }

    public DateTime ScheduleDate()
    {
        DateTime nextDate = DateTime.Now.AddDays(30);
        while (!ValidateDate(nextDate.Date) || !IsFridayOrSaturday(nextDate.Date))
        {
            nextDate = nextDate.AddDays(1);
        }
        
        Dates.Add(nextDate.Date);
        return nextDate.Date;
    }

    public bool ValidateDate(DateTime date)
    {
        return Dates.Any(d => d.Date == date.Date);
    }
    
    private bool IsFridayOrSaturday(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
    }
}