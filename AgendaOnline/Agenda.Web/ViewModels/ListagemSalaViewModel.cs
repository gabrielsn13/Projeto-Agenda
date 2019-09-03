using AgendaOnline.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agenda.Web.ViewModels
{
    public class ListagemSalaViewModel
    {
        public int IDSALA { get; set; }

        //Validação informando que o campo abaixo é necessario
        public string SALA { get; set; }

        public string STATUS { get; set; }

        public ListagemSalaViewModel()
        {
        }
        public ListagemSalaViewModel(Sala sala)
        {
            IDSALA = sala.IDSALA;
            SALA = sala.SALA;
            if(sala.ID_STATUS == 1) {
                STATUS = "Disponível";
            }
            if (sala.ID_STATUS == 2)
            {
                STATUS = "Ocupada";
            }
            if (sala.ID_STATUS == 3)
            {
                STATUS = "Em Manutenção";
            }

        }
    }
}