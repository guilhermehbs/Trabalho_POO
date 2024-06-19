namespace FestaECia.Models;

public class Calendario
{
    public List<DateTime> Datas { get; private set; }

    public Calendario()
    {
        Datas = new List<DateTime>();
    }
}