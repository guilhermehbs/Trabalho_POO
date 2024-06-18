namespace FestaECia.Repository.Interfaces
{
    public interface IGet<T>
    {
        List<T> ListarTodos();
        T PegarPorId(int id);
    }
}
