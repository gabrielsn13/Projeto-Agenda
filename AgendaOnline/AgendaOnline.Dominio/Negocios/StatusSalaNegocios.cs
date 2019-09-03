using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;

namespace AgendaOnline.Dominio.Negocios
{
    public class StatusSalaNegocios : StatusSalaRepositorio, IStatusSalaNegocios
    {
        public StatusSala ListarStatusSala(int param)
        {
            //busca o primeiro resultado encontrado
            var statusClientes = ListarTodos().FirstOrDefault(x => x.IDSTATUS == param);
            return statusClientes;
        }
    }
}
