using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio
{
    public class Cliente
    {
        public int IDCLIENTE { get; set; }

        public string CPF_CNPJ { get; set; }

        public string NOME { get; set; }

        public string SOBRENOME { get; set; }

        public string CONJUGE { get; set; }

        public int ID_TIPO { get; set; }

        public int ID_CBO { get; set; }

        public int ID_CIDADE { get; set; }
    }
}
