using FestaECia.Models;
using FestaECia.Repository;

namespace FestaECia.Services;

public class PartyService
{
	private readonly PartyRepository _partyRepository;

	public PartyService(PartyRepository partyRepository)
	{
		_partyRepository = partyRepository;
	}

	public IEnumerable<Party> GetAllParties()
	{
		return _partyRepository.GetAll();
	}

	public Party GetPartyById(int id)
	{
		return _partyRepository.GetById(id);
	}

	public void CreateParty(Party party)
	{
		_partyRepository.Insert(party);
	}

	public void UpdateParty(Party party)
	{
		_partyRepository.Update(party);
	}

	public void DeleteParty(int id)
	{
		_partyRepository.Delete(id);
	}
}