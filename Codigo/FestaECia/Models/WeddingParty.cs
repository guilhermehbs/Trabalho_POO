using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class WeddingParty : Party
{
    public WeddingParty(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price) : 
        base(id, date, numberOfGuests, space, type, price)
    {
    }
}