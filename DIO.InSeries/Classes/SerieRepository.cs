using DIO.InSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.InSeries.Classes
{
    class SerieRepository : IRepository<Serie>
    {
        List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entity)
        {
            listaSerie[id] = entity;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Exclui();
        }

        public void Insere(Serie entity)
        {
            listaSerie.Add(entity);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}
