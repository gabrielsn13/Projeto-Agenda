using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;

namespace AgendaOnline.Dominio.Negocios
{
    public class ClienteNegocios : ClienteRepositorio, IClienteNegocios
    {
        public Cliente ListarCliente(string param)
        {
            //busca o primeiro resultado encontrado
            var cliente = BuscarId(param);
            return cliente;
        }
    }
}
