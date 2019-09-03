using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.AcessoDados.Interface
{
       // todas as classes que herdarem essa interface, tem como obrigação implementar esses metodos.
       // como uma espécie de contrato
    public interface IRepositorio<T> where T: class
    {
        string Salvar(T entidade);
        string Deletar(T entidade);
        T BuscarId(string cpf);

        T BuscarId(int id);
        IEnumerable<T> ListarTodos();
    }
}
