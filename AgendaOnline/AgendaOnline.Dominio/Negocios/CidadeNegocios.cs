using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio.Negocios
{
    public class CidadeNegocios : CidadeRepositorio, ICidadeNegocios
    {
        public Cidade ListarCidades(int param)
        {
            var cidades = ListarTodos().FirstOrDefault(x => x.IDCIDADE == param);
            return cidades;
        }

  
    }
}
