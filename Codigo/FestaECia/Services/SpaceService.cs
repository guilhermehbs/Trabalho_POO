using FestaECia.Models;
using FestaECia.Repository;

namespace FestaECia.Services;

public class SpaceService
{
	private readonly SpaceRepository _spaceRepository;

	public SpaceService(SpaceRepository spaceRepository)
	{
		_spaceRepository = spaceRepository;
	}

	public SpaceService()
	{
		
	}

	public List<Space> QuantityAvailabeSpaceList(int peopleQuantity)
	{
		List<Space> spaceList = ListAllSpaces();
		spaceList = spaceList.Where(space => space.Capacity >= peopleQuantity).ToList();
		spaceList = spaceList.OrderBy(space => space.Capacity).ToList();

		return spaceList;
	}

	public List<Space> ListAllSpaces()
	{
		return _spaceRepository.GetAll();
	}

	public Space GetPartyById(int id)
	{
		return _spaceRepository.GetById(id);
	}
}