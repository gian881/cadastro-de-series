using System.Collections.Generic;

namespace cadastro_de_series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> GetLista();
        T GetPorId(int id);
        void Adicionar(T objeto);
        void Excluir(int id);
        void Atualizar(int id, T objeto);
        int ProximoId();
    }
}