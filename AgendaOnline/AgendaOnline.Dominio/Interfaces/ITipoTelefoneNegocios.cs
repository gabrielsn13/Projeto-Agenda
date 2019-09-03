using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.AcessoDados.Interface;

namespace AgendaOnline.Dominio.Interfaces
{
    interface ITipoTelefoneNegocios : IRepositorio<TipoTelefone>
    {
        TipoTelefone ListarTipoTelefones(int param);
    }
}
