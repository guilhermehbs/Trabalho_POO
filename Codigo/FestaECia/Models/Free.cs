using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class Free : Party
{
    public Free(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price) : 
        base(id, date, numberOfGuests, space, type, price)
    {
    }
}