namespace FestaECia.Repository.Interfaces
{
    public interface IManipulavel<T>
    {
        public void Inserir(T entidade);
        public void Deletar(int id);

    }
}
