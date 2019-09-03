using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Repositorios;

namespace AgendaOnline.Dominio.Negocios
{
    public class TelefoneNegocios : TelefoneRepositorio, ITelefoneNegocios 
    {
        public Telefone ListarTelefones(int param)
        {
            var telefones = ListarTodos().FirstOrDefault(x => x.IDTELEFONE == param);
            return telefones;
        }
    }
}
