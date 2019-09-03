using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgendaOnline.Dominio;

namespace Agenda.Web.ViewModels
{
    public class PesquisaViewModel
    {
        public int NivelId { get; set; }
        
        public virtual IEnumerable<TipoCliente> tipos { get; set; }
    }
}