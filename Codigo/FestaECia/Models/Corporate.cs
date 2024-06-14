using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class Corporate : Party
{
    public Corporate(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price) : 
        base(id, date, numberOfGuests, space, type, price)
    {
    }
}