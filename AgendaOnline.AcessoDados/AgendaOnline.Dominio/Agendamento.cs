using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio
{
    public class Agendamento
    {
        public int IDAGENDAMENTO { get; set; }

        public string TITULO { get; set; }

        public int ID_SALA { get; set; }

        public int ID_CLIENTE { get; set; }

        public DateTime DATA { get; set; }

        public string OBSERVACOES { get; set; }
    }
}
