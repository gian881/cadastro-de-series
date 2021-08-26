using System.Collections.Generic;
using cadastro_de_series.Interfaces;

namespace cadastro_de_series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Adicionar(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public void Atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public List<Serie> GetLista()
        {
            return listaSerie;
        }

        public Serie GetPorId(int id)
        {
            return listaSerie[id];
        }

        public int ProximoId()
        {
            return listaSerie.Count;

        }
    }
}