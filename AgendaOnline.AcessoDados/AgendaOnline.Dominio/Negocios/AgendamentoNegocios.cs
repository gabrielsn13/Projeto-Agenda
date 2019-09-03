using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;

namespace AgendaOnline.Dominio.Negocios
{
    public class AgendamentoNegocios : AgendamentoRepositorio, IAgendamentoNegocios
    {
        public Agendamento ListarAgendamento(string param)
        {
            var cliente = BuscarId(param);
            return cliente;
        }
    }
}
