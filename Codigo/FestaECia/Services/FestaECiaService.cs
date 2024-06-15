using FestaECia.Models;
using FestaECia.Repository;

namespace FestaECia.Services;

public class FestaECiaService
{
	private readonly PartyRepository _partyRepository;
	public CalendaryService calendary;
	public SpaceService spaceService;

	public FestaECiaService(PartyRepository partyRepository)
	{
		_partyRepository = partyRepository;
		calendary = new CalendaryService();
		spaceService = new SpaceService(new SpaceRepository());
	}

	public void ScheduleParty(Party party)
	{
		DateTime date = calendary.ScheduleDate();
		List<Space> spacesAvailabe = spaceService.QuantityAvailabeSpaceList(party.NumberOfGuests);
		foreach (Space space in spacesAvailabe)
		{
			if (!space.DatasMarcadas.Contains(date))
			{
				Console.WriteLine("Marcado no espaço " + space.Name);
				Console.WriteLine("Marcado na data " + date);
				break;
			}
		}

		//_partyRepository.Insert(party);
	}

	public void UpdateParty(Party party)
	{
		_partyRepository.Update(party);
	}

	public void DeleteParty(int id)
	{
		_partyRepository.Delete(id);
	}

	public List<Party> ListAllParties()
	{
		return _partyRepository.GetAll();
	}

	public Party GetPartyById(int id)
	{
		return _partyRepository.GetById(id);
	}
}