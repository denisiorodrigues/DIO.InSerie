using System.Collections.Generic;

namespace DIO.InSeries.Interfaces
{
    public interface IRepository<T>
    {   
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entity);
        void Exclui(int id);
        void Atualiza(int id, T entity);
        int ProximoId();
    }
}
