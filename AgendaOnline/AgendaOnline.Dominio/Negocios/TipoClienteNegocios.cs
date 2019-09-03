using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio.Negocios
{
    public class TipoClienteNegocios : TipoClienteRepositorio, ITipoClienteNegocios
    {
        public TipoCliente ListarTipoClientes(int param)
        {
            //busca o primeiro resultado encontrado
            var tiposClientes = ListarTodos().FirstOrDefault(x => x.IDTIPO == param);
            return tiposClientes;
        }      
    }
}
