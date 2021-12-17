#pragma warning disable CS8600

using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series

{
    public class SerieRepositorio : Irepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }        
        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);        
        }
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }
        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
        public List<Serie> Lista()
        {
            return listaSerie;
        }
    }
}

#pragma warning disable CS8600
