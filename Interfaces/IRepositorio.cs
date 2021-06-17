using System.Collections.Generic;

namespace cad_series.Interfaces {

    public interface IRepositorio<T>{

        List<T> Lista();

        T RetornaId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Alterar(int id, T entidade);
        int ProximoId();
    }
}