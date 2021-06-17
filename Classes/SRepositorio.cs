using System;
using System.Collections.Generic;
using cad_series.Interfaces;

namespace cad_series {

    public class SRepositorio : IRepositorio<Serie>
    {
        // Variável com a lista das séries
        private List<Serie> lista = new List<Serie>();
        
        public void Alterar(int id, Serie objeto)
        {
            lista[id] = objeto;
        }

        public void Excluir(int id)
        {
            lista[id].Excluir();
        }

        public void Inserir(Serie objeto)
        {
            lista.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return lista;
        }

        public int ProximoId()
        {
            return lista.Count;
        }

        public Serie RetornaId(int id)
        {
            return lista[id];
        }
    }

}