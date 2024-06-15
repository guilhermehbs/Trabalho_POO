namespace FestaECia.Repository
{
	public interface IGet<T>
	{
		List<T> GetAll();
		T GetById(int id);
	}
}
