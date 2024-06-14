using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class Graduation : Party
{
    public Graduation(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price) : 
        base(id, date, numberOfGuests, space, type, price)
    {
    }
}