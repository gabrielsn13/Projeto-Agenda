using AgendaOnline.AcessoDados.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio.Interfaces
{
    interface ITipoClienteNegocios : IRepositorio<TipoCliente>
    {
        TipoCliente ListarTipoClientes(int param);
    }
}
