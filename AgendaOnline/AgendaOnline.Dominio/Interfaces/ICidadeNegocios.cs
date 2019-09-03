using AgendaOnline.AcessoDados.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio.Interfaces
{
    interface ICidadeNegocios : IRepositorio<Cidade>
    {
        Cidade ListarCidades(int param);
    }
}
