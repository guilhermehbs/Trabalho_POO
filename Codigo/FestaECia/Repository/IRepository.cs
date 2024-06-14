namespace FestaECia.Repository
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
