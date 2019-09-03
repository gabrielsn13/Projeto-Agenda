using AgendaOnline.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Agenda.Web.ViewModels
{
    public class SalaViewModel
    {
        public int IDSALA { get; set; }

        //Validação informando que o campo abaixo é necessario
        [Required(ErrorMessage = " * Campo obrigatório")]
        public string SALA { get; set; }
    
        [Required(ErrorMessage = " * Campo obrigatório")]
        public int ID_STATUS { get; set; }
        
        public SalaViewModel()
        {
        }
        public SalaViewModel(Sala sala)
        {
            IDSALA = sala.IDSALA;
            SALA = sala.SALA;
            ID_STATUS = sala.ID_STATUS;
        }
    }
}
