using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.AcessoDados.Interface;

namespace AgendaOnline.Dominio.Interfaces
{
    interface IClienteNegocios : IRepositorio<Cliente>
    {
        Cliente ListarCliente(string param);
    }
}
