namespace FestaECia.Models;

public class Calendary
{
    public List<DateTime> Dates { get; private set; }

    public Calendary()
    {
        Dates = new List<DateTime>();
    }
}