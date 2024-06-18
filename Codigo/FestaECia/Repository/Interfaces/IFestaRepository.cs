using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Repository.Interfaces
{
    public interface IFestaRepository
    {
        List<Festa> ListarTodos();
        void Inserir(Festa festa);
        void Deletar(int id);
    }
}