namespace FestaECia.Repository
{
	public interface ISet<T>
	{
		public void Inserir(T entidade);

		public void Deletar(int id);
	}
}
