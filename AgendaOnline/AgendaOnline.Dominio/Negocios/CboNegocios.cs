using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio.Negocios
{
    public class CboNegocios : CboRepositorio, ICboNegocios
    {
        public Cbo ListarCboNome(int param)
        {
            var cbo = ListarTodos().FirstOrDefault(x => x.IDCBO == param);
            return cbo;
        }
    }
}
