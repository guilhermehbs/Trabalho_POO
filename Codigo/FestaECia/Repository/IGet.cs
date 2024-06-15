namespace FestaECia.Repository
{
	public interface IGet<T>
	{
		List<T> ListarTodos();
		T PegarPorId(int id);
	}
}
