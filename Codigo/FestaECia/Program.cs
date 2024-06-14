using FestaECia.Models;
using FestaECia.Repository;
using FestaECia.Services;

namespace FestaECia;

class Program
{
	static void Main(string[] args)
	{
/*
		var partyRepository = new PartyRepository();
		var partyService = new PartyService(partyRepository);

		int option = 0;

		while (option != 5)
		{
			Console.WriteLine("1. List all parties");
			Console.WriteLine("2. Add a new party");
			Console.WriteLine("3. Update a party");
			Console.WriteLine("4. Delete a party");
			Console.WriteLine("5. Exit");

			var choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					ListAllParties(partyService);
					break;
				case "2":
					AddNewParty();
					break;
				case "3":
					UpdateParty();
					break;
				case "4":
					DeleteParty();
					break;
				case "5":
					return;
			}
		}
	}

	static void ListAllParties(PartyService partyService)
	{
		var parties = partyService.GetAllParties();
		foreach (var party in parties)
		{
			Console.WriteLine($"{party.Id}: {party.Type} on {party.Date}");
		}
	}

	static void AddNewParty()
	{

	}

	static void UpdateParty()
	{

	}

	static void DeleteParty()
	{

	}
	*/

		Calendary calendary = new Calendary();

		DateTime date1 = calendary.ScheduleDate();
		DateTime date2 = calendary.ScheduleDate();
		DateTime date3 = calendary.ScheduleDate();
		DateTime date4 = calendary.ScheduleDate();

		Console.WriteLine(date1.Date.ToString());
		Console.WriteLine(date2.Date.ToString());
		Console.WriteLine(date3.Date.ToString());
		Console.WriteLine(date4.Date.ToString());
	}
}