using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio
{
    public class ListagemAgendamento
    {
        public int CODIGO { get; set; }

        public string TITULO { get; set; }

        public string SALA { get; set; }

        public string CLIENTE { get; set; }

        public DateTime DATA { get; set; }

        public string OBSERVACOES { get; set; }
    }
}
