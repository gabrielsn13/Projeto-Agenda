using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio
{
    public class Telefone
    {
        public int IDTELEFONE { get; set; }

        public string DDD { get; set; }

        public string TELEFONE { get; set; }

        public int ID_TIPOTEL { get; set; }

        public int ID_CLIENTE { get; set; }
    }
}
