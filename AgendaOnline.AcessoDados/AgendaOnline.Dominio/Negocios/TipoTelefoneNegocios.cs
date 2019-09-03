using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;

namespace AgendaOnline.Dominio.Negocios
{
    public class TipoTelefoneNegocios : TipoTelefoneRepositorio, ITipoTelefoneNegocios
    {
        public TipoTelefone ListarTipoTelefones(int param)
        {
            var tiposClientes = ListarTodos().FirstOrDefault(x => x.IDTIPOTEL == param);
            return tiposClientes;
        }
    }
}
