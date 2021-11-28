using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
       List<T> Lista(); //Método Lista retrona uma lista de T.
       T RetornaPorId(int id); //Recebe um id como parametro e retonra T.
       void Insere(T entidade);
       void Exclui(int id);
       void Atualiza(int id, T entidade);
       int ProximoId();
    }
}