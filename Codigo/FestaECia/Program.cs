using FestaECia.Models;
using FestaECia.Models.Enums;
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

		Calendary calendary = new Calendary();

        DateTime date1 = calendary.ScheduleDate();
		DateTime date2 = calendary.ScheduleDate();
		DateTime date3 = calendary.ScheduleDate();

        DateTime date4 = calendary.ScheduleDate();

		Console.WriteLine(date1.Date.ToString());
		Console.WriteLine(date2.Date.ToString());
		Console.WriteLine(date3.Date.ToString());

        Console.WriteLine(date4.Date.ToString());
        Console.WriteLine(calendary.lastScheduledDay().ToString());
		*/
		for (int i = 0; i < 5; i++) {

            FestaRepository repository = new FestaRepository();
            FestaECiaService service = new FestaECiaService(repository);

            List<Comida> comidas = new List<Comida>();
            Dictionary<string, int> bebidas = new Dictionary<string, int>()
            {
                {"agua sem gas", 10},
                {"suco", 10},
                {"refrigerante", 10},
                {"cerveja comum", 10},
                {"cerveja artesanal", 1},
                {"espumante nacional", 10},
                {"espumante importado", 10}
            };

            Festa festa = new FestaDeAniversario(201, TipoServico.Premier, comidas, bebidas);

            service.MarcarFesta(festa);
        }

        
 
	}
}