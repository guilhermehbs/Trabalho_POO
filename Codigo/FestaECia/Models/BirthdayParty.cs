using FestaECia.Models.Enums;

namespace FestaECia.Models;

public class BirthdayParty : Party 
{
	public BirthdayParty(DateTime date, int numberOfGuests, PartyType type, double price) :
		base(date, numberOfGuests, type, price)
	{
	}

	public BirthdayParty(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price) : 
        base(id, date, numberOfGuests, space, type, price)
    {
    }
}