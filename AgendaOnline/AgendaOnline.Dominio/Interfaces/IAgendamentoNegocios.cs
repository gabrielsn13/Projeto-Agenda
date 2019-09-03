using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.AcessoDados.Interface;

namespace AgendaOnline.Dominio.Interfaces
{
    interface IAgendamentoNegocios : IRepositorio<Agendamento>
    {
        Agendamento ListarAgendamento(string param);
    }
}
