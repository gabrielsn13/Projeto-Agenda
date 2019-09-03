using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;

namespace AgendaOnline.Dominio.Negocios
{
    public class SalaNegocios : SalaRepositorio, ISalaNegocios
    {
        public Sala ListarSala(int param)
        {
            //metodo nao retorna nada, avaliar a necessidade de listar as salas depois
            var sala = BuscarId(param);
            return sala;
        }
    }
}
