using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class BirthdayParty : Party 
{
   public BirthdayParty(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price) : 
        base(id, date, numberOfGuests, space, type, price)
    {
    }
}