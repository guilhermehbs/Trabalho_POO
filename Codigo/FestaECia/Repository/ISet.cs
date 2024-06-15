namespace FestaECia.Repository
{
	public interface ISet<T>
	{
		public void Insert(T entity);

		public void Update(T entity);

		public void Delete(int id);
	}
}
